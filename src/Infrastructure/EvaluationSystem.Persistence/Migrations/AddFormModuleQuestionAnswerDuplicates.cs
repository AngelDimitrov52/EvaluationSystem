using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202112151647)]
   public class AddFormModuleQuestionAnswerDuplicates : Migration
    {
        public override void Down()
        {
            Delete.Table("UserAnswer");
            Delete.Table("Attestation");
            Delete.Table("AttestationModuleQuestion");
            Delete.Table("AttestationFormModule");
            Delete.Table("AttestationForm");
            Delete.Table("AttestationModule");
            Delete.Table("AttestationAnswer");
            Delete.Table("AttestationQuestion");
        }

        public override void Up()
        {
            Delete.Table("AttestationParticipant");
            Delete.Table("AttestationAnswer");
            Delete.Table("Attestation");

            Create.Table("AttestationQuestion")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Name").AsString(1024).NotNullable()
               .WithColumn("Type").AsInt64().NotNullable()
               .WithColumn("IsReusable").AsBoolean().NotNullable();

            Create.Table("AttestationAnswer")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("IsDefault").AsBoolean().NotNullable()
              .WithColumn("Position").AsInt32().NotNullable()
              .WithColumn("AnswerText").AsString(255).NotNullable()
              .WithColumn("IdQuestion").AsInt32().ForeignKey("AttestationQuestion", "Id").NotNullable();

            Create.Table("AttestationModule")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("Name").AsString(255).NotNullable();

            Create.Table("AttestationForm")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("Name").AsString(255).NotNullable();

            Create.Table("AttestationFormModule")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("IdForm").AsInt32().ForeignKey("AttestationForm", "Id").NotNullable()
               .WithColumn("IdModule").AsInt32().ForeignKey("AttestationModule", "Id").NotNullable()
               .WithColumn("Position").AsInt16().NotNullable();

            Create.Table("AttestationModuleQuestion")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("IdModule").AsInt32().ForeignKey("AttestationModule", "Id").NotNullable()
              .WithColumn("IdQuestion").AsInt32().ForeignKey("AttestationQuestion", "Id").NotNullable()
              .WithColumn("Position").AsInt16().NotNullable();

            Create.Table("Attestation")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("IdAttestationForm").AsInt32().ForeignKey("AttestationForm", "Id").NotNullable()
               .WithColumn("IdUserToEval").AsInt32().ForeignKey("User", "Id").NotNullable()
               .WithColumn("CreateDate").AsDateTime2().NotNullable();

            Create.Table("AttestationParticipant")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("IdAttestation").AsInt32().ForeignKey("Attestation", "Id").NotNullable()
             .WithColumn("IdUserParticipant").AsInt32().ForeignKey("User", "Id").NotNullable()
             .WithColumn("Status").AsString(20).NotNullable()
             .WithColumn("Position").AsString(32).Nullable();

            Create.Table("UserAnswer")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("IdAttestation").AsInt32().ForeignKey("Attestation", "Id").NotNullable()
             .WithColumn("IdUserParticipant").AsInt32().ForeignKey("User", "Id").NotNullable()
             .WithColumn("IdModule").AsInt32().ForeignKey("AttestationModule", "Id").NotNullable()
             .WithColumn("IdQuestion").AsInt32().ForeignKey("AttestationQuestion", "Id").NotNullable()
             .WithColumn("IdAnswer").AsInt32().Nullable()
             .WithColumn("TextAnswer").AsString(512).Nullable();
        }
    }
}
