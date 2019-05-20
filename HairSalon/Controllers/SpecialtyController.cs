using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {
    [HttpGet("/specialty")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialty = Specialty.GetAll();
      return View(allSpecialty);
    }

    [HttpGet("/specialty/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/specialty")]
    public ActionResult Create(string specialtyType)
    {
      Specialty newSpecialty = new Specialty(specialtyType);
      newSpecialty.Save();
      List<Specialty> allSpecialty = Specialty.GetAll();
      return View("Index", allSpecialty);
    }

    [HttpGet("/specialty/{specialtyId}")]
    public ActionResult Show(int specialtyId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(specialtyId);
      List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialty", selectedSpecialty);
      model.Add("specialtyStylists", specialtyStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    [HttpPost("/specialty/{specialtyId}/stylist/new")]
    public ActionResult AddStylist(int specialtyId, int stylistId)
    {
      Specialty specialty = Specialty.Find(specialtyId);
      Stylist stylist = Stylist.Find(stylistId);
      specialty.AddStylist(stylist);
      return RedirectToAction("Show",  new { id = specialtyId });
    }

    [HttpPost("/specialty/{specialtyId}/delete")]
    public ActionResult Delete(int specialtyId)
    {
      Specialty specialty = Specialty.Find(specialtyId);
      specialty.DeleteSpecialty();
      return Redirect("/");
    }


    [HttpGet("/specialty/{specialtyId}/edit")]
    public ActionResult Edit(int specialtyId)
    {
      Specialty specialty = Specialty.Find(specialtyId);
      return View(specialty);
    }

    [HttpPost("/specialty/{specialtyId}")]
    public ActionResult Update(int specialtyId, string newType)
    {
      Specialty specialty = Specialty.Find(specialtyId);
      specialty.Edit(newType);
      return RedirectToAction("Show", specialtyId);
    }
  }
}
