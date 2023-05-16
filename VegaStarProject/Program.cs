using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using VegaStarProject;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

Action<NpgsqlDbContextOptionsBuilder> npgsqlOptionsAction;
builder.Services.AddDbContext<WorkContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";

    npgsqlOptionsAction = cfg =>
    {
        cfg.MigrationsAssembly("VegaStarProject");
        cfg.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        cfg.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    };
    options.UseNpgsql(connectionString, npgsqlOptionsAction);
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WorkContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
