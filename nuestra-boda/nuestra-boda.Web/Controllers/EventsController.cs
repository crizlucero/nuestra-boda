using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nuestra_boda.Core.Models.Events;

namespace nuestra_boda.Web.Controllers
{
    public class EventsController : Controller
    {
        #region Vistas
        // GET: EventController
        /// <summary>
        /// Presentación de la página del evento, donde tendrá toda la información
        /// </summary>
        /// <param name="EventCode"></param>
        /// <returns></returns>
        public ActionResult Index(string EventCode = "")
        {
            
            return View();
        }

        public ActionResult Microeventos(string EventCode = "")
        {
            //Obtiene el evento principal
            EventsModel model = new() { EventCode = EventCode };
            model.GetEvento();
            //Obtener microeventos
            model.MicroEventos = MicroEventsModel.GetMicroEventos(EventCode);
            return View(model);
        }
        #endregion

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
