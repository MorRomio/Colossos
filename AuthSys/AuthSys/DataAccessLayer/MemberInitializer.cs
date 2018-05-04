﻿using AuthSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthSys.DataAccessLayer
{
    public class MemberInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ColossosContext>
    {
        //This class creates testdata, and recreates in tables if the database scheme changes
        protected override void Seed(ColossosContext context)
        {
            //base.Seed(context);
            var today = DateTime.Today;
            var firstRec = new DateTime(1984, 11, 28).Date;
            var secRec = new DateTime(2004, 05, 28).Date;

            var firstAge = today.Subtract(firstRec).TotalDays;
            var secAge = today.Subtract(secRec).TotalDays;

      /*      var members = new List<Member>
            {
                new Member { FirstName = "MagiQ", LastName = "Pjat", BirthDate = firstRec, CreationDate = DateTime.Now, Age = (int) Math.Truncate(firstAge/365) },
                new Member { FirstName = "Elmer", LastName = "Fjot", BirthDate = secRec, CreationDate = DateTime.Today, Age = (int) Math.Truncate(secAge/365) }
            }; */

            var members = new List<Member> 
            {
                new Member { FirstName = "MagiQ", LastName = "Pjat", DateCreate = firstRec, BirthDate = firstRec, Age = (int) Math.Truncate(firstAge/365) },
                new Member { FirstName = "Elmer", LastName = "Fjot", DateCreate = secRec, BirthDate = secRec, Age = (int) Math.Truncate(secAge/365) }
            };
 
            members.ForEach(s => context.Members.Add(s));
            context.SaveChanges();
        }
    }
}