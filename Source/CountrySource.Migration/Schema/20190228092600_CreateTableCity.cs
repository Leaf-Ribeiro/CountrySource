using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Migration.Schema
{
    [FluentMigrator.Migration(20190228092600)]
    public class CreateTableCity : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("City")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Name").AsString(150).NotNullable()
                  .WithColumn("StateId").AsInt32().NotNullable().ForeignKey("FK_City_State", "State", "Id");
        }

        public override void Down()
        {
            Delete.Table("City");
        }
    }
}
