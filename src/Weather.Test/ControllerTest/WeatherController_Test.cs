using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Weather.Data.Models;
using Weather.MVC.Controllers;

namespace Weather.Test.ControllerTest
{
    [TestClass]
    public class WeatherController_Test
    {
        [TestMethod]
        public void TestReturnType()
        {
            var controller = new WeatherController();
            var result = controller.GetAllWeathers() as ViewResult;
            Assert.AreEqual(new List<SingleWeather>().GetType(), result.Model.GetType());
        }
    }
}
