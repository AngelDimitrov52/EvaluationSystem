using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202201101148)]
    public class AddFomrIdColumnInAttestationParticipantAndTextAnswerInQuestions : Migration
    {
        public override void Down()
        {
            Delete.Column("AttestationFormId").FromTable("AttestationParticipant");
            Delete.Column("QuestionTemplate").FromTable("AnswerText");
            Delete.Column("AttestationQuestion").FromTable("AnswerText");
        }

        public override void Up()
        {
            Alter.Table("AttestationParticipant")
                .AddColumn("AttestationFormId").AsInt32().ForeignKey("AttestationForm", "Id").NotNullable();
            Alter.Table("QuestionTemplate")
               .AddColumn("AnswerText").AsString(512).Nullable();
            Alter.Table("AttestationQuestion")
              .AddColumn("AnswerText").AsString(512).Nullable();
        }
    }
}
