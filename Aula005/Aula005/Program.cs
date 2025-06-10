using Model;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

FillCustumerData();
FillProductData();

app.Run();

static void FillCustumerData()
{
    for(int i = 1; i <= 10; i++)
    { 
        Customer customer = new() // Ou new Customer()
        {
            Id = i,
            Name = $" Customer {i}",
            HomeAddres = new Addres()
            {
                Id = i,
                Street = "Minha casa",
                neighborhood = "Casita",
                City = "Videira",
                State = "SC",
                Country = "Brasil",
                cep = 078788
            }
        };
        CustomerData.Customers.Add(customer);
    }
}

static void FillProductData()
{
    for (int i = 1; i <= 10; i++)
    {
        Product product = new()
        {
            Id = i,
            Name = $" Product {i}",
            Description = "Produto de teste",
            CurrentPrice = 10.0 * i
        };
        ProductData.Products.Add(product);
    }
}