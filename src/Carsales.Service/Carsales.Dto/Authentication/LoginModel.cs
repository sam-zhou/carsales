namespace Carsales.Dto.Authentication
{
    public class LoginModel
    {
        /// <summary>
        /// Must provide one of [UsernameOrEmailAddress + Password] or [LoginProvider + ProviderKey]
        /// </summary>
        public string UsernameOrEmailAddress { get; set; }

        public string Password { get; set; }


        public bool IsRememberMe { get; set; }

        /// <summary>
        /// Must provide one of [UsernameOrEmailAddress + Password] or [LoginProvider + ProviderKey]
        /// </summary>
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
