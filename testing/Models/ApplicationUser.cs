using Microsoft.AspNet.Identity.EntityFramework;

public class ApplicationUser : IdentityUser
{
    public string LastName { get; set; }
    public string FirsttName { get; set; }
    public string MiddleName { get; set; }
    public ApplicationUser()
    {
    }
}
