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
        private IProfileRepository _repository;

        public ProfileController(IProfileRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<Profile> Get()
        {
            var profiles = _repository.Get(x => true);
            return profiles;
        }

        [HttpGet("{id}")]
        public Profile Get(int id)
        {
            var profile = _repository.GetById(id);
            return profile;
        }

        [HttpPatch]
        public IActionResult Update([FromBody] Profile profile)
        {
            if (profile == null)
            {
                return BadRequest();
            }
            _repository.Update(profile);
            return Ok();
        }

        [HttpPut]
        public IActionResult Create([FromBody] Profile profile)
        {
            if (profile==null)
            {
                return BadRequest();
            }
            _repository.Create(profile);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            _repository.Delete((int)id);
            return Ok();
        }
    }
}