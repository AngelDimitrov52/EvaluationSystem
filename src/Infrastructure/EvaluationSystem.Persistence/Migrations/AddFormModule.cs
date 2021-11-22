using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202111220924)]
    public class AddFormModule : Migration
    {
        public override void Down()
        {
            Delete.Table("FormModule");
        }

        public override void Up()
        {
            Create.Table("FormModule")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("IdForm").AsInt64().ForeignKey("FormTemplate", "Id").NotNullable()
               .WithColumn("IdModule").AsInt64().ForeignKey("ModuleTemplate", "Id").NotNullable()
               .WithColumn("Position").AsInt64().NotNullable();
        }
    }
}
