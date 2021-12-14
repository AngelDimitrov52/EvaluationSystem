using FluentMigrator;

namespace EvaluationSystem.Persistence.Migrations
{
    [Migration(202112131609)]
   public class AddIdentityToEmailInUserTable : Migration
    {
        public override void Down()
        {
            Delete.Column("[Email]").FromTable("[User]");
        }

        public override void Up()
        {
            Delete.Column("[Email]").FromTable("[User]");

            Alter.Table("[User]")
               .AddColumn("[Email]").AsString(200).NotNullable().Unique();
        }
    }
}
