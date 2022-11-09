using Microsoft.EntityFrameworkCore;
using Projeto_CRUD.Data;
using Projeto_CRUD.Interfaces.Repositories;
using Projeto_CRUD.Interfaces.Services;
using Projeto_CRUD.Repositories;
using Projeto_CRUD.Services;

var rotasPermitidas = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: rotasPermitidas,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                             "https://localhost:4200"               );
                      });
});


//Add DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add Services

builder.Services.AddScoped<IProdutoService, ProdutoService>();

// Add Repos

builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();


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

app.UseCors(rotasPermitidas);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
