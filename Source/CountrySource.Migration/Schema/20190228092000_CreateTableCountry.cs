using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Migration.Schema
{
    [FluentMigrator.Migration(20190228092000)]
    public class CreateTableCountry : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Country")
                  .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Name").AsString(150).NotNullable()
                  .WithColumn("Continent").AsString(100).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Country");
        }
    }
}
