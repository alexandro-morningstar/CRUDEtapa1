using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Pelicula
    {
        // --------- Propiedades de lectura/escritura ---------
        public int IdPelicula { get; set; } //No es necesario que el nombre de la propiedad sea exactamente igual al nombre de la tabla SQL
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public DateTime FechaEstreno { get; set; }

        // --------- Propiedades de lectura/escritura ---------

        public int getIdPelicula
        {
            get
            {
                return IdPelicula;
            }
        }
        public string getNombre
        {
            get
            {
                return Nombre;
            }
        }
        public string getGenero
        {
            get
            {
                return Genero;
            }
        }
        public DateTime getFechaEstreno
        {
            get
            {
                return FechaEstreno;
            }
        }
    }
}
