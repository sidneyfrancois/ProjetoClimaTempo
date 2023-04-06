using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Weather.Data.Models;
using Weather.MVC.Controllers;

namespace Weather.Test.ControllerTest
{
    [TestClass]
    public class PrevisaoClimaTempoController_Test
    {
        [TestMethod]
        public void GetAllCidades_Test()
        {
            var controller = new PrevisaoClimaTempoController();
            var result = controller.GetAllCidades() as ViewResult;
            Assert.AreEqual(new List<Cidade>().GetType(), result.Model.GetType());
        }
    }
}
