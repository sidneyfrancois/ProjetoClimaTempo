using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Weather.Data.Models;
using Weather.MVC.Controllers;
using System.Linq;

namespace Weather.Test.ControllerTest
{
    [TestClass]
    public class WeatherController_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var listComparasion = new List<SingleWeather>();

            var controller = new WeatherController();
            var result = controller.GetAllWeathers();
            Assert.AreEqual(listComparasion, result);
        }
    }
}
