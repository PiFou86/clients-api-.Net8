using clients_api.ViewModel;
using GC.BL;
using GC.Entites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private GestionClientsBL _gestionClients;
        public ClientsController(GestionClientsBL gestionClientsBL)
        {
            _gestionClients = gestionClientsBL;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClientViewModel>))]
        public ActionResult<IEnumerable<ClientViewModel>> Get([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(_gestionClients.ObtenirClients(pagingParameters).Select(x => new ClientViewModel(x)));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClientViewModel> Get(Guid clientId)
        {
            Client? c = _gestionClients.ObtenirClient(clientId);
            return c is null ? NotFound() : Ok(new ClientViewModel(c));
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClientViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ClientViewModel> Post([FromBody] ClientViewModel clientViewModel)
        {
            if (clientViewModel is  null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            clientViewModel.ClientId = Guid.NewGuid();
            Client client = clientViewModel.ToEntity();
            _gestionClients.AjouterClient(client);
            clientViewModel.ClientId = client.ClientId;

            return CreatedAtAction(nameof(Get), new { id = client.ClientId }, clientViewModel);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{clientId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ClientViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClientViewModel> Put(Guid clientId, [FromBody] ClientViewModel clientViewModel)
        {
            if (clientViewModel is null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            if (clientId != clientViewModel.ClientId)
            {
                return BadRequest();
            }

            Client? c = _gestionClients.ObtenirClient(clientId);
            if (c is null)
            {
                return NotFound();
            }

            _gestionClients.ModifierClient(clientViewModel.ToEntity());

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{clientId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(Guid clientId)
        {
            Client? c = _gestionClients.ObtenirClient(clientId);

            if (c is null)
            {
                return NotFound();
            }

            _gestionClients.EffacerClient(clientId);

            return NoContent();
        }
    }
}
