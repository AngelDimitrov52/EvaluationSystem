using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202111190930)]
    public class AddModuleTable : Migration
    {
        public override void Down()
        {
            Delete.Table("ModuleTemplate");
        }

        public override void Up()
        {
            Create.Table("ModuleTemplate")
              .WithColumn("Id").AsInt64().PrimaryKey().Identity()
              .WithColumn("Name").AsString(255).NotNullable();
        }
    }
}
