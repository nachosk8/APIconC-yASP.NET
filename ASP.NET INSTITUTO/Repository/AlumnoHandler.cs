using ASP.NET_INSTITUTO.Model;
using System.Data.SqlClient;

namespace ASP.NET_INSTITUTO.Repository
{
    public class AlumnoHandler
    {
        //las clases van a ser estáticas, para poder utilizar los métodos sin ningun tipo de problema
        public const string ConectarBDD = "Server=DESKTOP-OOTIKMN\\SQLEXPRESS;Database=instituto;Trusted_Connection=True;TrustServerCertificate=True;";

        public static List<Alumnos> GetAlumnos()
        {
            List<Alumnos> alumnado = new List<Alumnos>();

            using (SqlConnection sqlConnection = new SqlConnection(ConectarBDD))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Select * from alumnos", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                        //nos aseguramos que hayan filas que leer
                        if (reader.HasRows) {
                            while (reader.Read())
                            {
                                Alumnos conocerAlumno = new Alumnos();
                                conocerAlumno.nombre = reader["nombre"].ToString();
                                conocerAlumno.apellido = reader["apellido"].ToString();
                                conocerAlumno.dni = Convert.ToInt32(reader["dni"]);
                                conocerAlumno.nacimiento = Convert.ToDateTime(reader["nacimiento"]);

                                alumnado.Add(conocerAlumno);
                            }
                                
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return alumnado;
        }
    }
}
