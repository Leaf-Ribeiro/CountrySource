using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Migration.Schema
{
    [FluentMigrator.Migration(20190228092300)]
    public class CreateTableState : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("State")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Name").AsString(150).NotNullable()
                  .WithColumn("CountryId").AsInt32().NotNullable().ForeignKey("FK_State_Country", "Country", "Id");
        }

        public override void Down()
        {
            Delete.Table("State");
        }
    }
}
