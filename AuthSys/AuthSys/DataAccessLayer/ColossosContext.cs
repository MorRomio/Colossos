using AuthSys.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AuthSys.DataAccessLayer
{
    public class ColossosContext : DbContext
    {
        //Create a DbSet property for each entity set (Database table)
        public DbSet<Card> Cards { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Roles> Roles { get; set; }

        //Specify the connection string
        public ColossosContext() : base("ColosseumContext")
        {

        }

        //Prevent table names from being pluralized (e.i table Card will remain Card, and not Cards)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}