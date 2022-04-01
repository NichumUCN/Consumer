using Consumer.Models;
using Consumer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Controllers {
	public class PersonsController : Controller {
		// GET: PersonsController
		public async Task<ActionResult> Index() {
			PersonService personService = new PersonService();
			return View(await personService.GetPersons());
		}

		// GET: PersonsController/Details/5
		public async Task<ActionResult> Details(string id)
		{
			PersonService personService = new PersonService();
			return View(await personService.GetPersonByEmail(id));
		}

		// GET: PersonsController/Create
		public ActionResult Create() {
			return View();
		}

		// POST: PersonsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}

		// GET: PersonsController/Edit/5
		public ActionResult Edit(int id) {
			return View();
		}

		// POST: PersonsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}

		// GET: PersonsController/Delete/5
		public ActionResult Delete(int id) {
			return View();
		}

		// POST: PersonsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}
	}
}
