using clients_api.ViewModel;
using GC.BL;
using GC.Entites;
using GC.GenererDonnees;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenData : ControllerBase
    {
        private readonly GestionClientsBL _gestionClientsBL;

        public GenData(GestionClientsBL gestionClientsBL)
        {
            _gestionClientsBL = gestionClientsBL;
        }

        //// GET: api/<GenData>
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        //public IActionResult Get()
        //{
        //    return StatusCode(StatusCodes.Status405MethodNotAllowed);
        //}

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        //public IActionResult Get(int id)
        //{
        //    return StatusCode(StatusCodes.Status405MethodNotAllowed);
        //}

        // POST api/<GenData>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(List<Client>))]
        public IActionResult Post([FromBody] ClientGenerationViewModel clientGenerationViewModel)
        {
            if (clientGenerationViewModel is null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            List<Client> clients = GenerateurDonnees.GenererClients(clientGenerationViewModel.Quantity);

            foreach (Client client in clients)
            {
                _gestionClientsBL.AjouterClient(client);
            }

            return StatusCode(StatusCodes.Status201Created, clients);
        }

        //// PUT api/<GenData>/5
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        //public IActionResult Put(int id, [FromBody] ClientGenerationViewModel clientGenerationViewModel)
        //{
        //    return StatusCode(StatusCodes.Status405MethodNotAllowed);
        //}

        //// DELETE api/<GenData>/5
        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        //public IActionResult Delete(int id)
        //{
        //    return StatusCode(StatusCodes.Status405MethodNotAllowed);
        //}
    }
}
