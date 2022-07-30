using Microsoft.AspNetCore.Mvc;

namespace StartupBusStickySub.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private static readonly string[] stringVals = new[]
    {
        "Test2", "Test3", "Test4", "Test5"
    };

    private static readonly string[] typeVals = new[]
    {
        "flower", "preroll", "vape", "edible"
    };

    private static readonly string[] strains = new[]
   {
        "hybrid", "sativa", "indica"
    };

    private static readonly string[] Plans = new[]
   {
        "Basic3", "Lux6"
    };

    private readonly ILogger<CustomersController> _logger;

    public CustomersController(ILogger<CustomersController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCustomers")]
    public IEnumerable<Customers> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Customers
        {
            DateOfBirth = DateTime.Now.AddDays(index),
            Over21Plus = 1,
            PreferredProduct = typeVals[Random.Shared.Next(typeVals.Length)],
            PreferredStrains = strains[Random.Shared.Next(strains.Length)],
            FirstName = stringVals[Random.Shared.Next(stringVals.Length)],
            LastName = stringVals[Random.Shared.Next(stringVals.Length)],
            address = stringVals[Random.Shared.Next(stringVals.Length)],
            Plan = Plans[Random.Shared.Next(Plans.Length)]
        })
        .ToArray();
    }
}

