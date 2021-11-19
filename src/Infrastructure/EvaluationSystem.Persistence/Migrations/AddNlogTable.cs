using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202111180955)]
    public class AddNlogTable : Migration
    {
        public override void Down()
        {
            Delete.Table("NlogsErrors");
        }

        public override void Up()
        {
            Create.Table("NlogsErrors")
               .WithColumn("Date").AsDateTime().NotNullable()
               .WithColumn("Level").AsInt32().Nullable()
               .WithColumn("[Message]").AsString(1024).Nullable();
        }
    }
}
