//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MrTMaker.imagen {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IImagen", Namespace="http://tempuri.org/")]
    public partial class SQL_Imagen : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public SQL_Imagen() {
			this.Url = "http://192.168.43.5:8733/Design_Time_Addresses/HostWCF/ServicioWCF/imagen/imagen";//192.168.1.67
			//this.Url = "http://192.168.1.67:8733/Design_Time_Addresses/HostWCF/ServicioWCF/imagen/imagen";
        }
        
        public SQL_Imagen(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IImagen/getImagenFromIndividio", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/SQL_ClassLibrary")]
        public SQL_Imagen1[] getImagenFromIndividio(int ind_id, [System.Xml.Serialization.XmlIgnoreAttribute()] bool ind_idSpecified) {
            object[] results = this.Invoke("getImagenFromIndividio", new object[] {
                        ind_id,
                        ind_idSpecified});
            return ((SQL_Imagen1[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetImagenFromIndividio(int ind_id, bool ind_idSpecified, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getImagenFromIndividio", new object[] {
                        ind_id,
                        ind_idSpecified}, callback, asyncState);
        }
        
        /// <remarks/>
        public SQL_Imagen1[] EndgetImagenFromIndividio(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((SQL_Imagen1[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IImagen/createNewImageInDB", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void createNewImageInDB([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] SQL_Imagen1 ima, out int createNewImageInDBResult, [System.Xml.Serialization.XmlIgnoreAttribute()] out bool createNewImageInDBResultSpecified) {
            object[] results = this.Invoke("createNewImageInDB", new object[] {
                        ima});
            createNewImageInDBResult = ((int)(results[0]));
            createNewImageInDBResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegincreateNewImageInDB(SQL_Imagen1 ima, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("createNewImageInDB", new object[] {
                        ima}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndcreateNewImageInDB(System.IAsyncResult asyncResult, out int createNewImageInDBResult, out bool createNewImageInDBResultSpecified) {
            object[] results = this.EndInvoke(asyncResult);
            createNewImageInDBResult = ((int)(results[0]));
            createNewImageInDBResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IImagen/updateImagenInDB", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void updateImagenInDB([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] SQL_Imagen1 ima) {
            this.Invoke("updateImagenInDB", new object[] {
                        ima});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginupdateImagenInDB(SQL_Imagen1 ima, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("updateImagenInDB", new object[] {
                        ima}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndupdateImagenInDB(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IImagen/deleteImagenInDB", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void deleteImagenInDB([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] SQL_Imagen1 ima) {
            this.Invoke("deleteImagenInDB", new object[] {
                        ima});
        }
        
        /// <remarks/>
        public System.IAsyncResult BegindeleteImagenInDB(SQL_Imagen1 ima, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("deleteImagenInDB", new object[] {
                        ima}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EnddeleteImagenInDB(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="SQL_Imagen", Namespace="http://schemas.datacontract.org/2004/07/SQL_ClassLibrary")]
    public partial class SQL_Imagen1 {
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", IsNullable=true)]
        public byte[] ima_dat;
        
        /// <comentarios/>
        public int ima_id;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ima_idSpecified;
        
        /// <comentarios/>
        public int ind_id;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ind_idSpecified;
    }
}
