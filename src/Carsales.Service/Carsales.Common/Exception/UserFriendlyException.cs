namespace Carsales.Common.Exception
{
    public class UserFriendlyException : System.Exception
    {
        public string Details { get; private set; }
        /// <summary>An arbitrary error code.</summary>
        public int Code { get; set; }

        public UserFriendlyException(string message):base(message)
        {
            
        }

        public UserFriendlyException(string message, System.Exception exception)
            : base(message, exception)
        {
            
        }

        public UserFriendlyException(string message, string details, System.Exception exception)
            : base(message, exception)
        {
            Details = details;
        }

        public UserFriendlyException(string message, string details, int code, System.Exception exception)
            : base(message, exception)
        {
            Details = details;
            Code = code;
        }

        public UserFriendlyException() : base()
        {
            
        }
    }
}
