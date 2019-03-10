using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Migration.Schema
{
    [FluentMigrator.Migration(20190208121600)]
    public class AddUniqueConstraintOnCountryName : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.UniqueConstraint("UQ_Country_Name").OnTable("Country").Column("Name");
        }

        public override void Down()
        {
            Delete.UniqueConstraint("UQ_Country_Name").FromTable("Country");
        }

    }
}
