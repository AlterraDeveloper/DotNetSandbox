using System.Resources;

namespace DotnetSandbox
{

    public enum NetworkProtocol
    {
        HTTP, HTTPS, SOAP
    }
    
    public class ServiceHelper
    {
        private NetworkProtocol serviceNetworkProtocol;
        private string serviceAddress;
        private string encryptionMethod = null;

        private static ServiceHelper _helper = new ServiceHelper();

        public ServiceHelper WithProtocol(NetworkProtocol protocol)
        {
            _helper.serviceNetworkProtocol = protocol;
            return _helper;
        } 
        
        public ServiceHelper WithBaseAddress(string address)
        {
            _helper.serviceAddress = address;
            return _helper;
        } 
        public ServiceHelper WithEncryption(string encMethod)
        {
            _helper.encryptionMethod = encryptionMethod;
            return _helper;
        }

        public static ServiceHelper Build()
        {
            return _helper;
        }
        
    }
}