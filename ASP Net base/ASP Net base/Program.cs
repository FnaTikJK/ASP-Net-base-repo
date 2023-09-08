using ASP_Net_base.DAL;
using ASP_Net_base.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ������������ DbContext � DI Container
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// ��������� ������ ������������ ��� API
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonConfig.DateOnlyJsonConverter());
});
// ��������� ������� ������� (������ �� ���� ������ DateOnly � DateTime)
builder.Services.AddAutoMapper(typeof(BaseMappingProfile));
// ������������ ������ ����� Extensions
builder.Services.RegisterModules();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
