using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private IConfiguration Configuration;


        public QuestionsController(IConfiguration _configuration)
        {
            Configuration = _configuration;

        }
        [HttpGet]
        [Route("GetAllQuestions")]
        public IActionResult Get()
        {
            return Ok("Reading all Questions");
        }
    }
}
