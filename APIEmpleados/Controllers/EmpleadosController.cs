using Microsoft.AspNetCore.Mvc;
using APIEmpleados.Models;

namespace APIEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        [HttpPost("APIEmpleados")]
        public void Crear(Empleado value)
        {
            Empleado.CrearJSON(value);
            return;
        }


        [HttpGet("APIEmpleados")]
        public IActionResult Get(string Id)
        {
            Empleado encontrado = Empleado.ObtenerJSON(Id);

            if (encontrado == null)
            {
                return NotFound(null);
            }

            return Ok(encontrado);
        }
    }
}
