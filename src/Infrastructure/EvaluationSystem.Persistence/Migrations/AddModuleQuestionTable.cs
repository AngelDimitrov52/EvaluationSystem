using FluentMigrator;

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
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("IdModule").AsInt32().ForeignKey("ModuleTemplate", "Id").NotNullable()
               .WithColumn("IdQuestion").AsInt32().ForeignKey("QuestionTemplate", "Id").NotNullable()
               .WithColumn("Position").AsInt16().NotNullable();
        }
    }
}
