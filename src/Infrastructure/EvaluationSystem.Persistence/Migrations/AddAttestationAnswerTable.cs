using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202112071116)]
    public class AddAttestationAnswerTable : Migration
    {
        public override void Down()
        {
            Delete.Table("AttestationAnswer");
        }

        public override void Up()
        {
            Create.Table("AttestationAnswer")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("IdAttestation").AsInt32().ForeignKey("Attestation", "Id").NotNullable()
              .WithColumn("IdUserParticipant").AsInt32().ForeignKey("User", "Id").NotNullable()
              .WithColumn("IdModule").AsInt32().ForeignKey("ModuleTemplate", "Id").NotNullable()
              .WithColumn("IdQuestion").AsInt32().ForeignKey("QuestionTemplate", "Id").NotNullable()
              .WithColumn("IdAnswer").AsInt32().Nullable()
              .WithColumn("TextAnswer").AsString(512).Nullable();
        }
    }
}
