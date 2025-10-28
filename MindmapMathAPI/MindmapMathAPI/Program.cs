
using Microsoft.EntityFrameworkCore;
using MindmapBO.Data;
using MindmapRepository;
using MindmapRepository.Interfaces;
using MindmapService;
using MindmapService.Interfaces;
using System;

namespace MindmapMathAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // 2 dòng này để Render đọc đúng PORT
            //var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            //builder.WebHost.UseUrls($"http://+:{port}");

            builder.Services.AddDbContext<MindmapMathDbContext>(options =>
            {
                var conn = builder.Configuration.GetConnectionString("Default");
                options.UseMySql(conn, ServerVersion.AutoDetect(conn));
            });

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DI repositories
            builder.Services.AddScoped<IMathRepository, MathRepository>();
            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
            builder.Services.AddScoped<ILessonRepository, LessonRepository>();

            // DI services
            builder.Services.AddScoped<IMathService, MathService>();
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<IChapterService, ChapterService>();
            builder.Services.AddScoped<ILessonService, LessonService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Auto-migrate
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MindmapMathDbContext>();
                db.Database.Migrate();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }
    }
}
