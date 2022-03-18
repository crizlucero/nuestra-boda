using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using nuestra_boda.Core.Models.Events;
using nuestra_boda.Core.Models.Users;

namespace nuestra_boda.Web.Controllers
{
    public class AdminController : Controller
    {
        #region Vistas
        // GET: AdminController/Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: AdminController
        /// <summary>
        /// Mostrar la información general del usuario, así como sus eventos
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("UsuarioSession") == null)
            {
                return RedirectToAction("Login");
            }
            PersonaModel persona = JsonConvert.DeserializeObject<PersonaModel>(HttpContext.Session.GetString("UsuarioSession"));
            if (persona == null)
            {
                return RedirectToAction("Login");
            }
            persona.Eventos = EventsModel.GetEventos(persona.IDPersona);
            return View();
        }



        public ActionResult AddPersona()
        {
            return View();
        }

        public ActionResult AddEventos()
        {
            return View();
        }

        #endregion

        #region Servicios
        // POST: AdminController/Login
        [HttpPost]
        public JsonResult Login(UserModel usuario)
        {
            usuario.GetUser();
            PersonaModel persona = new() { UserModel = usuario };
            persona.GetPersona();
            HttpContext.Session.SetString("UsuarioSession", JsonConvert.SerializeObject(persona));

            return Json(persona);
        }
        #endregion
    }
}
