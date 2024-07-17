using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Pelicula
    {
        //Metodo para obtener todas las peliculas
        public List<E_Pelicula> ObtenerTodos()
        {
            //Crear un objeto de la capa de datos
            D_Pelicula datos = new D_Pelicula();

            List<E_Pelicula> lista = datos.ObtenerTodos();

            return lista;
        }

        public void Agregar(E_Pelicula pelicula)
        {
            //Crear un objeto de la capa de datos
            D_Pelicula datos = new D_Pelicula();
            datos.Agregar(pelicula);
        }

        public E_Pelicula ObtenerPorID(int id)
        {
            //Objeto capa datos
            D_Pelicula datos = new D_Pelicula();

            //Objeto pelicula, le pasamos el objeto de la capa de datos con el metodo ObtenerPorID
            E_Pelicula pelicula = datos.ObtenerPorID(id);

            return pelicula;
        }
    }
}
