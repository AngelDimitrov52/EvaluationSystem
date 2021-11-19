using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202111191020)]
    public class AddFormTable : Migration
    {
        public override void Down()
        {
            Delete.Table("FormTemplate");
        }

        public override void Up()
        {
            Create.Table("FormTemplate")
              .WithColumn("Id").AsInt64().PrimaryKey().Identity()
              .WithColumn("Name").AsString(255).NotNullable();
        }
    }
}
