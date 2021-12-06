using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202113021013)]
    public class AddDateOfCreationInQuestionTemplate : Migration
    {
        public override void Down()
        {
            Delete.Column("DateOfCreation").FromTable("QuestionTemplate");
        }

        public override void Up()
        {
            Alter.Table("QuestionTemplate")
                .AddColumn("DateOfCreation").AsDateTime2().Nullable();
        }
    }
}
