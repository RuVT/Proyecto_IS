﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClienteWCF.ReferenciaServicioWCF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReferenciaServicioWCF.IServicioWCF")]
    public interface IServicioWCF {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioWCF/DoWork", ReplyAction="http://tempuri.org/IServicioWCF/DoWorkResponse")]
        string DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioWCF/DoWork", ReplyAction="http://tempuri.org/IServicioWCF/DoWorkResponse")]
        System.Threading.Tasks.Task<string> DoWorkAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioWCFChannel : ClienteWCF.ReferenciaServicioWCF.IServicioWCF, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioWCFClient : System.ServiceModel.ClientBase<ClienteWCF.ReferenciaServicioWCF.IServicioWCF>, ClienteWCF.ReferenciaServicioWCF.IServicioWCF {
        
        public ServicioWCFClient() {
        }
        
        public ServicioWCFClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioWCFClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioWCFClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioWCFClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string DoWork() {
            return base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task<string> DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
    }
}
