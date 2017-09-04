namespace Carsales.Common.Exception
{
    public class CarsalesException: System.Exception
    {
        public CarsalesException(string message):base(message)
        {
            
        }

        public CarsalesException(string message, System.Exception exception)
            : base(message, exception)
        {
            
        }

        public CarsalesException() : base()
        {
            
        }
    }
}
