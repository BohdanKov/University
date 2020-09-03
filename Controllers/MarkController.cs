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
    [Route("api/marks")]
    public class MarkController : Controller
    {
        private MarkService markService;

        public MarkController(MarkService markService)
        {
            this.markService = markService;
        }

        [HttpPost]
        public Mark AddMark(Mark mark)
        {
            return markService.AddMark(mark);
        }

        [HttpPatch("{id}/{newValue}")]
        public void Update(int id, int newValue)
        {
            markService.UpdateMark(id, newValue);
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            markService.DeleteMark(id);
        }
    }
}
