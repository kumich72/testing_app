using System.Data.Entity;

namespace testing.Models
{
    public class Role : DbContext
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}