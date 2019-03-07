using AuthSys.Models;
using System;
using System.Collections.Generic;

namespace AuthSys.DataAccessLayer
{
    public class MemberInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ColossosContext>
    {
        //This class creates testdata, and recreates in tables if the database scheme changes
        protected override void Seed(ColossosContext context)
        {
            //context.Database.CreateIfNotExists();

            //base.Seed(context);
            var today = DateTime.Today;
            var firstRec = new DateTime(1984, 11, 28).Date;
            var secRec = new DateTime(2004, 05, 28).Date;

            var firstAge = today.Subtract(firstRec).TotalDays;
            var secAge = today.Subtract(secRec).TotalDays;

            var members = new List<Member> 
            {
                new Member { FirstName = "MagiQ", LastName = "Pjat", Address = "Bum street", ZipCode = 8334, City = "Bum city",  DateCreate = firstRec, BirthDate = firstRec, Age = (int) Math.Truncate(firstAge/365) },
                new Member { FirstName = "Elmer", LastName = "Fjot", Address = "Street cred", ZipCode = 4322, City = "Rich city", DateCreate = secRec, BirthDate = secRec, Age = (int) Math.Truncate(secAge/365), },
                new Member { FirstName = "Jin", LastName = "Kazama", Address = "Unknown", ZipCode = 3214, City = "Take city", DateCreate = secRec, BirthDate = secRec, Age = (int) Math.Truncate(secAge/365)+17, }
            };
 
            members.ForEach(s => context.Members.Add(s));
            context.SaveChanges();

            var roles = new List<Roles>
            {
                new Roles {RoleID = 1, RoleName = "Normal user", RoleDescription = "Can do little" },
                new Roles {RoleID = 2, RoleName = "Admin", RoleDescription = "Can do more than normal user" },
                new Roles {RoleID = 3, RoleName = "Super Admin", RoleDescription = "Can do it all" }
            };

            roles.ForEach(x => context.Roles.Add(x));
            context.SaveChanges();
        }
    }
}