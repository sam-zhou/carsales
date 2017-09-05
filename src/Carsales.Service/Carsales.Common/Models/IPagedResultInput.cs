namespace Carsales.Common.Models
{
    public interface IPagedResultInput: IOrderedResultInput
    {
        int Take { get; set; }

        int Skip { get; set; }
    }
}
