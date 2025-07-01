using Modelo;
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

static void FillProperty()
{
        string[] categorias = { "Apartment", "House", "Farm", "Commercial Room"};

        for (int i = 1; i <= 5; i++)
        {
            Property property = new()
            {
                Id = i,
                Category = categorias[(i - 1) % categorias.Length],
                Value = 200000.00f + (i * 10000),
                Description = $"Imóvel número {i} com características únicas.",
                CurrentOwner = $"Proprietário {i}",
                BusinessType = i % 2 == 0 ? "Sale" : "Rent",
                Address = $"{i} Main St, Springfield, USA",
                SquareMeter = 1500.0f + (i * 100)
            };

            PropertyData.Properties.Add(property);
        }
}

FillProperty();


app.Run();
