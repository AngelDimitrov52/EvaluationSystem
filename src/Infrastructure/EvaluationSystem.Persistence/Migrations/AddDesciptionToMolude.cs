using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202201071306)]
    public class AddDesciptionToMolude : Migration
    {
        public override void Down()
        {
            Delete.Column("Description").FromTable("AttestationModule");
            Delete.Column("Description").FromTable("ModuleTemplate");
        }

        public override void Up()
        {
            Alter.Table("AttestationModule")
                .AddColumn("Description").AsString(1024).Nullable();
            Alter.Table("ModuleTemplate")
               .AddColumn("Description").AsString(1024).Nullable();
        }
    }
}
