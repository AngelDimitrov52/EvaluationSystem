using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202111191117)]
    public class AddModuleQuestionTable : Migration
    {
        public override void Down()
        {
            Delete.Table("ModuleQuestion");
        }

        public override void Up()
        {
            Create.Table("ModuleQuestion")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("IdModule").AsInt64().ForeignKey("ModuleTemplate", "Id").NotNullable()
               .WithColumn("IdQuestion").AsInt64().ForeignKey("QuestionTemplate", "Id").NotNullable()
               .WithColumn("Position").AsInt64().NotNullable();
        }
    }
}
