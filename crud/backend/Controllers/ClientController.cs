using System.Collections.Generic;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ClientController : Controller {

        [HttpGet]
        public IActionResult Get () {
            ClientRepository clientRepo = new ClientRepository ();
            List<Client> data = clientRepo.All ();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Client value) {
            return Json (new {
                Response = "OK",
                    Data = value
            });
        }
    }
}