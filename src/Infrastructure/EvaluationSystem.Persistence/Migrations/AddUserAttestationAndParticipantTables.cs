using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202112021601)]
    public class AddUserAttestationAndParticipantTables : Migration
    {
        public override void Down()
        {
            Delete.Table("AttestationParticipant");
            Delete.Table("Attestation");
            Delete.Table("User");
        }

        public override void Up()
        {
            Create.Table("User")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Email").AsString(200).NotNullable()
               .WithColumn("Name").AsString(200).NotNullable();

            Create.Table("Attestation")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("IdFormTemplate").AsInt32().ForeignKey("FormTemplate", "Id").NotNullable()
               .WithColumn("IdUserToEval").AsInt32().ForeignKey("User", "Id").NotNullable()
               .WithColumn("CreateDate").AsDateTime2().NotNullable();

            Create.Table("AttestationParticipant")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("IdAttestation").AsInt32().ForeignKey("Attestation", "Id").NotNullable()
               .WithColumn("IdUserParticipant").AsInt32().ForeignKey("User", "Id").NotNullable()
               .WithColumn("Status").AsString(20).NotNullable();
        }
    }
}
