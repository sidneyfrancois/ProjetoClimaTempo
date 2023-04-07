﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using Weather.Data.Models;
using Weather.MVC.Controllers;

namespace Weather.Test.ControllerTest
{
    [TestClass]
    public class PrevisaoClimaTempoController_Test
    {
        [TestMethod]
        [DataSource("SourceDefault")]
        public void GetAllCidadesType_Test()
        {
            var controller = new PrevisaoClimaTempoController();
            var result = controller.GetAllCidades() as ViewResult;
            Assert.AreEqual(new List<Cidade>().GetType(), result.Model.GetType());  
        }

        [TestMethod]
        [DataSource("SourceDefault")]
        public void GetAllCidades_Test()
        {
            var controller = new PrevisaoClimaTempoController();
            var result = controller.GetAllCidades() as ViewResult;
            var cidadeResult = result.ViewData.Model;
            Trace.WriteLine("The list: " + cidadeResult);
        }

        [TestMethod]
        [DataSource("SourceDefault")]
        public void GetAllEstados_Test()
        {
            var controller = new PrevisaoClimaTempoController();
            var result = controller.GetAllEstados() as ViewResult;
            var cidadeResult = result.ViewData.Model;
            Trace.WriteLine("The list: " + cidadeResult);
        }

        [TestMethod]
        [DataSource("SourceDefault")]
        public void GetAllClimas_Test()
        {
            var controller = new PrevisaoClimaTempoController();
            var result = controller.GetAllClimas() as ViewResult;
            var cidadeResult = result.ViewData.Model;
            Trace.WriteLine("The list: " + cidadeResult);
        }

        [TestMethod]
        [DataSource("SourceDefault")]
        public void GetTopThreeHottest_Test()
        {
            DateTime today = new DateTime(2023, 02, 21);

            var controller = new PrevisaoClimaTempoController();
            var result = controller.GetMaxHoje(today) as ViewResult;
            var cidadeResult = result.ViewData.Model;
            Trace.WriteLine("The list: " + cidadeResult);
        }
    }
}