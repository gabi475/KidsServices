using KidsServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using KidsServices.Models.DTO;
using KidsServices.Models.Domain;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KidServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KidController : ControllerBase
    {
        private KidServicesContext Context { get; }

        public KidController(KidServicesContext context)
        {
            Context = context;
        }

        [HttpPost]
        public IActionResult RegisterKid(KidDto kidDto)
        {
            var kid = new Kid(
                kidDto.FirstName,
                kidDto.LastName,
                kidDto.SocialSecurityNumber,
                kidDto.PhoneNumber
            );

            Context.Kids.Add(kid);

            Context.SaveChanges();

            // TODO Eventuellt byt ut DTO mot annan

            return Created("", kidDto); // 201 Created
        }

        [HttpGet("{socialSecurityNumber}")]
        public IActionResult GetKid(string socialSecurityNumber)
        {
            var kid = Context.Kids.FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

            if (kid == null)
                return NotFound(); // 404 Not Found

            var kidDto = new KidDto
            {
                FirstName = kid.FirstName,
                LastName = kid.LastName,
                SocialSecurityNumber = kid.SocialSecurityNumber,
                PhoneNumber = kid.PhoneNumber
            };

            return Ok(kidDto); // 200 OK
        }
    }
}