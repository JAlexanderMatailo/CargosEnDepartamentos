using CargosEnDepartamentos.Service;
using CargosEnDepartamentos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CargosEnDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDepController : Controller
    {
        private readonly ICargoDep _cargoDepService;
        public CargoDepController(ICargoDep cargoDepService)
        {
            _cargoDepService = cargoDepService;
        }

        [HttpPost("")]
        public IActionResult RegistrarDepartamento(DepartamentosVM departamentosVM)
        {
            var result = _cargoDepService.registrarDepartamentos(departamentosVM);
            return new JsonResult(result);
        }

    }
}
