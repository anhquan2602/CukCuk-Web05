using Microsoft.Extensions.FileProviders;
using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Application.Services;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

StaticFileOptions staticFileOptions = new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "UploadFile")),
    RequestPath = "/UploadFile"
};


builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
});



// Add services to the container.
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();

builder.Services.AddScoped<IServiceHobbyRepository, ServiceHobbyRepository>();
builder.Services.AddScoped<IServiceHobbyService, ServiceHobbyService>();

builder.Services.AddScoped<IFoodDetailRepository, FoodDetailRepository>();
builder.Services.AddScoped<IFoodDetailService, FoodDetailService>();

builder.Services.AddScoped<IFoodUnitRepository, FoodUnitRepository>();
builder.Services.AddScoped<IFoodUnitService, FoodUnitService>();

builder.Services.AddScoped<ICookRoomRepository, CookRoomRepository>();
builder.Services.AddScoped<ICookRoomService, CookRoomService>();

builder.Services.AddScoped<IMenuGroupRepository, MenuGroupRepository>();
builder.Services.AddScoped<IMenuGroupService, MenuGroupService>();

builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Không bị định dạng json
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.PropertyNamingPolicy = null);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseStaticFiles(staticFileOptions);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
