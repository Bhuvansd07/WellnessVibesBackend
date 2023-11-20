using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Models.DailyActivities;
using WebApplication1.Models.HealthAssess;
using WebApplication1.Models.Reviews;
using WebApplication1.Models.WorkoutRoutines;
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
