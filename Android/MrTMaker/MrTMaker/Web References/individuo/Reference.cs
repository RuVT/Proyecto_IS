//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MrTMaker.individuo {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IIndividuo", Namespace="http://tempuri.org/")]
    public partial class SQL_Individuo : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public SQL_Individuo() {
			this.Url = "http://192.168.43.5:8733/Design_Time_Addresses/HostWCF/ServicioWCF/individuo/individ" +
                "uo";
        }
        
        public SQL_Individuo(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IIndividuo/createNewIndividuoInDB", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void createNewIndividuoInDB([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] SQL_Individuo1 ind, out int createNewIndividuoInDBResult, [System.Xml.Serialization.XmlIgnoreAttribute()] out bool createNewIndividuoInDBResultSpecified) {
            object[] results = this.Invoke("createNewIndividuoInDB", new object[] {
                        ind});
            createNewIndividuoInDBResult = ((int)(results[0]));
            createNewIndividuoInDBResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegincreateNewIndividuoInDB(SQL_Individuo1 ind, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("createNewIndividuoInDB", new object[] {
                        ind}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndcreateNewIndividuoInDB(System.IAsyncResult asyncResult, out int createNewIndividuoInDBResult, out bool createNewIndividuoInDBResultSpecified) {
            object[] results = this.EndInvoke(asyncResult);
            createNewIndividuoInDBResult = ((int)(results[0]));
            createNewIndividuoInDBResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IIndividuo/updateIndividuoInDB", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void updateIndividuoInDB([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] SQL_Individuo1 ind) {
            this.Invoke("updateIndividuoInDB", new object[] {
                        ind});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginupdateIndividuoInDB(SQL_Individuo1 ind, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("updateIndividuoInDB", new object[] {
                        ind}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndupdateIndividuoInDB(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IIndividuo/deleteIndiviuoInDB", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void deleteIndiviuoInDB([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] SQL_Individuo1 ind) {
            this.Invoke("deleteIndiviuoInDB", new object[] {
                        ind});
        }
        
        /// <remarks/>
        public System.IAsyncResult BegindeleteIndiviuoInDB(SQL_Individuo1 ind, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("deleteIndiviuoInDB", new object[] {
                        ind}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EnddeleteIndiviuoInDB(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IIndividuo/searchIndividuoByName", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/SQL_ClassLibrary")]
        public SQL_Individuo1[] searchIndividuoByName([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string _name) {
            object[] results = this.Invoke("searchIndividuoByName", new object[] {
                        _name});
            return ((SQL_Individuo1[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginsearchIndividuoByName(string _name, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("searchIndividuoByName", new object[] {
                        _name}, callback, asyncState);
        }
        
        /// <remarks/>
        public SQL_Individuo1[] EndsearchIndividuoByName(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((SQL_Individuo1[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IIndividuo/getIndividuoFromDBbyID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public SQL_Individuo1 getIndividuoFromDBbyID(int _id, [System.Xml.Serialization.XmlIgnoreAttribute()] bool _idSpecified) {
            object[] results = this.Invoke("getIndividuoFromDBbyID", new object[] {
                        _id,
                        _idSpecified});
            return ((SQL_Individuo1)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetIndividuoFromDBbyID(int _id, bool _idSpecified, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getIndividuoFromDBbyID", new object[] {
                        _id,
                        _idSpecified}, callback, asyncState);
        }
        
        /// <remarks/>
        public SQL_Individuo1 EndgetIndividuoFromDBbyID(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((SQL_Individuo1)(results[0]));
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="SQL_Individuo", Namespace="http://schemas.datacontract.org/2004/07/SQL_ClassLibrary")]
    public partial class SQL_Individuo1 {
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string direction;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string email;
        
        /// <comentarios/>
        public int id;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string last_name1;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string last_name2;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string name;
        
        /// <comentarios/>
        public int telephone;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool telephoneSpecified;
        
        /// <comentarios/>
        public System.DateTime years;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool yearsSpecified;
    }
}
