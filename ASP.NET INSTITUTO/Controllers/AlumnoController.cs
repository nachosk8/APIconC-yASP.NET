using ASP.NET_INSTITUTO.Controllers.DTOS;
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
        public bool DeleteAlumnos([FromBody /*esto quiere decir que se borrará lo que se escriba en el body del postman*/] int id) {
            try {
                return AlumnoHandler.DeleteAlumnos(id);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        [HttpPut]

        public bool editAlumno([FromBody] PutAlumno alumno)
        {
            try
            {
                return AlumnoHandler.editAlumno(new Alumnos
                {
                    nombre = alumno.nombre,
                    apellido = alumno.apellido,
                    dni = alumno.dni,
                    nacimiento = alumno.nacimiento,
                    id = alumno.id

                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPost]

        public bool CreateAlumno([FromBody] PostAlumno alumno)
        {
            try {
                return AlumnoHandler.InsertAlumnos(new Alumnos
                {
                    nombre = alumno.nombre,
                    apellido = alumno.apellido,
                    dni = alumno.dni,
                    nacimiento = alumno.nacimiento

                });
            }
            catch (Exception ex) { 
            Console.WriteLine(ex.Message);
            return false ;
            }

        }

        
    }
}
