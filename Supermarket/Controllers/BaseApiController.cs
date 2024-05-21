using Microsoft.AspNetCore.Mvc;

namespace Supermarket.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
