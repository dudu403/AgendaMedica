using EAgendaMedica.Aplicacao.ModuloAtividade;
using EAgendaMedica.WebApi.Config;
using EAgendaMedica.WebApi.Config.AutoMapperProfiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using AgendaMedica.Aplicacao.ModuloMedico;
using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Infra.Orm.Compartilhado;
using AgendaMedica.Infra.Orm.ModuloAtividade;
using AgendaMedica.Infra.Orm.ModuloMedico;

namespace EAgendaMedica.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.Configure<ApiBehaviorOptions>(config => {
                config.SuppressModelStateInvalidFilter = false;
            });

            var connectionString = builder.Configuration.GetConnectionString("SqlServer");

            builder.Services.AddDbContext<IContextoPersistencia, AgendaMedicaDbContext>(optionsBuilder => {
                optionsBuilder.UseSqlServer(connectionString);
            });

            builder.Services.AddTransient<IRepositorioMedico, RepositorioMedicoOrm>();
            builder.Services.AddTransient<ServicoMedico>();

            builder.Services.AddTransient<IRepositorioAtividade, RepositorioAtividadeOrm>();
            builder.Services.AddTransient<ServicoAtividade>();

            builder.Services.AddTransient<ConfigurarMedicoMappingAction>();

            builder.Services.AddAutoMapper(config => {
                config.AddProfile<MedicoProfile>();
                config.AddProfile<AtividadeProfile>();
            });

            builder.Services.AddCors(options => {
                options.AddPolicy("desenvolvimento",
                    builder => {
                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                    });
            });

            builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => {
                c.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });
                c.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString(DateTime.Now.ToString("23-11-2023"))

                });

            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AgendaMedicaDbContext>();
                    try
                    {
                        dbContext.InicializarDadosDeTesteAsync().Wait();
                    }
                    catch (Exception ex)
                    {
                        // Substitua isso pelo seu mecanismo de log preferido
                        Console.WriteLine($"Erro ao inicializar dados de teste: {ex.Message}");
                    }
                }
            }

            app.UseMiddleware<ManipuladorExcecoes>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("desenvolvimento");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }

    public class TimeSpanToStringConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeSpan.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}