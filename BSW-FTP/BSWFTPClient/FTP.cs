using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BSWFTPClient
{
    public class FTP:IDisposable
    {
        
        #region Construct & Dispose
        // Pointer to an external unmanaged resource.
        private IntPtr handle;
        // Other managed resource this class uses.
        private Component component = new Component();
        // Track whether Dispose has been called.
        private bool disposed = false;

        // The class constructor.
        public FTP(IntPtr handle)
        {
            this.handle = handle;
        }

        public void Dispose()
        {
            Dispose(true);
            
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if(!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if(disposing)
                {
                    // Dispose managed resources.
                    component.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;

                // Note disposing has been done.
                disposed = true;

            }
        }

        // Use interop to call the method necessary
        // to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        ~FTP()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }

        public FTP()
        {
            
        }

        /// <summary>
        /// Initiate a new instance of the class
        /// </summary>
        /// <param name="hostServer">FTP site/server that will be used</param>
        /// <param name="username">User name used to connect to the ftp site</param>
        /// <param name="password">Password used to connect to the ftp site</param>
        public FTP(string hostServer, string username, string password)
        {
            Host = hostServer;
            UserName = username;
            Password = password;
        }


        #endregion

        private int bufferSize = 2048;
        private string _Host = string.Empty;

        #region - Custom Events -

        /// <summary>
        /// The event is raised upone upload and downloading of a file
        /// </summary>
        /// <param name="totalSoze">Total size of the file in bytes</param>
        /// <param name="sizedone">Total size of bytes successfully transfered</param>
        public delegate void FileProgressChangedDelegate(Int64 totalSize, Int64 sizedone);
        public event FileProgressChangedDelegate FileProgressChanged;

        public delegate void ExceptionRaisedDelegate(string errorMsg);
        public event ExceptionRaisedDelegate ExceptionRaised;

        public delegate void ProgressDetailChangedDelegate(string info);
        public event ProgressDetailChangedDelegate ProgressDetailChanged;

        #endregion

        #region - Properties -

        /// <summary>
        /// Get/Set the FTP hosting server/FTP Site
        /// </summary>
        public string Host 
        {
            get { return _Host; }
            set
            {
                _Host = value;
                //check to see if the host includes the ftp:// - part
                if (!_Host.ToLower().StartsWith("ftp://"))
                {
                    _Host = "ftp://" + _Host;
                }
            }
        }

        /// <summary>
        /// Gte/Set the user name that will be used to connect to the ftp site
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gte/Set the password that will be used to connect to the ftp site
        /// </summary>
        public string Password { get; set; }

        public string ProxyAddress { get; set; }

        public string ProxyDomain { get; set; }

        public string ProxyUID { get; set; }

        public string ProxyPwd { get; set; }

        /// <summary>
        /// Gte/Set the file upload/donwload buffer size in bytes - Default =  2048
        /// </summary>
        public int BufferSize
        {
            get { return bufferSize; }
            set { bufferSize = value; }
        }

        #endregion

        #region - Public Methods -

        /// <summary>
        /// Uplaod a file to the FTP Site
        /// </summary>
        /// <param name="remoteFile">If the file name blank - the system will use the local file name</param>
        /// <param name="localFile">File that will be send</param>
        /// <returns></returns>
        public bool UploadFile(string remoteFile, string localFile)
        {
            bool result = true;
            try
            {
                //we need to check if the local file exists
                if (!File.Exists(localFile))
                {
                    RaiseException(localFile + " - Not found!");
                    return false;
                }
                //check if the remote file name is valid
                if (string.IsNullOrEmpty(remoteFile))
                {
                    remoteFile = Path.GetFileName(localFile);
                }

                using (FileStream localFileSt = new FileStream(localFile, FileMode.OpenOrCreate))
                {
                    result = UploadFile(localFileSt, remoteFile);

                    //always close the local file
                    localFileSt.Flush();
                    localFileSt.Close();
                }
                
            }
            catch (Exception exp)
            {
                result = false;
                RaiseException(exp.Message);
            }
            return result;

        }

        public bool UploadFile(string remoteFile, MemoryStream localFile)
        {
            bool result = true;
            try
            {
                result = UploadFile(localFile.ToArray(), remoteFile);
            }
            catch (Exception exp)
            {
                result = false;
                RaiseException(exp.Message);
            }
            return result;

        }

        /// <summary>
        /// Get the size of a file on the FTP site
        /// </summary>
        /// <param name="fileName">Name of file we want to get the size of</param>
        /// <returns>-1 If the file is not found else the size of the file</returns>
        public long GetFileSize(string fileName)
        {
            long fileSize = -1;
            try
            {
                //create an FTP request
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(Host + "/" + fileName);

                //set the login credentials
                request.Credentials = new NetworkCredential(UserName, Password);
                //Set the default options to use
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;

                //we need to set the type
                request.Method = WebRequestMethods.Ftp.GetFileSize;

                // Establish Return Communication with the FTP Server
                FtpWebResponse ftpResponse = (FtpWebResponse)request.GetResponse();
                //get the responce content lenght/ file size
                fileSize = ftpResponse.ContentLength;

                //close the cnnection to the ftp site
                request.Abort();
                request = null;
                
            }
            catch (Exception exp) 
            { 
                //set the file size to -1 if a error is raised
                fileSize = -1;
                RaiseException(exp.Message);
            }

            return fileSize;
        }

        ///<summary>
        /// Get the request using a specific URI
        ///</summary>
        ///<param name=”method”></param>
        ///<param name=”uri”></param>
        ///<returns></returns>
        private FtpWebRequest GetWebRequest(string method, string folderName)
        {
            var reqFTP = (FtpWebRequest)FtpWebRequest.Create(Host + "/" + folderName);
            //check if proxy setting are being used
            if (!string.IsNullOrEmpty(ProxyAddress))
            {
                //we set it to bypass local by default
                WebProxy proxy = new WebProxy(ProxyAddress, true);
                proxy.Credentials = new NetworkCredential(ProxyUID, ProxyPwd, ProxyDomain);
                reqFTP.Proxy = proxy;
            }
            else
                reqFTP.Proxy = null;

            reqFTP.Method = method;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(UserName, Password);
            
            return reqFTP;
        }

        public bool MoveRemoteFile(string Folder, string fileName)
        {
            try
            {
                var request = GetWebRequest(WebRequestMethods.Ftp.Rename, Folder + "/" + fileName);
                request.RenameTo = "error/" + fileName;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                RaiseException(ex.Message);
                return false;
            }
        }

        public bool DeleteRemoteFile(string Folder, string fileName)
        {
            try
            {
                var request = GetWebRequest(WebRequestMethods.Ftp.DeleteFile, Folder + "/" + fileName);
                request.UsePassive = true;
                request.KeepAlive = true;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                RaiseException(ex.Message);
                return false;
            }
        }

        public List<RemoteFile> ReadRemoteXML(string Folder, DateTime? lastProcessed)
        {
            List<RemoteFile> list = new List<RemoteFile>();
            string[] listFiles;

            if (lastProcessed == null)
            {
                // give last processed a date 
                lastProcessed = Convert.ToDateTime("1900-01-01");
            }

            try
            {
                var request = GetWebRequest(WebRequestMethods.Ftp.ListDirectory, Folder);
                request.KeepAlive = true;
                request.Timeout = 10000000;
                request.UsePassive = false;

                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                string readerList = reader.ReadToEnd();

                reader.Close();
                response.Close();

                listFiles = readerList.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string file in listFiles)
                {
                    if (file != "error")
                    {
                        RemoteFile remoteFile = new RemoteFile();
                        remoteFile.FileName = file.ToString();

                        var requestDate = GetWebRequest(WebRequestMethods.Ftp.GetDateTimestamp, Folder + "/" + remoteFile.FileName);
                        FtpWebResponse resp = (FtpWebResponse)requestDate.GetResponse();
                        remoteFile.FileCreated = resp.LastModified;

                        list.Add(remoteFile);

                        //close the connection to the ftp site
                        requestDate = null;
                    }
                }
            }
            catch (WebException ex)
            {
                FtpWebResponse FtpResponse = (FtpWebResponse)ex.Response;
                FtpResponse.Close();
            }
            catch (Exception ex)
            {
                // do nothing well
            }

            list = list.OrderBy(d => d.FileCreated).ToList();
            list.RemoveAll(a => a.FileCreated < lastProcessed);
            foreach (RemoteFile remoteFile in list)
            {
                if (remoteFile.FileCreated >= lastProcessed)
                {
                    // process
                    WebClient requestContents = new WebClient();
                    requestContents.Credentials = new NetworkCredential(UserName, Password);

                    try
                    {
                        byte[] newFileData = requestContents.DownloadData(Host + "/" + Folder + "/" + remoteFile.FileName);
                        string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                        remoteFile.FileContents = fileString;
                    }
                    catch (WebException e)
                    {
                        remoteFile.FileContents = e.Message;
                    }
                }
                else
                {
                    list.RemoveAll(a => a.FileName == remoteFile.FileName && a.FileCreated == remoteFile.FileCreated);
                }
            }            
            return list;
        }

        public bool DownloadFile(string remoteFile, string localFile)
        {
            bool result = true;

            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(Host + "/" + remoteFile);

                //check if proxy setting are being used
                if (!string.IsNullOrEmpty(ProxyAddress))
                {
                    //we set it to bypass local by default
                    WebProxy proxy = new WebProxy(ProxyAddress,true);
                    proxy.Credentials = new NetworkCredential(ProxyUID, ProxyPwd, ProxyDomain);
                    request.Proxy = proxy;
                }

                //set the login credentials
                request.Credentials = new NetworkCredential(UserName, Password);
                //Set the default options to use
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;

                //we need to set the type
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                FtpWebResponse ftpResponse = (FtpWebResponse)request.GetResponse();

                //Get the FTP Server's Response Stream 
                using (Stream ftpStream = ftpResponse.GetResponseStream())
                {
                    // Open a File Stream to Write the Downloaded File
                    using (FileStream localFileStream = new FileStream(localFile, FileMode.Create))
                    {
                        //Buffer for the Downloaded Data
                        byte[] byteBuffer = new byte[bufferSize];
                        int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                        long bytesAlreadyDownloaded = 0;
                        //Download the File by Writing the Buffered Data Until the Transfer is Complete
                        try
                        {
                            while (bytesRead > 0)
                            {
                                localFileStream.Write(byteBuffer, 0, bytesRead);

                                bytesAlreadyDownloaded += bytesRead;
                                //This only works if the steam is seakable
                                //RaiseFileProgessChanged(ftpStream.Length, bytesAlreadyDownloaded);

                                bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                            }
                        }
                        catch (Exception ex)
                        { 
                            Console.WriteLine(ex.ToString());
                        }
                        //Resource Cleanup
                        localFileStream.Flush();
                        localFileStream.Close();
                    }
                    ftpStream.Close();
                }
               
                ftpResponse.Close();
               
            }
            catch (Exception ex)
            {
                result = false;
                RaiseException(ex.Message);
            }

            return result;

        }

        public List<string> GetFtpDirectoryDetails(string strDir)
        {
            List<string> lst_strFiles = new List<string>();
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Host + "/" + strDir);
                //check if proxy setting are being used
                if (!string.IsNullOrEmpty(ProxyAddress))
                {
                    //we set it to bypass local by default
                    WebProxy proxy = new WebProxy(ProxyAddress, true);
                    proxy.Credentials = new NetworkCredential(ProxyUID, ProxyPwd, ProxyDomain);
                    request.Proxy = proxy;
                }
                else
                    request.Proxy = null;
             
                request.Credentials = new NetworkCredential(UserName, Password);
                //Set the default options to use
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
              
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                StreamReader file = new StreamReader(response.GetResponseStream());

                while (!file.EndOfStream)
                {
                    lst_strFiles.Add(file.ReadLine());
                }
                file.Close();
                response.Close();

                return lst_strFiles;
            }
            catch (Exception ex)
            {
                RaiseException(ex.Message);
                return null;
            }
        }

        public List<FTPLineResult> GetFilesListSortedByDate(string ftpPath, string fileStartWith)
        {
            List<FTPLineResult> output = new List<FTPLineResult>();

            try
            {
                
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Host + "/" + ftpPath);
                //check if proxy setting are being used
                if (!string.IsNullOrEmpty(ProxyAddress))
                {
                    //we set it to bypass local by default
                    WebProxy proxy = new WebProxy(ProxyAddress, true);
                    proxy.Credentials = new NetworkCredential(ProxyUID, ProxyPwd, ProxyDomain);
                    request.Proxy = proxy;
                }
                else
                    request.Proxy = null;

                request.Credentials = new NetworkCredential(UserName, Password);
                //Set the default options to use
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;

                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                StreamReader directoryReader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.ASCII);

                var parser = new FTPLineParser();
               
                while (!directoryReader.EndOfStream)
                {
                    var result = parser.Parse(directoryReader.ReadLine());

                   
                    if (!result.IsDirectory && result.Name.ToLower().StartsWith(fileStartWith.ToLower()))
                    {
                        output.Add(result);
                    }
                    
                }
                // need to ensure the files are sorted in ascending date order
                output.Sort(
                    new Comparison<FTPLineResult>(
                        delegate(FTPLineResult res1, FTPLineResult res2)
                        {
                            return res1.DateTime.CompareTo(res2.DateTime);
                        }
                    )
                );
            }
            catch (Exception exp)
            {
                RaiseException(exp.Message);
                output = new List<FTPLineResult>();
            }

            return output;
        }

        private void parser_ExceptionRaised(string errorMsg)
        {
            RaiseException(errorMsg);
        }
     
        #endregion

        #region - Private Methods - 

        /// <summary>
        /// Upload the selected file to the curret ftp site
        /// </summary>
        /// <param name="localSt">File Stream of the local file to be send</param>
        /// <param name="remoteFile">File name and extention - of the new file that will be created on the ftp Site</param>
        /// <returns>Bool indicatting sucess</returns>
        private bool UploadFile(FileStream localSt, string remoteFile)
        {
            bool result = true;
            try
            {
                //create an FTP request
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(Host + "/" + remoteFile);

                //check if proxy setting are being used
                if (!string.IsNullOrEmpty(ProxyAddress))
                {
                    //we set it to bypass local by default
                    WebProxy proxy = new WebProxy(ProxyAddress, true);
                    proxy.Credentials = new NetworkCredential(ProxyUID, ProxyPwd, ProxyDomain);
                    request.Proxy = proxy;
                }


                //set the login credentials
                request.Credentials = new NetworkCredential(UserName, Password);
                //Set the default options to use
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;

                //we need to set the type
                request.Method = WebRequestMethods.Ftp.UploadFile;
                //Get a communication open with the ftp server
                using (Stream ftpStream = request.GetRequestStream())
                {
                    try
                    {
                        byte[] byteBuffer = new byte[bufferSize];

                        //get the first bytes to send
                        int bytesToSend = localSt.Read(byteBuffer, 0, bufferSize);
                        long bytesAlreadySend = 0;

                        while (bytesToSend != 0)
                        {
                            //Send the bytes across to the new file on the ftp server
                            ftpStream.Write(byteBuffer, 0, bytesToSend);

                            //update the file send progress
                            bytesAlreadySend += bytesToSend;
                            //RaiseFileProgessChanged(localSt.Length, bytesAlreadySend);
                            //read the next set of bytes
                            bytesToSend = localSt.Read(byteBuffer, 0, bufferSize);
                        }
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        RaiseException(ex.Message);
                    }
                    finally
                    {
                        //close the file on the ftp server
                        ftpStream.Flush();
                        ftpStream.Close();
                    }
                }
                //close the cnnection to the ftp site
                request.Abort();
                request = null;
            }
            catch (Exception exp)
            {
                result = false;
                RaiseException(exp.Message);
            }
            return result;
        }

        /// <summary>
        /// Upload the selected file to the curret ftp site
        /// </summary>
        /// <param name="localSt">Memory Stream of the local file to be send</param>
        /// <param name="remoteFile">File name and extention - of the new file that will be created on the ftp Site</param>
        /// <returns>Bool indicatting sucess</returns>
        private bool UploadFile(byte[] SendBytes, string remoteFile)
        {
            bool result = true;
            try
            {
                //create an FTP request
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(Host + "/" + remoteFile);
                //check if proxy setting are being used
                if (!string.IsNullOrEmpty(ProxyAddress))
                {
                    //we set it to bypass local by default
                    WebProxy proxy = new WebProxy(ProxyAddress, true);
                    proxy.Credentials = new NetworkCredential(ProxyUID, ProxyPwd, ProxyDomain);
                    request.Proxy = proxy;
                }

                //set the login credentials
                request.Credentials = new NetworkCredential(UserName, Password);
                //Set the default options to use
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;

                //we need to set the type
                request.Method = WebRequestMethods.Ftp.UploadFile;
                //Get a communication open with the ftp server
                using (Stream ftpStream = request.GetRequestStream())
                {
                    try
                    {
                        byte[] byteBuffer = new byte[bufferSize];
                        using (MemoryStream localSt = new MemoryStream(SendBytes))
                        {

                            //get the first bytes to send
                            int bytesToSend = localSt.Read(byteBuffer, 0, bufferSize);

                            long bytesAlreadySend = 0;

                            while (bytesToSend != 0)
                            {
                                //Send the bytes across to the new file on the ftp server
                                ftpStream.Write(byteBuffer, 0, bytesToSend);

                                //update the file send progress
                                bytesAlreadySend += bytesToSend;
                               // RaiseFileProgessChanged(localSt.Length, bytesAlreadySend);

                                //read the next set of bytes
                                bytesToSend = localSt.Read(byteBuffer, 0, bufferSize);
                            }

                            localSt.Flush();
                        }
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        RaiseException(ex.Message);
                    }
                    finally
                    {
                        //close the file on the ftp server
                        ftpStream.Flush();
                        ftpStream.Close();
                    }
                }
                //close the cnnection to the ftp site
                request.Abort();
                request = null;
            }
            catch (Exception exp)
            {
                result = false;
                RaiseException(exp.Message);
            }
            return result;
        }

        /// <summary>
        /// Custom method to validate the Exception Raised event - and rais it
        /// </summary>
        /// <param name="errorMsg">Exception message that as raised</param>
        private void RaiseException(string errorMsg)
        {
            if (ExceptionRaised != null)
                ExceptionRaised(errorMsg);

            Application.DoEvents(); //Allow the event to fire - before we carry on
        }

        /// <summary>
        /// Method to validate File progress changed - and raise the event
        /// </summary>
        /// <param name="totalSize">Total size of the file</param>
        /// <param name="sizedone">Total soze uploaded/donwloaded</param>
        private void RaiseFileProgessChanged(Int64 totalSize, Int64 sizedone)
        {
            
            if (FileProgressChanged != null)
                FileProgressChanged(totalSize, sizedone);

            Application.DoEvents(); //Allow the event to fire - before we carry on
        }

        /// <summary>
        /// Validate the progresschanged event - and rais it if valid
        /// </summary>
        /// <param name="msg">Information of the current process</param>
        private void RaiseProcessDetailChanged(string msg)
        {
            if (ProgressDetailChanged != null)
                ProgressDetailChanged(msg);

            Application.DoEvents(); //Allow the event to fire - before we carry on
        }

        /// <summary>
        /// Note - This function has not been tested yet
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string getFileSize(string fileName)
        {
            try
            {

                //TODO: Test this function
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(Host + "/" + fileName);

                //check if proxy setting are being used
                if (!string.IsNullOrEmpty(ProxyAddress))
                {
                    //we set it to bypass local by default
                    WebProxy proxy = new WebProxy(ProxyAddress, true);
                    proxy.Credentials = new NetworkCredential(ProxyUID, ProxyPwd, ProxyDomain);
                    request.Proxy = proxy;
                }

                //set the login credentials
                request.Credentials = new NetworkCredential(UserName, Password);
                //Set the default options to use
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;

                /* Specify the Type of FTP Request */
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                /* Establish Return Communication with the FTP Server */
                FtpWebResponse ftpResponse = (FtpWebResponse)request.GetResponse();
                /* Establish Return Communication with the FTP Server */
                 Stream ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string fileInfo = null;
                /* Read the Full Response Stream */
                try { while (ftpReader.Peek() != -1) { fileInfo = ftpReader.ReadToEnd(); } }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                request = null;
                /* Return File Size */
                return fileInfo;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return "";
        }

            
        
        #endregion
    }

    public class RemoteFile
    {
        private DateTime? fileCreated = null;
        private string fileName = string.Empty;
        private string fileContents = string.Empty;

        public DateTime? FileCreated
        {
            get { return fileCreated; }
            set { fileCreated = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string FileContents
        {
            get { return fileContents; }
            set { fileContents = value; }
        }
    }

    public enum ListStyle
    {
        Unix,
        Windows
    }

    public class FTPLineResult
    {
        public ListStyle Style { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDirectory { get; set; }
        public long Size { get; set; }
    }

    public class FTPLineParser
    {
        
        private Regex winStyle = new Regex(@"^(?<month>\d{1,2})-(?<day>\d{1,2})-(?<year>\d{1,2})\s+(?<hour>\d{1,2}):(?<minutes>\d{1,2})(?<ampm>am|pm)\s+(?<dir>[<]dir[>])?\s+(?<size>\d+)?\s+(?<name>.*)$", RegexOptions.IgnoreCase);

        public FTPLineResult Parse(string line)
        {
                           
            //we need to check the format first
            if (line.ToLower().Contains("rw"))
            {
                
                FTPLineResult lineResult = new FTPLineResult();
                if (line.ToLower().StartsWith("dr"))
                {
                    lineResult.IsDirectory = true;
                }
                else
                {
                    lineResult.IsDirectory = false;
                }
                //-rw-rw-rw-   1 user     group         145 Feb 25 08:29 list_FromLS_25.02.14.08.30.00
                //-rw-rw-rw-   1 user     group        1113 Mar  4 09:00 list_FromLs_Test
 
                string[] values = line.Split(Convert.ToChar(" "));

                
                if (values.Length > 10)
                {
                    //get the date 
                    string sday = string.Empty;
                    string sMonth = string.Empty;
                    string sTime = string.Empty;
                    int monthLocation = 0;

                    sTime = values[values.Length - 2].Trim();
                    sday = values[values.Length - 3].Trim();

                    if (!string.IsNullOrEmpty(values[values.Length - 4].Trim()))
                    {
                        monthLocation = 4;
                        sMonth = values[values.Length - 4].Trim();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(values[values.Length - 5].Trim()))
                        {
                            monthLocation = 5;
                            sMonth = values[values.Length - 5].Trim();
                        }
                    }

                    if (string.IsNullOrEmpty(sMonth))
                        sMonth = DateTime.Now.Month.ToString();


                    if (!lineResult.IsDirectory)
                    {
                        if (monthLocation > 0)
                            lineResult.Size = long.Parse(values[values.Length - (monthLocation + 1)].Trim());
                    }

                    lineResult.DateTime = Convert.ToDateTime(DateTime.Now.Year + "-" + sMonth + "-" + sday + " " + sTime);
                    
                    lineResult.Name = values[values.Length - 1].Trim();

                    
                }

                return lineResult;
            }
            else
            { 
                //new windows foramt - containing date first
                Match match = winStyle.Match(line);
                if (match.Success)
                {
                    return ParseMatch(match.Groups, ListStyle.Windows);
                }
            }

            throw new Exception("Invalid line format - " + line);
        }

        private FTPLineResult ParseMatch(GroupCollection matchGroups, ListStyle style)
        {
            string dirMatch = (style == ListStyle.Unix ? "d" : "<dir>");
            
            FTPLineResult result = new FTPLineResult();
            result.Style = style;
            result.IsDirectory = matchGroups["dir"].Value.Equals(dirMatch, StringComparison.InvariantCultureIgnoreCase);
            result.Name = matchGroups["name"].Value;
            
            result.DateTime = new DateTime(2000 + int.Parse(matchGroups["year"].Value), int.Parse(matchGroups["month"].Value), int.Parse(matchGroups["day"].Value), int.Parse(matchGroups["hour"].Value) + (matchGroups["ampm"].Value.Equals("PM") && matchGroups["hour"].Value != "12" ? 12 : 0), int.Parse(matchGroups["minutes"].Value), 0);
            
            if (!result.IsDirectory)
                result.Size = long.Parse(matchGroups["size"].Value);
            
            return result;
        }

    }
}

   

   

