using System;
using System.Collections.Generic;
using System.Data.Entity;
using testing.Models;

namespace testing.Utils
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DbConnection")
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Question> Question  { get; set; }
        public DbSet<Answer> Answers     { get; set; }

        public System.Data.Entity.DbSet<testing.Models.Result> Results { get; set; }
    }
}