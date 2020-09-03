using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Services;
using University.Models;
using University.DAL;

namespace University.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class MarkController : Controller
    {
        MarkService markService;

        public MarkController(MarkService markService)
        {
            this.markService = markService;
        }
    }
}
