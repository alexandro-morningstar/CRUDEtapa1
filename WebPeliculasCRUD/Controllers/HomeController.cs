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
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            TempData["success"] = "Pelicula agregada satisfactoriamente";
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
    }
}