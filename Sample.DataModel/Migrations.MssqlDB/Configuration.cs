using System.Data.Entity.Migrations;

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
        }
    }
}
