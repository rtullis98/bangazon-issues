using Bangazon;
using Bangazon.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
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


//customer endpoints
app.MapGet("/api/customers", (BangazonDbContext dbContext) =>
{
    var customers = dbContext.Customers.OrderBy(c => c.CustomerId).ToList();
    return Results.Ok(customers);
});

app.MapGet("/api/customers/{id}", (int id, BangazonDbContext dbContext) =>
{
    var customer = dbContext.Customers.Find(id);
    if (customer == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(customer);
});

app.MapPost("/api/customers", (Customer customer, BangazonDbContext dbContext) =>
{
    dbContext.Customers.Add(customer);
    dbContext.SaveChanges();
    return Results.Created($"/api/customers/{customer.CustomerId}", customer);
});


app.MapPut("/api/customers/{id}", (int id, Customer updatedCustomer, BangazonDbContext dbContext) =>
{
    if (id != updatedCustomer.CustomerId)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(updatedCustomer).State = EntityState.Modified;

    try
    {
        dbContext.SaveChanges();
        return Results.NoContent();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!dbContext.Customers.Any(e => e.CustomerId == id))
        {
            return Results.NotFound();
        }

        throw;
    }
});

app.MapDelete("/api/customers/{id}", (int id, BangazonDbContext dbContext) =>
{
    var customer = dbContext.Customers.Find(id);
    if (customer == null)
    {
        return Results.NotFound();
    }

    dbContext.Customers.Remove(customer);
    dbContext.SaveChanges();
    return Results.NoContent();
});

// order endpoints

app.MapGet("/api/orders", (BangazonDbContext dbContext) =>
{
    var orders = dbContext.Orders.ToList();
    return Results.Ok(orders);
});

app.MapGet("api/orders/{id}", (int id, BangazonDbContext dbContext) =>
{
    var order = dbContext.Orders.Find(id);
    if (order == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(order);
});

app.MapGet("/api/orders/{orderId}/products", async (int orderId, BangazonDbContext db) =>
{
    var products = await db.Ordered_Products
        .Where(op => op.OrderId == orderId)
        .Select(op => op.Product)
        .ToListAsync();

    return Results.Ok(products);
});

app.MapPost("/api/orders", (Order order, BangazonDbContext dbContext) =>
{
    dbContext.Orders.Add(order);
    dbContext.SaveChanges();
    return Results.Created($"/api/orders/{order.OrderId}", order);
});

app.MapPut("/api/orders/{id}", (int id, Order updatedOrder, BangazonDbContext dbContext) =>
{
    if (id != updatedOrder.OrderId)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(updatedOrder).State = EntityState.Modified;

    try
    {
        dbContext.SaveChanges();
        return Results.NoContent();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!dbContext.Orders.Any(e => e.OrderId == id))
        {
            return Results.NotFound();
        }

        throw;
    }
});

app.MapDelete("/api/orders/{id}", (int id, BangazonDbContext dbContext) =>
{
    var order = dbContext.Orders.Find(id);
    if (order == null)
    {
        return Results.NotFound();
    }

    dbContext.Orders.Remove(order);
    dbContext.SaveChanges();
    return Results.NoContent();
});

// product endpoints

app.MapGet("/api/products", (BangazonDbContext dbContext) =>
{
    var products = dbContext.Products.ToList();


    return Results.Ok(products);
});


app.MapGet("/api/products/{id}", (int id, BangazonDbContext dbContext) =>
{
    var product = dbContext.Products.Find(id);
    if (product == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(product);
});

app.MapPost("/api/products", (Product product, BangazonDbContext dbContext) =>
{
    dbContext.Products.Add(product);
    dbContext.SaveChanges();
    return Results.Created($"/api/products/{product.ProductId}", product);
});

app.MapPut("/api/products/{id}", (int id, Product updatedProduct, BangazonDbContext dbContext) =>
{
    if (id != updatedProduct.ProductId)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(updatedProduct).State = EntityState.Modified;

    try
    {
        dbContext.SaveChanges();
        return Results.NoContent();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!dbContext.Products.Any(e => e.ProductId == id))
        {
            return Results.NotFound();
        }

        throw;
    }
});

app.MapDelete("/api/products/{id}", (int id, BangazonDbContext dbContext) =>
{
    var product = dbContext.Products.Find(id);
    if (product == null)
    {
        return Results.NotFound();
    }

    dbContext.Products.Remove(product);
    dbContext.SaveChanges();
    return Results.NoContent();
});

// seller endpoints
app.MapGet("/api/sellers", (BangazonDbContext dbContext) =>
{
    var sellers = dbContext.Sellers.ToList();
    return Results.Ok(sellers);
});

app.MapGet("/api/sellers/{id}", (int id, BangazonDbContext dbContext) =>
{
    var seller = dbContext.Sellers.Find(id);
    if (seller == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(seller);
});

app.MapPost("/api/sellers", (Seller seller, BangazonDbContext dbContext) =>
{
    dbContext.Sellers.Add(seller);
    dbContext.SaveChanges();
    return Results.Created($"/api/sellers/{seller.SellerId}", seller);
});

app.MapPut("/api/sellers/{id}", (int id, Seller updatedSeller, BangazonDbContext dbContext) =>
{
    if (id != updatedSeller.SellerId)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(updatedSeller).State = EntityState.Modified;

    try
    {
        dbContext.SaveChanges();
        return Results.NoContent();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!dbContext.Sellers.Any(e => e.SellerId == id))
        {
            return Results.NotFound();
        }

        throw;
    }
});

app.MapDelete("/api/sellers/{id}", (int id, BangazonDbContext dbContext) =>
{
    var seller = dbContext.Sellers.Find(id);
    if (seller == null)
    {
        return Results.NotFound();
    }

    dbContext.Sellers.Remove(seller);
    dbContext.SaveChanges();
    return Results.NoContent();
});


app.Run();