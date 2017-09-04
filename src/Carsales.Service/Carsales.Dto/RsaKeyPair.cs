namespace Carsales.Dto
{
    public class RsaKeyPair
    {
        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }

        public RsaKeyPair(string publicKey, string privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
    }
}
