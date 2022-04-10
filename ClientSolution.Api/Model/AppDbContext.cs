using ClientSolution.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSolution.Api.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                   new Person { PersonId=1,Name="Sam",LastName= "sullivans",Email= "sullivans@gmail,com",GenderId=1,PrimaryNumber="01125200125",SecondaryNumber="101255225566" });
            modelBuilder.Entity<Person>().HasData(
                  new Person { PersonId = 2, Name = "Peter", LastName = "Jackson", Email = "Jackson@gmail,com", GenderId = 1, PrimaryNumber = "0140225522144", SecondaryNumber = "01325588855" });
            modelBuilder.Entity<Person>().HasData(
                  new Person { PersonId = 3, Name = "Tania", LastName = "Elize", Email = "Elize@gmail,com", GenderId = 2, PrimaryNumber = "01255444555", SecondaryNumber = "012533699555" });
            modelBuilder.Entity<Person>().HasData(
                  new Person { PersonId = 4, Name = "Gordon", LastName = "Prudence", Email = "Prudence@gmail,com", GenderId = 2, PrimaryNumber = "01258554411", SecondaryNumber = "013255899552" });
            modelBuilder.Entity<Person>().HasData(
                  new Person { PersonId = 5, Name = "Brian", LastName = "Greyling", Email = "Greyling@gmail,com", GenderId = 2, PrimaryNumber = "012588745566", SecondaryNumber = "102365889966" });
            modelBuilder.Entity<Person>().HasData(
                  new Person { PersonId = 6, Name = "Shaun", LastName = "Noel", Email = "Noel@gmail,com", GenderId = 1, PrimaryNumber = "102255544555", SecondaryNumber = "012654788999" });


            modelBuilder.Entity<Address>().HasData(
                        new Address {  AddressId=1,AddressTypeId=1,PersonId=1,ProvinceId=1,StreetName= "157 Voortrekker rd",Town= "Germiston" });
            modelBuilder.Entity<Address>().HasData(
                        new Address { AddressId = 2, AddressTypeId = 2, PersonId = 1, ProvinceId = 1, StreetName = "157 Voortrekker rd", Town = "Germiston" });

            modelBuilder.Entity<Address>().HasData(
            new Address { AddressId = 3, AddressTypeId = 1, PersonId = 2, ProvinceId = 1, StreetName = "150 West Street", Town = "Sandton" });
            modelBuilder.Entity<Address>().HasData(
                        new Address { AddressId = 4, AddressTypeId = 2, PersonId = 2, ProvinceId = 1, StreetName = "150 West Street", Town = "Sandton" });


            modelBuilder.Entity<Address>().HasData(
            new Address { AddressId = 5, AddressTypeId = 1, PersonId = 3, ProvinceId = 1, StreetName = "157 Voortrekker rd", Town = "Roodepoort" });
            modelBuilder.Entity<Address>().HasData(
                        new Address { AddressId = 6, AddressTypeId = 2, PersonId = 3, ProvinceId = 1, StreetName = "157 Voortrekker rd", Town = "Roodepoort" });
        }
    }
}
