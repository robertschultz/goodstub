// <copyright file="HomeControllerTest.cs" company="Microsoft">Copyright © Microsoft 2011</copyright>
using System;
using System.Web.Mvc;
using Goodstub.Web.Frontend.Controllers;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goodstub.Web.Frontend.Controllers
{
    /// <summary>This class contains parameterized unit tests for HomeController</summary>
    [PexClass(typeof(HomeController))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class HomeControllerTest
    {
        /// <summary>Test stub for Index()</summary>
        [PexMethod]
        public ActionResult Index([PexAssumeUnderTest]HomeController target)
        {
            ActionResult result = target.Index();
            return result;
            // TODO: add assertions to method HomeControllerTest.Index(HomeController)
        }
    }
}
