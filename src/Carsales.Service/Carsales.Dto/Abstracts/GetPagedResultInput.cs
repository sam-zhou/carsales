using Carsales.Common.Models;

namespace Carsales.Dto.Abstracts
{
    public abstract class GetPagedResultInput: IPagedResultInput
    {
        public int Take { get; set; }

        public int Skip { get; set; }

        public string Sort { get; set; }

        public bool Ascending { get; set; }

        protected GetPagedResultInput()
        {
            Take = 20;
            Skip = 0;
            Sort = "CreatedDateTime";
            Ascending = false;
        }
    }
}
