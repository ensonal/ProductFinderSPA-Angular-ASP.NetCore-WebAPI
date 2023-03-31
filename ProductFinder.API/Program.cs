using ProductFinder.Business.Abstract;
using ProductFinder.Business.Concrete;
using ProductFinder.DataAccess.Abstract;
using ProductFinder.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<ICategoryRepository, CategoryReposityory>();
builder.Services.AddCors(options => options.AddPolicy(name: "ProductOrigins",
    policy => {
        policy.WithOrigins("http://localhost:50502").AllowAnyMethod().AllowAnyHeader();
    })); 

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseCors("ProductOrigins");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();

