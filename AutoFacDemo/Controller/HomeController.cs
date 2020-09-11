using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auto.Interface;
using AutoFacDemo.IHandle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoFacDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IDateWriter _dateWriter;
        private Icalculator _calculator;
        private ILogger _logger;
        public HomeController(IDateWriter dateWriter, Icalculator calculator,ILogger<HomeController> logger)
        {
            _dateWriter = dateWriter;
            _calculator = calculator;
            _logger = logger;
        }
        public string Index()
        {
            _logger.LogInformation("开始执行Home.Index" );
            return _dateWriter.writeDate() + "-------" + _calculator.Plus(2, 2).ToString() ;
        }

    }
}