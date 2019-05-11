using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/stylist")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylist/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylist")]
    public ActionResult Create(string firstName, string lastName)
    {
      Stylist newStylist = new Stylist(firstName, lastName);
      List<Stylist> allStylists = Stylist.GetAll();
      newStylist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylist/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClients();
      model.Add("stylist", selectedStylist);
      model.Add("stylistClients", stylistClients);
      return View(selectedStylist);
    }

    [HttpPost("/stylist/{stylistId}/client")]
    public ActionResult Create(string firstName, string lastName, DateTime clientSince, int stylistId)
    {
      Stylist foundStylist = Stylist.Find(stylistId);
      Client newClient = new Client(firstName, lastName, clientSince, stylistId);
      newClient.Save();
      foundStylist.GetClients();
      return View("Show", foundStylist);
    }

    [HttpPost("/stylist/{stylistId}/delete")]
    public ActionResult Delete(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      stylist.DeleteStylist();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("stylist", stylist);
      return RedirectToAction("Index");
    }

  }
}
