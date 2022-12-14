using jcGS.REST.Objects;
using jcGS.REST.Services;

namespace jcGS.REST
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var graphDbConnection = builder.Configuration.GetSection(nameof(DbConfig)).Get<DbConfig>();

            builder.Services.AddSingleton(new Neo4JService(graphDbConnection));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}