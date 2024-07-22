using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace WebPeliculasCRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<E_Pelicula> peliculas = new List<E_Pelicula>();

            //Obtenermos la lista de peliculas de la Capa de Negocio
            try
            {
                //Creamos un objeto de la capa de Negocio
                N_Pelicula negocio = new N_Pelicula();
                peliculas = negocio.ObtenerTodos();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            //Regresamos la vista consulta con la lista de peliculas como modelo
            return View("Consulta", peliculas);
        }

        public ActionResult IrAgregar()
        {
            return View("Agregar");
        }

        public ActionResult Agregar(E_Pelicula objPelicula)
        {
            try
            {
                //Creamos un objeto de la capa de Negocio
                N_Pelicula negocio = new N_Pelicula();

                //Llamamos al método Agregar
                negocio.Agregar(objPelicula);
                TempData["success"] = "Pelicula agregada satisfactoriamente";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        public ActionResult IrEditar(int id)
        {
            //Crear objeto para la pelicula
            E_Pelicula pelicula = new E_Pelicula();

            //Obtenemos la info de la pelicula desde la Capa de Negocio
            try
            {
                //Objeto capa de negocio
                N_Pelicula negocio = new N_Pelicula();
                pelicula = negocio.ObtenerPorID(id);
                return View("Editar", pelicula);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Editar(E_Pelicula pelicula)
        {

            N_Pelicula negocio = new N_Pelicula();
            try
            {
                negocio.Modificar(pelicula);
                TempData["success"] = $"La pelicula con el id: {pelicula.getIdPelicula} fue modificada exitosamente";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Buscar(string textoBusqueda)
        {
            N_Pelicula negocio = new N_Pelicula();

            try
            {
                List<E_Pelicula> peliculas = negocio.Buscar(textoBusqueda);
                return View("Consulta", peliculas);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult IrEliminar(int id)
        {
            //Crear objeto para la pelicula
            E_Pelicula pelicula = new E_Pelicula();

            //Obtenemos la info de la pelicula de la capa Negocio
            try
            {
                //Objeto de la capa Negocio
                N_Pelicula negocio = new N_Pelicula();
                pelicula = negocio.ObtenerPorID(id);
                return View("Eliminar", pelicula);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Eliminar(int id, bool? confirmacion = null)
        {
            if (confirmacion == null)
            {
                TempData["error"] = "No se ha confirmado la accion";
                return RedirectToAction("Index");
            }
            else
            {
                //Objeto de la capa anterior (negocio) la cual contiene el metodo, heredado a su vez de la capa de datos
                N_Pelicula eliminador = new N_Pelicula();

                try
                {
                    eliminador.Eliminar(id); /*usa el metodo eliminar de la herramienta eliminador en el id*/
                    TempData["success"] = $"La pelicula con el ID: {id} ha sido eliminada correctamente.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("Index");
                }

            }
        }
    }
}