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
            mark.Date = DateTime.Today;
            return markService.AddMark(mark);
        }

        [HttpPatch("{id}")]
        public void Update(int id, [FromBody] MarkPatchRequest body)
        {
            markService.UpdateMark(id, body.Grade); 
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            markService.DeleteMark(id);
        }
    }
}
