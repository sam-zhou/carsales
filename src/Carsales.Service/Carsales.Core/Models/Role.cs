using Microsoft.AspNet.Identity.EntityFramework;

namespace Carsales.Core.Models
{
    public partial class Role : IdentityRole<long, UserRole> { }
}
