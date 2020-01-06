using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RequestTimeTrackingMiddleware.DAL;
using RequestTimeTrackingMiddleware.Models;

namespace RequestTimeTrackingMiddleware.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private IProfileRepository repository;

        public ProfileController(IProfileRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Profile> Get()
        {
            var profiles = repository.Get(x => true);
            return profiles;
        }

        [HttpGet("{id}")]
        public Profile Get(int? id)
        {
            var profile = repository.GetById((int)id);
            return profile;
        }

        [HttpPatch]
        public IActionResult Update([FromBody] Profile profile)
        {
            repository.Update(profile);
            return Ok();
        }

        [HttpPut]
        public IActionResult Create([FromBody] Profile profile)
        {
            repository.Create(profile);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            repository.Delete((int)id);
            return Ok();
        }
    }
}