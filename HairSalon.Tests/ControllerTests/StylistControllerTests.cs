using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistControllerTest
  {
    [TestMethod]
    public void Index_HasCorrectModelType_StylistList()
    {
      StylistController controller = new StylistController();
      ViewResult indexView = controller.Index() as ViewResult;

      var result = indexView.ViewData.Model;

      Assert.IsInstanceOfType(result, typeof(List<Stylist>));
    }

  }
}
