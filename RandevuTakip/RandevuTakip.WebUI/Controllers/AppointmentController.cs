using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandevuTakip.ENTITIES;
using RandevuTakip.SERVICES.Abstract;
using RandevuTakip.SERVICES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandevuTakip.WebUI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _service;
        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        
        public IActionResult CreateAppointment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                if(_service.CreateAppointment(appointment) == true)
                {
                    return RedirectToAction("Success");
                }
            }
            
            return RedirectToAction("Error");
        }

        public IActionResult ExpectedAppointments()
        {
            List<Appointment> expectedAppointments = _service.GetExpectedAppointments();
            return View(expectedAppointments);
        }
        
        public IActionResult Edit(int id)
        {
            Appointment appointment = _service.GetAppointmentById(id);

            if(appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            _service.EditAppointment(appointment);
            appointment.IsApproved = true;

            return RedirectToAction("Search");
        }

        public IActionResult Search(string searchString)
        {
            var response = _service.Search(searchString);
            ViewBag.count = response.Count();
            return View(response);
        }


        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
