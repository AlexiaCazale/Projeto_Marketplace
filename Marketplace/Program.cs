using MediatR;
using Marketplace.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using SwaggerThemes;
using Marketplace.Domain.Commands;

namespace Marketplace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddServices();
            builder.Services.AddRepositories();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ContatoCreateCommand).Assembly); // Commands
                //cfg.RegisterServicesFromAssembly(typeof(ContatoCreateCommandHandler).Assembly); // Handlers
            });
                var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(Theme.Dracula);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
