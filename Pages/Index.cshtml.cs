using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace learningapp.Pages;

public class IndexModel : PageModel
{
     public List<Course> Courses=new List<Course>();
    private readonly ILogger<IndexModel> _logger;
    private IConfiguration _configuration;
    public IndexModel(ILogger<IndexModel> logger,IConfiguration configuration)
    {
        _logger = logger;
        _configuration=configuration;
    }

    public async Task<IActionResult> OnGet()
    {

        //string connectionString = _configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")!;
        string functionUrl = "https://azurefunctionchethan.azurewebsites.net/api/getlist";
        using(HttpClient client = new HttpClient())
        {
            HttpResponseMessage response= await client.GetAsync(functionUrl);
            string content = await response.Content.ReadAsStringAsync();
            Courses = JsonConvert.DeserializeObject<List<Course>>(content);
            return Page();
        }
    }
}
