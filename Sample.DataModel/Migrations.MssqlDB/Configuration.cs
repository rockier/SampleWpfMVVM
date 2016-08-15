﻿using System.Data.Entity.Migrations;

namespace Sample.DataModel.Migrations.MssqlDB
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataModel.MssqlDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations.MssqlDB";
        }

        protected override void Seed(MssqlDataContext context)
        {
            base.Seed(context);

            if (!context.Customers.Any())
            {
                var customer = new List<Customer>
                {
                    new Customer()
                    {
                        FristName = "Rockie",
                        MiddleName = "W",
                        LastName = "Roper",
                        Address = "123 Main Street",
                        City = "Las Vegas",
                        State = "NV",
                        PostalCode = "89123"
                    }
                };

                customer.ForEach(x => context.Customers.Add(x));
                context.SaveChanges();
            }
        }
    }
}
