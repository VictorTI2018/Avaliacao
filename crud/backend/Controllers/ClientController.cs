using System;
using System.Collections.Generic;
using backend.Core;
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
        public Message Post ([FromBody] Client value) {
            Message response = new Message ();
            try {
                ClientRepository clientRepo = new ClientRepository ();
                clientRepo.save (value);
                response.Result = true;
                response.ErrorMessage = string.Empty;
            } catch (Exception e) {
                response.Result = false;
                response.ErrorMessage = "Erro ao registrar um novo cliente: " + e.Message;
            }
            return response;
        }

        [HttpPut]
        [Route ("/api/client/edit/{id}")]
        public Message Put (int id, [FromBody] Client value) {
            Message response = new Message ();
            try {
                ClientRepository clientRepo = new ClientRepository ();
                clientRepo.edit (id, value);
                response.Result = true;
                response.ErrorMessage = string.Empty;
            } catch (Exception e) {
                response.Result = false;
                response.ErrorMessage = "Erro ao atualizar um  cliente: " + e.Message;
            }
            return response;
        }

        [HttpDelete ("{id}")]
        public Message Delete (int id) {
            Message response = new Message ();
            try {
                ClientRepository clientRepo = new ClientRepository ();
                clientRepo.remove (id);
                response.Result = true;
                response.ErrorMessage = string.Empty;
            } catch (Exception e) {
                response.Result = false;
                response.ErrorMessage = "Erro ao excluir um  cliente: " + e.Message;
            }
            return response;
        }
    }
}