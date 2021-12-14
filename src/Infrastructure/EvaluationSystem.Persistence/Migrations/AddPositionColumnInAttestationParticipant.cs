using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202112131450)]
    public class AddPositionColumnInAttestationParticipant : Migration
    {
        public override void Down()
        {
            Delete.Column("Position").FromTable("AttestationParticipant");
        }

        public override void Up()
        {
            Alter.Table("AttestationParticipant")
                .AddColumn("Position").AsString(32).Nullable();
        }
    }
}
