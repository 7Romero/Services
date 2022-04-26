using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Services.API.Controllers;

[Authorize]
[ApiController]
public class AppBaseController : Controller
{

}
