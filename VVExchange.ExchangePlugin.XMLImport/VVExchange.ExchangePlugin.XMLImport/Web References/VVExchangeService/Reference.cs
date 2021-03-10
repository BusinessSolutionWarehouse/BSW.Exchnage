﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34011.
// 
#pragma warning disable 1591

namespace VVExchange.ExchangePlugin.XMLImport.VVExchangeService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IService", Namespace="http://tempuri.org/")]
    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetDataOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetMessagesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service() {
            this.Url = global::VVExchange.ExchangePlugin.XMLImport.Properties.Settings.Default.VVExchange_ExchangePlugin_XMLImport_VVExchangeService_Service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetDataCompletedEventHandler GetDataCompleted;
        
        /// <remarks/>
        public event GetMessagesCompletedEventHandler GetMessagesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IService/GetData", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string GetData([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string value) {
            object[] results = this.Invoke("GetData", new object[] {
                        value});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetDataAsync(string value) {
            this.GetDataAsync(value, null);
        }
        
        /// <remarks/>
        public void GetDataAsync(string value, object userState) {
            if ((this.GetDataOperationCompleted == null)) {
                this.GetDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDataOperationCompleted);
            }
            this.InvokeAsync("GetData", new object[] {
                        value}, this.GetDataOperationCompleted, userState);
        }
        
        private void OnGetDataOperationCompleted(object arg) {
            if ((this.GetDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDataCompleted(this, new GetDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IService/GetMessages", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GetMessages([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] System.Nullable<byte> profileID, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] [System.Xml.Serialization.XmlIgnoreAttribute()] bool profileIDSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] System.Nullable<System.DateTime> messageDT, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] [System.Xml.Serialization.XmlIgnoreAttribute()] bool messageDTSpecified, [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)] [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/VVExchangeWCF")] ref ImportMessageModel[] importMessageModel, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] ref string msg, out bool GetMessagesResult, [System.Xml.Serialization.XmlIgnoreAttribute()] out bool GetMessagesResultSpecified) {
            object[] results = this.Invoke("GetMessages", new object[] {
                        profileID,
                        profileIDSpecified,
                        messageDT,
                        messageDTSpecified,
                        importMessageModel,
                        msg});
            importMessageModel = ((ImportMessageModel[])(results[0]));
            msg = ((string)(results[1]));
            GetMessagesResult = ((bool)(results[2]));
            GetMessagesResultSpecified = ((bool)(results[3]));
        }
        
        /// <remarks/>
        public void GetMessagesAsync(System.Nullable<byte> profileID, bool profileIDSpecified, System.Nullable<System.DateTime> messageDT, bool messageDTSpecified, ImportMessageModel[] importMessageModel, string msg) {
            this.GetMessagesAsync(profileID, profileIDSpecified, messageDT, messageDTSpecified, importMessageModel, msg, null);
        }
        
        /// <remarks/>
        public void GetMessagesAsync(System.Nullable<byte> profileID, bool profileIDSpecified, System.Nullable<System.DateTime> messageDT, bool messageDTSpecified, ImportMessageModel[] importMessageModel, string msg, object userState) {
            if ((this.GetMessagesOperationCompleted == null)) {
                this.GetMessagesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMessagesOperationCompleted);
            }
            this.InvokeAsync("GetMessages", new object[] {
                        profileID,
                        profileIDSpecified,
                        messageDT,
                        messageDTSpecified,
                        importMessageModel,
                        msg}, this.GetMessagesOperationCompleted, userState);
        }
        
        private void OnGetMessagesOperationCompleted(object arg) {
            if ((this.GetMessagesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMessagesCompleted(this, new GetMessagesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/VVExchangeWCF")]
    public partial class ImportMessageModel {
        
        private System.Nullable<System.DateTime> messageDTField;
        
        private bool messageDTFieldSpecified;
        
        private System.Nullable<long> messageIDField;
        
        private bool messageIDFieldSpecified;
        
        private System.Nullable<byte> profileIDField;
        
        private bool profileIDFieldSpecified;
        
        private string xMLMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> MessageDT {
            get {
                return this.messageDTField;
            }
            set {
                this.messageDTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MessageDTSpecified {
            get {
                return this.messageDTFieldSpecified;
            }
            set {
                this.messageDTFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> MessageID {
            get {
                return this.messageIDField;
            }
            set {
                this.messageIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MessageIDSpecified {
            get {
                return this.messageIDFieldSpecified;
            }
            set {
                this.messageIDFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<byte> ProfileID {
            get {
                return this.profileIDField;
            }
            set {
                this.profileIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProfileIDSpecified {
            get {
                return this.profileIDFieldSpecified;
            }
            set {
                this.profileIDFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string XMLMessage {
            get {
                return this.xMLMessageField;
            }
            set {
                this.xMLMessageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetDataCompletedEventHandler(object sender, GetDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetMessagesCompletedEventHandler(object sender, GetMessagesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMessagesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetMessagesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ImportMessageModel[] importMessageModel {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ImportMessageModel[])(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string msg {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public bool GetMessagesResult {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public bool GetMessagesResultSpecified {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[3]));
            }
        }
    }
}

#pragma warning restore 1591