using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Weather.Data.Models;
using Weather.Data.ViewModel;
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

        [TestMethod]
        public void TestAddWeather()
        {
            var viewModel = new AddWeatherViewModel()
            {
                Temperature = 25,
                Type = TypeWeather.Ensolarado
            };

            var controller = new WeatherController();
            var result = controller.AddWeather(viewModel) as ViewResult;
            var weatherResult = (SingleWeather) result.ViewData.Model;

            Assert.AreEqual(new Guid().GetType(), weatherResult.Id.GetType());
            Assert.AreEqual(TypeWeather.Ensolarado, weatherResult.Type);
            Assert.AreEqual(25, weatherResult.Temperature);
        }
    }
}
