using Microsoft.AspNetCore.Identity;

namespace Ads.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Ad> Ads { get; set; }
    }
}