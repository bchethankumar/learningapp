var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Configuration
.AddAzureAppConfiguration(options=> {
    options.Connect("Endpoint=https://applicationconfig1234.azconfig.io;Id=KK/J;Secret=EJ5QEI2kqo945Py18ThZHeTwDZClRJ02UENTpxfYKDbVLYiEbL4JJQQJ99AGACi5YpzSf5FgAAABAZACjXeL");
    options.UseFeatureFlags();
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();



app.Run();
