//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MrTMaker.opcion {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IOpcion", Namespace="http://tempuri.org/")]
    public partial class SQL_Opcion : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public SQL_Opcion() {
			this.Url = "http://192.168.43.5:8733/Design_Time_Addresses/HostWCF/ServicioWCF/opcion/opcion";
			//this.Url = "http://192.168.1.67:8733/Design_Time_Addresses/HostWCF/ServicioWCF/opcion/opcion";
		}
        
        public SQL_Opcion(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IOpcion/getAllOptions", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/SQL_ClassLibrary")]
        public SQL_Opcion1[] getAllOptions([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] SQL_Atributo atr) {
            object[] results = this.Invoke("getAllOptions", new object[] {
                        atr});
            return ((SQL_Opcion1[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetAllOptions(SQL_Atributo atr, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getAllOptions", new object[] {
                        atr}, callback, asyncState);
        }
        
        /// <remarks/>
        public SQL_Opcion1[] EndgetAllOptions(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((SQL_Opcion1[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IOpcion/getOpcionByGroup", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/SQL_ClassLibrary")]
        public SQL_Opcion1[] getOpcionByGroup([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string group) {
            object[] results = this.Invoke("getOpcionByGroup", new object[] {
                        group});
            return ((SQL_Opcion1[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetOpcionByGroup(string group, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getOpcionByGroup", new object[] {
                        group}, callback, asyncState);
        }
        
        /// <remarks/>
        public SQL_Opcion1[] EndgetOpcionByGroup(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((SQL_Opcion1[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IOpcion/createNewOpcionInDB", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void createNewOpcionInDB([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] SQL_Opcion1 op, out int createNewOpcionInDBResult, [System.Xml.Serialization.XmlIgnoreAttribute()] out bool createNewOpcionInDBResultSpecified) {
            object[] results = this.Invoke("createNewOpcionInDB", new object[] {
                        op});
            createNewOpcionInDBResult = ((int)(results[0]));
            createNewOpcionInDBResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegincreateNewOpcionInDB(SQL_Opcion1 op, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("createNewOpcionInDB", new object[] {
                        op}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndcreateNewOpcionInDB(System.IAsyncResult asyncResult, out int createNewOpcionInDBResult, out bool createNewOpcionInDBResultSpecified) {
            object[] results = this.EndInvoke(asyncResult);
            createNewOpcionInDBResult = ((int)(results[0]));
            createNewOpcionInDBResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IOpcion/updateOpcionInDB", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void updateOpcionInDB([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] SQL_Opcion1 op) {
            this.Invoke("updateOpcionInDB", new object[] {
                        op});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginupdateOpcionInDB(SQL_Opcion1 op, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("updateOpcionInDB", new object[] {
                        op}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndupdateOpcionInDB(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IOpcion/deleteOpcionInDB", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void deleteOpcionInDB([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] SQL_Opcion1 op) {
            this.Invoke("deleteOpcionInDB", new object[] {
                        op});
        }
        
        /// <remarks/>
        public System.IAsyncResult BegindeleteOpcionInDB(SQL_Opcion1 op, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("deleteOpcionInDB", new object[] {
                        op}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EnddeleteOpcionInDB(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/SQL_ClassLibrary")]
    public partial class SQL_Atributo {
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string atr_drescription;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string atr_group;
        
        /// <comentarios/>
        public int atr_id;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool atr_idSpecified;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string atr_name;
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="SQL_Opcion", Namespace="http://schemas.datacontract.org/2004/07/SQL_ClassLibrary")]
    public partial class SQL_Opcion1 {
        
        /// <comentarios/>
        public int atr_group;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool atr_groupSpecified;
        
        /// <comentarios/>
        public int atr_id;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool atr_idSpecified;
        
        /// <comentarios/>
        public int opc_id;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool opc_idSpecified;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string opc_value;
    }
}
