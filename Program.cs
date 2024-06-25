using Catalogo.Data;
using Catalogo.Extentions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddInjectionApi();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AlmacenDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection"));
});

var AllowOrigins = "_allowSpecificOrigins";

builder.Services.AddCors(options =>
{
	options.AddPolicy(
		name: AllowOrigins,
		builder =>
		{
			builder.AllowAnyOrigin();
			builder.AllowAnyMethod();
			builder.AllowAnyHeader();
		}
	);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(AllowOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

// Add the endpoint for the API
app.MapControllers();
app.Run();
