using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202111111305)]
    public class  AddAnswerTable : Migration
    {
        public override void Down()
        {
            Delete.Table("AnswerTemplate");
        }

        public override void Up()
        {
            Create.Table("AnswerTemplate")
               .WithColumn("AnswerId").AsInt64().PrimaryKey().Identity()
               .WithColumn("IsDefault").AsBoolean().NotNullable()
               .WithColumn("Position").AsInt64().NotNullable()
               .WithColumn("AnswerText").AsString(255).NotNullable()
               .WithColumn("IdQuestion").AsInt64().ForeignKey().NotNullable();
        }
    }
}
