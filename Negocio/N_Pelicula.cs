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

            //Otra validación porque si
            ValidaLongitudNombre(pelicula.Nombre);

            //Antes de agregar, debemos validar si ya existe la pelicula
            ValidaPeliculaRepetida(pelicula.Nombre);

            datos.Agregar(pelicula);
        }

        public void ValidaPeliculaRepetida(string nombre) //Se abstrae en un nuevo metodo la validación
        {
            D_Pelicula datos = new D_Pelicula();
            E_Pelicula peliculaRepetida = datos.BuscarPorNombre(nombre);
            if (peliculaRepetida != null)
            {
                //Recordar que todo lo que esté despues de una excepción se ignora, si llegamos aqui, no se ejecuta el resto del codigo del metodo invocador
                throw new Exception($"La pelicula {nombre} ya existe con el ID {peliculaRepetida.IdPelicula}");
            }
        }

        public void ValidaLongitudNombre(string nombre)
        {
            if (nombre.Count() < 2)
            {
                throw new Exception("El nombre de una pelicula no puede ser menor a 2 caracteres.");
            }
        }

        public E_Pelicula ObtenerPorID(int id)
        {
            //Objeto capa datos
            D_Pelicula datos = new D_Pelicula();

            //Objeto pelicula, le pasamos el objeto de la capa de datos con el metodo ObtenerPorID
            E_Pelicula pelicula = datos.ObtenerPorID(id);

            return pelicula;
        }

        public void Modificar(E_Pelicula pelicula)
        {
            //Crear un objeto de la capa de datos
            D_Pelicula datos = new D_Pelicula();

            //Le pasamos el metodo Modificar
            datos.Modificar(pelicula);
        }

        public List<E_Pelicula> Buscar(string texto)
        {
            D_Pelicula lista = new D_Pelicula();
            List<E_Pelicula> peliculas = lista.Buscar(texto);
            return peliculas;
        }

        public void Eliminar(int id)
        {
            //Crear un objeto de la capa de datos
            D_Pelicula datos = new D_Pelicula();

            //Le pasamos el metodo Modificar
            datos.Eliminar(id);
        }
    }
}
