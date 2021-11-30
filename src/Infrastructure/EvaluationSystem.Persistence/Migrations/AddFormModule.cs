using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202111220924)]
    public class AddFormModule : Migration
    {
        public override void Down()
        {
            Delete.Table("FormModule");
        }

        public override void Up()
        {
            Create.Table("FormModule")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("IdForm").AsInt32().ForeignKey("FormTemplate", "Id").NotNullable()
               .WithColumn("IdModule").AsInt32().ForeignKey("ModuleTemplate", "Id").NotNullable()
               .WithColumn("Position").AsInt16().NotNullable();
        }
    }
}
