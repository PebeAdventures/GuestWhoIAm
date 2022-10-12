using GuestWhoIAm;
using GuestWhoIAm.Services;
using GuestWhoIAm.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEntryService, EntryService>();
builder.Services.AddDbContext<DbGuestContext>(builder =>
{
    builder.UseSqlServer("Data Source=guessdb.database.windows.net,1433;Initial Catalog=guessdbserver2;User ID=pebe@piotrbujakhotmail.onmicrosoft.com;Password=00Kurwamac11!");
    // builder.UseSqlServer(@"Data Source=guessdb.database.windows.net;Initial Catalog=guessdbserver2;Persist Security Info=False;User ID=pebe@piotrbujakhotmail.onmicrosoft.com;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=""Active Directory Interactive""");
});

//builder.Services.AddDbContext<DbGuestContext>(builder =>
//{
//    builder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=GuestWhoImBase;Integrated Security=True");
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Entry}/{action=GuessGame}/{id?}");

app.Run();
