using Base;
using BaseServer;
using ComplainsServer;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<MigrationsDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection")));
//builder.Services.AddDbContext<MigrationsDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ProductionConnection")));
else
    builder.Services.AddDbContext<MigrationsDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ProductionConnection")));

builder.Services.AddTransient<IComplainService, ComplainService>();
builder.Services.AddTransient<IAttachmentService, AttachmentService>();
builder.Services.AddTransient<IComplainStatusService, ComplainStatusService>();
builder.Services.AddTransient<IComplainTypeService, ComplainTypeService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IMilitaryRankService, MilitaryRankService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();


//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAllOrigins");
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
});
app.MapControllers();

app.Run();
