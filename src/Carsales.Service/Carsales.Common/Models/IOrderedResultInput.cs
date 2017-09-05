namespace Carsales.Common.Models
{
    public interface IOrderedResultInput
    {
        string Sort { get; set; }

        bool Ascending { get; set; }
        
    }
}
