using System.Runtime.Serialization;

namespace Carsales.Common.DataContracts
{
    [DataContract]
    public class TokenError
    {
        [DataMember]
        public string Error { get; set; }

        [DataMember]
        public TokenStatus ErrorDescription { get; set; }

        [DataMember]
        public string ErrorUri { get; set; }
    }
}
