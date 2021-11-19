using EvaluationSystem.Persistence.Migrations;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EvaluationSystem.Persistence.Configurations
{
    public static class ConfigurationMigrations
    {
        public static IServiceCollection AddConfigurationMigrations(this IServiceCollection services)
        {
            services
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSqlServer()
                .WithGlobalConnectionString("DatabaseConnection")
                .ScanIn(typeof(AddAnswerTable).Assembly).For.Migrations());
            return services;
        }
        public static void MigrateUpDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            migrator.MigrateUp();
        }
    }
}
