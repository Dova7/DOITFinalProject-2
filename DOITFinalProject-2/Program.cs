using Application.Service.Implimentations.Services;
using DOITFinalProject_2.MiddleWare;
using Hangfire;

namespace DOITFinalProject_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.AddDatabaseContext();
            builder.ConfigureJwtOptions();
            builder.AddIdentity();
            builder.AddAuthentication();
            builder.AddHttpContextAccessor();
            builder.AddControllers();
            builder.AddEndpointsApiExplorer();
            builder.AddSwagger();
            builder.AddCors();
            builder.AddScopedServices();
            builder.AddHangfire();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandler>();
            app.UseHttpsRedirection();
            app.UseCors(builder.Configuration.GetValue<string>("Cors:AllowOrigin")!);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHangfireDashboard();
            app.MapControllers();
            app.Run();

            RecurringJob.AddOrUpdate<TopicService>(x => x.DeactivateInactiveTopicsAsync(), Cron.Daily);
        }
    }
}
