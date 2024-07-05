var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Configuration
.AddAzureAppConfiguration(options=> {
    options.Connect("Endpoint=https://learningappconfig12345.azconfig.io;Id=yP2j;Secret=1VvSNzGslXZkJmh9feJkPzZkE6XlbhDeFGDAIeLdRQ2846loCmVAJQQJ99AGACi5YpzSf5FgAAACAZACvHvb");
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
