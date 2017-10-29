using Microsoft.AspNet.Identity.EntityFramework;

namespace prypo3.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }
        public string Description { get; set; }
    }
}