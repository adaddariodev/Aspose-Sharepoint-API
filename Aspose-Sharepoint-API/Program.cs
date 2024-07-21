using ASA_Sharepoint_Upload_Service;
using Data;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services:

//Database service
builder.Services.AddDbContext<AsaDbContext>();
//File upload and download service
builder.Services.AddScoped<IFileService, FileService>();
//Sharepoint file service
builder.Services.AddScoped<ISharepointUploadService, SharepointUploadService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
