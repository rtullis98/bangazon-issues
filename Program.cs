using Bangazon;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/products", (BangazonDbContext dbContext) =>
{
    var products = dbContext.Products
        .Join(
            dbContext.ProductCategories,
            product => product.ProductCategoryId,
            category => category.ProductCategoryId,
            (product, category) => new
            {
                ProductId = product.ProductId,
                Title = product.Title,
                Description = product.Description,
                QuantityAvailable = product.QuantityAvailable,
                PricePerUnit = product.PricePerUnit,
                SellerId = product.SellerId,
                Seller = product.Seller.StoreName,
                ProductCategoryId = product.ProductCategoryId,
                ProductCategoryName = category.Name
            })
        .ToList();

    if (products.Count == 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(products);
});


app.MapGet("/api/sellers/{sellerId}/products", (int sellerId, BangazonDbContext dbContext) =>
{
    var products = dbContext.Products
        .Where(p => p.SellerId == sellerId)
        .Join(
            dbContext.ProductCategories,
            product => product.ProductCategoryId,
            category => category.ProductCategoryId,
            (product, category) => new
            {
                ProductId = product.ProductId,
                Title = product.Title,
                Description = product.Description,
                QuantityAvailable = product.QuantityAvailable,
                PricePerUnit = product.PricePerUnit,
                SellerId = product.SellerId,
                Seller = product.Seller.StoreName,
                ProductCategoryId = product.ProductCategoryId,
                ProductCategoryName = category.Name
            })
        .ToList();

    if (products.Count == 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(products);
});





app.Run();