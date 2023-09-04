using ArmazemDoMago.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ArmazemDoMago {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Configura��o do aplicativo Web.

            // Configura��o do servi�o de banco de dados usando Entity Framework Core.
            builder.Services.AddDbContext<ItemContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("ItemContext")));

            // Configura��o dos servi�os da API.
            builder.Services.AddControllers();

            // Configura��o do Swagger
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c => {
                // Configura��o de defini��o de seguran�a Bearer para Swagger.
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Configura��o de requisito de seguran�a Bearer para Swagger.
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            // Configura��o da chave secreta usada para autentica��o JWT.
            var key = Encoding.ASCII.GetBytes(Key.Secret);

            // Configura��o de autentica��o JWT.
            builder.Services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            });

            var app = builder.Build();

            // Configura��o do pipeline de solicita��es HTTP.

            if (app.Environment.IsDevelopment()) {
                // Habilita o Swagger e a interface do Swagger no ambiente de desenvolvimento.
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
