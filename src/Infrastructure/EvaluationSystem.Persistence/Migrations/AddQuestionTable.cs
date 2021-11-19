using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202111111310)]
    public class AddQuestionTable : Migration
    {
        public override void Down()
        {
            Delete.Table("QuestionTemplate");
        }

        public override void Up()
        {
            Create.Table("QuestionTemplate")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Name").AsString(1024).NotNullable()
               .WithColumn("Type").AsInt64().NotNullable()
               .WithColumn("IsReusable").AsBoolean().NotNullable();
        }
    }
}
