using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PetClient.Data;
using PetClient.Models;

namespace PetClient.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly ClientsAPIDbContext dbContext;

        public ClientsController(ClientsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            return Ok(await dbContext.Clients.ToListAsync());
            
        }
        [HttpPost]
        public async Task<IActionResult> AddClient(AddClientRequest addClientRequest)
        {
            var client = new Client()
            {
                Id = Guid.NewGuid(),
                FullName= addClientRequest.FullName,
                Address = addClientRequest.Address,
                Email = addClientRequest.Email,
                Phone = addClientRequest.phone,
                Species = addClientRequest.species,
                Breed = addClientRequest.breed,
                PetBirthday = addClientRequest.PetBirthday,
                PetName = addClientRequest.PetName,

            };
            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();

            return Ok(client);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateClient([FromRoute] Guid id, UpdateClientRequest updateClientRequest)
        {
           var client =  dbContext.Clients.Find(id);

            if (client != null) 
            {
                client.FullName= updateClientRequest.FullName;
                client.Address= updateClientRequest.Address;
                client.Email= updateClientRequest.Email;
                client.Phone= updateClientRequest.Phone;
                client.Species= updateClientRequest.Species;
                client.PetBirthday = updateClientRequest.PetBirthday;
                client.PetName= updateClientRequest.PetName;    


            }

            return NotFound();
        }
        
    }
}
