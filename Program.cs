using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Text;
using WebApplication1.Models.DailyActivities;
using WebApplication1.Models.HealthAssess;
using WebApplication1.Models.Reviews;
using WebApplication1.Models.WorkoutRoutines;
using WebApplication1.Services.AuthService;
using WebApplication1.Services.DailyActivity;
using WebApplication1.Services.HealthAssess;
using WebApplication1.Services.Review;
using WebApplication1.Services.WorkoutRoutine;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<HealthSettings>(builder
    .Configuration.GetSection(nameof(HealthSettings)));

builder.Services.AddSingleton<IHealthSettings>(sp=>sp.GetRequiredService<IOptions<HealthSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("HealthSettings:ConnectionString")));

builder.Services.AddScoped<IHealthService, HealthService>();

builder.Services.Configure<Activities>(builder
    .Configuration.GetSection(nameof(Activities)));

builder.Services.AddSingleton<IActivities>(sp => sp.GetRequiredService<IOptions<Activities>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("Activities:ConnectionString")));

builder.Services.AddScoped<IActivityService, ActivityService>();

builder.Services.AddScoped<AuthService>();

builder.Services.Configure<FeedbackSettings>(builder
    .Configuration.GetSection(nameof(FeedbackSettings)));

builder.Services.AddSingleton<IFeedbackSettings>(sp => sp.GetRequiredService<IOptions<FeedbackSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("FeedbackSettings:ConnectionString")));

builder.Services.AddScoped<IFeedbackServicee, FeedbackService>();

builder.Services.Configure<WorkoutSettings>(builder
    .Configuration.GetSection(nameof(WorkoutSettings)));

builder.Services.AddSingleton<IWorkoutSettings>(sp => sp.GetRequiredService<IOptions<WorkoutSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("WorkoutSettings:ConnectionString")));

builder.Services.AddScoped<IWorkoutService, WorkoutService>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt => { 
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"])),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"]
    };
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

builder.Services.AddMvcCore();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWT Auth Sample",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer jhfdkj.jkdsakjdsa.jkdsajk\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
