﻿namespace ASP.NET_INSTITUTO.Controllers.DTOS
{
    public class PutAlumno
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public DateTime nacimiento { get; set; }
    }


}