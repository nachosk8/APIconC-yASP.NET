using ASP.NET_INSTITUTO.Model;
using ASP.NET_INSTITUTO.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_INSTITUTO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlumnoController : ControllerBase
    {
        [HttpGet(Name = "GetAlumnos")] //avisamos al controller que el método es un get, que traemos cosas
        public List<Alumnos> GetAlumnos()
        {
            return AlumnoHandler.GetAlumnos();  // AlumnoHandler la hice clase estática justamente para poder llamarla ahora
        }

        [HttpDelete]
        public void DeleteAlumnos([FromBody /*esto quiere decir que se borrará lo que se escriba en el body del postman*/] int id) { 
        }

        
    }
}
