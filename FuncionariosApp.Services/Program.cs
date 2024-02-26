using FuncionariosApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configura��o para o automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

DependencyInjection.Register(builder.Services);

//pol�tica de permiss�o para acesso � API
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
