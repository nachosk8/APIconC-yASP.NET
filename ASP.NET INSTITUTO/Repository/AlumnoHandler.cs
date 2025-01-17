using ASP.NET_INSTITUTO.Model;
using System.Data;
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
                                conocerAlumno.id = Convert.ToInt32(reader["id_alumno"]);

                                alumnado.Add(conocerAlumno);
                            }
                                
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return alumnado;
        }

        public static bool DeleteAlumnos(int id)
        {

            bool resultado = false;       
            using (SqlConnection sqlConnection = new SqlConnection(ConectarBDD))
            {
                string queryDelete = "Delete from alumnos where id_alumno = @id";
                SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.Int);
                sqlParameter.Value = id;
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0) { 
                        resultado = true;
                        //si se borra algo, devuelve true, ya que la cantidad de filas borradas es > a 0
                    
                    }
                    

         
                    
                }

                sqlConnection.Close();
            }
            return resultado;
        }

        public static bool InsertAlumnos(Alumnos alumno)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConectarBDD)) {
                string queryInstert = "Insert into [instituto].[dbo].[alumnos]" +
                    " (nombre, apellido, dni, nacimiento) values (@nombreParameter, " +
                    " @apellidoParameter, @dniParameter, @nacimientoParameter );";
                SqlParameter nombreParameter = new SqlParameter("nombreParameter", SqlDbType.VarChar) { Value = alumno.nombre};
                SqlParameter apellidoParameter = new SqlParameter("apellidoParameter", SqlDbType.VarChar) { Value = alumno.apellido };
                SqlParameter dniParameter = new SqlParameter("dniParameter", SqlDbType.Int) { Value = alumno.dni };
                SqlParameter nacimientoParameter = new SqlParameter("nacimientoParameter", SqlDbType.DateTime) { Value = alumno.nacimiento };

                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryInstert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParameter);
                    sqlCommand.Parameters.Add(apellidoParameter);
                    sqlCommand.Parameters.Add(dniParameter);
                    sqlCommand.Parameters.Add(nacimientoParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0) { 
                        resultado = true;   
                    }

                }

                    sqlConnection.Close();
            }
            return resultado;
        }

        public static bool editAlumno(Alumnos alumno)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConectarBDD))
            {
                
                string queryEdit = "update [instituto].[dbo].[alumnos] set nombre = @nombreParameter , " +
                    "apellido = @apellidoParameter , dni = @dniParameter , nacimiento = @nacimientoParameter" +
                    " where id_alumno = @idParameter; ";
                SqlParameter nombreParameter = new SqlParameter("nombreParameter", SqlDbType.VarChar) { Value = alumno.nombre };
                SqlParameter apellidoParameter = new SqlParameter("apellidoParameter", SqlDbType.VarChar) { Value = alumno.apellido };
                SqlParameter dniParameter = new SqlParameter("dniParameter", SqlDbType.Int) { Value = alumno.dni };
                SqlParameter idParameter = new SqlParameter("idParameter", SqlDbType.Int) { Value = alumno.id };
                SqlParameter nacimientoParameter = new SqlParameter("nacimientoParameter", SqlDbType.DateTime) { Value = alumno.nacimiento };
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryEdit, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParameter);
                    sqlCommand.Parameters.Add(apellidoParameter);
                    sqlCommand.Parameters.Add(dniParameter);
                    sqlCommand.Parameters.Add(nacimientoParameter);
                    sqlCommand.Parameters.Add(idParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }

                }
                sqlConnection.Close();
            }
            return resultado;
        }

    }


}
