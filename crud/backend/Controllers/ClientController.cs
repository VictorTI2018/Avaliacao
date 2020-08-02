using System.Collections.Generic;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ClientController : Controller {

        [HttpGet]
        public List<Client> Get () {
            ClientRepository clientRepo = new ClientRepository ();
            List<Client> data = clientRepo.All ();
            return data;
        }

        [HttpGet ("{id}")]
        public Client Get (int id) {
            ClientRepository clientRepo = new ClientRepository ();
            Client data = clientRepo.find (id);
            return data;
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Client value) {
            ClientRepository clientRepo = new ClientRepository ();
            clientRepo.save ();
            return Json(new {
                Response = "OK",
                Message = "Criado com sucesso"
            });
        }
    }
}