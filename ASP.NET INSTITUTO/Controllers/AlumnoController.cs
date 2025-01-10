using ASP.NET_INSTITUTO.Model;
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
            return new List<Alumnos>();
        }
        
    }
}
