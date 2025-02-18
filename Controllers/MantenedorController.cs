using Microsoft.AspNetCore.Mvc;

using CRUDPROJECT.Datos;
using CRUDPROJECT.Models;

namespace CRUDPROJECT.Controllers
{
    public class MantenedorController : Controller
    {
        TBLProductosDatos _ProductosDatos = new TBLProductosDatos();
        public IActionResult Listar()
        {
            var oLista = _ProductosDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(TBLPRODUCTOSModel oProducto)
        {
            if(!ModelState.IsValid)
                return View();

            var respuesta = _ProductosDatos.Guardar(oProducto);

            if(respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdProducto)
        {
            var oProducto = _ProductosDatos.Obtener(IdProducto);
            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Editar(TBLPRODUCTOSModel oProducto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ProductosDatos.Editar(oProducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdProducto)
        {
            var oProducto = _ProductosDatos.Obtener(IdProducto);
            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Eliminar(TBLPRODUCTOSModel oProducto)
        {
            
            var respuesta = _ProductosDatos.Eliminar(oProducto.IdProducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
