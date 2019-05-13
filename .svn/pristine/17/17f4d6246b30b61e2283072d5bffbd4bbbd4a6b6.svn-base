using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Configuration;

namespace BSW_ExchangeData
{
    public class ControllerManager
    {
        #region Private Members

        private static string _connectionString = "";

        private static int _loggedInUserID = -1;

        #endregion

        public static bool ExecuteSQL(string sql, ref string msg)
        {
            bool result = true;

            try
            {
                using (SqlConnection con = OpenConn(ref msg))
                {
                    if (con.State == ConnectionState.Open)
                    {
                        using (SqlCommand com = new SqlCommand(sql, con))
                        {
                            com.ExecuteNonQuery();
                        }
                        con.Close();
                        msg = "Success";
                    }
                    else
                        result = false;
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

        //This method does not log errors that occur, it is used by the method that loggs errors... otherwise it could cause an endless loop.
        public static bool ExecuteSP_WithoutErrorLogging(string spName, List<SqlParameter> parameters, ref string msg)
        {
            bool result = true;

            try
            {
                using (SqlConnection con = OpenConn(ref msg))
                {
                    if (con.State == ConnectionState.Open)
                    {

                        using (SqlCommand com = new SqlCommand(spName, con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddRange(parameters.ToArray());
                            com.ExecuteNonQuery();
                        }
                        con.Close();
                        msg = "Success";
                    }
                    else
                        result = false;
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

        public static bool ExecuteSP(string spName, List<SqlParameter> parameters, ref string msg)
        {
            bool result = true;

            try
            {
                using (SqlConnection con = OpenConn(ref msg))
                {
                    if (con.State == ConnectionState.Open)
                    {

                        using (SqlCommand com = new SqlCommand(spName, con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddRange(parameters.ToArray());
                            com.ExecuteNonQuery();
                        }
                        con.Close();
                        msg = "Success";
                    }
                    else
                        result = false;
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

        public static bool ExecuteSP(string spName, List<SqlParameter> parameters, IController controller, ref string msg)
        {
            bool result = true;

            try
            {
                using (SqlConnection con = OpenConn(ref msg))
                {
                    if (con.State == ConnectionState.Open)
                    {
                        using (SqlCommand com = new SqlCommand(spName, con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddRange(parameters.ToArray());

                            using (SqlDataReader reader = com.ExecuteReader())
                            {
                                controller.ClearModelData();
                                while (reader.Read())
                                {
                                    result = controller.ReadModelData(reader, ref msg);
                                    if (!result)
                                        break;
                                }
                            }
                        }
                        con.Close();
                        if (result)
                            msg = "Success";
                    }
                    else
                        result = false;

                }


            }
            catch (Exception ex)
            {
                controller.ClearModelData();
                msg = ex.Message;
                result = false;
            }

            return result;
        }

        public static bool ExecuteSPScalar(string spName, List<SqlParameter> parameters, ref object value, ref string msg)
        {
            bool result = true;

            try
            {
                using (SqlConnection con = OpenConn(ref msg))
                {
                    if (con.State == ConnectionState.Open)
                    {

                        using (SqlCommand com = new SqlCommand(spName, con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddRange(parameters.ToArray());

                            value = com.ExecuteScalar();
                        }
                        con.Close();
                        msg = "Success";
                    }
                    else
                        result = false;

                }


            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

        public static SqlParameter CreateParameter(string name, object value, SqlDbType type)
        {
            SqlParameter param = new SqlParameter(name, Converter.IsNullOrDBNull(value) ? DBNull.Value : value);
            param.SqlDbType = type;

            return param;
        }

        public static int LoggedInUserID
        {
            get { return ControllerManager._loggedInUserID; }
            set { ControllerManager._loggedInUserID = value; }
        }

        #region Private Properties
        /// <summary>
        /// Get the connection string to be used by this controller.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings.Count > 0)
                {
                    var c = ConfigurationManager.ConnectionStrings[0];
                    return c.ConnectionString;
                }

                return "";
            }
        }
        #endregion

        #region Private Members
        /// <summary>
        /// Open a connection to the current sql database
        /// </summary>
        /// <param name="expMsg">SQLException message</param>
        /// <returns>SQLConnection</returns>
        private static SqlConnection OpenConn(ref string expMsg)
        {
            SqlConnection conn = new SqlConnection();

            try
            {
                //get the connection string to use
                conn.ConnectionString = ConnectionString;
                conn.Open();
            }
            catch (SqlException exp)
            {
                expMsg = exp.Message;
            }
            return conn;
        }
        #endregion

        public class Converter
        {
            public static bool IsNullOrDBNull(object value)
            {
                if (value is string)
                {
                    return string.IsNullOrEmpty(value as String);
                }

                if (value is Guid)
                {
                    return ((Guid)value) == Guid.Empty;
                }

                return value == null || value == DBNull.Value;
            }

            public static Int16? ToInt16(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                Int16? result = null;

                try
                {
                    result = Convert.ToInt16(value);
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static int? ToInt32(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                Int32? result = null;

                try
                {
                    result = Convert.ToInt32(value);
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static Int64? ToInt64(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                Int64? result = null;

                try
                {
                    result = Convert.ToInt64(value);
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static decimal? ToDecimal(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                decimal? result = null;

                try
                {
                    result = Convert.ToDecimal(value);
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static double? ToDouble(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                double? result = null;

                try
                {
                    result = Convert.ToDouble(value);
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static bool? ToBool(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                bool? result = null;

                try
                {
                    result = Convert.ToBoolean(value);
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static byte[] ToByteArray(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                byte[] result = null;

                try
                {
                    result = (byte[])value;
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static byte? ToByte(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                byte? result = null;

                try
                {
                    result = Convert.ToByte(value);
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static Single? ToSingle(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                Single? result = null;

                try
                {
                    result = Convert.ToSingle(value);
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static DateTime? ToDateTime(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                DateTime? result = null;

                try
                {
                    result = Convert.ToDateTime(value);
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static Guid? ToGuid(object value)
            {
                if (IsNullOrDBNull(value))
                    return null;

                Guid? result = null;

                try
                {
                    result = (Guid)value;
                }
                catch
                {
                    result = null;
                }

                return result;
            }

            public static string ToString(object value)
            {
                if (IsNullOrDBNull(value))
                    return "";

                string result = "";

                try
                {
                    result = Convert.ToString(value);
                }
                catch
                {
                    result = "";
                }

                return result;
            }

           
       
        }

        public class Transaction
        {
            private static TransactionScope _tranScope = null;

            //Starts a transaction.
            public static bool Begin(ref string msg)
            {
                try
                {
                    if (_tranScope != null)
                        RollBack(ref msg);

                    _tranScope = new TransactionScope();
                    return true;
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    return false;
                }
            }

            //Closes the transaction and commits it.
            public static bool End(ref string msg)
            {
                try
                {
                    if (_tranScope == null) { msg = "The transaction has not been instantiated yet."; return false; }

                    _tranScope.Complete(); //Commits
                    _tranScope.Dispose();
                    _tranScope = null;
                    return true;
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    return false;
                }
            }

            //Rollsback the transaction
            public static bool RollBack(ref string msg)
            {
                try
                {
                    if (_tranScope == null) { msg = "The transaction has not been instantiated yet."; return false; }

                    _tranScope.Dispose();
                    _tranScope = null;
                    return true;
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    return false;
                }
            }
        }
    }
}
