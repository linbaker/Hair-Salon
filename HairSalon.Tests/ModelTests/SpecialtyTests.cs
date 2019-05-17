using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest //: IDisposable
  {
    //
    // public void Dispose()
    // {
    //   Client.ClearAll();
    // }

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=lindsey_baker_test;";
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfTypesAreTheSame_Specialty()
    {
      Specialty firstSpecialty = new Specialty("colorist");
      Specialty secondSpecialty = new Specialty("colorist");

      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }
  }
}
