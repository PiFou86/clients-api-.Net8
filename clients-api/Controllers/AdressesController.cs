using clients_api.ViewModel;
using GC.BL;
using GC.Entites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clients_api.Controllers
{
    [Route("api/clients/{clientId}/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private GestionClientsBL _gestionClients;
        public AdressesController(GestionClientsBL gestionClientsBL)
        {
            _gestionClients = gestionClientsBL;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AdresseViewModel>))]
        public ActionResult<IEnumerable<AdresseViewModel>> Get([FromQuery] PagingParameters pagingParameters, Guid clientId)
        {
            return Ok(_gestionClients.ListerAdresses(clientId, pagingParameters).Select(a => new AdresseViewModel(a)));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{adresseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdresseViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AdresseViewModel> Get(Guid clientId, Guid adresseId)
        {
            Adresse? a = _gestionClients.ObtenirAdresse(clientId, adresseId);
            return a is null ? NotFound() : Ok(new AdresseViewModel(a));
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AdresseViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AdresseViewModel> Post(Guid clientId, [FromBody] AdresseViewModel adresseViewModel)
        {
            if (adresseViewModel is  null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            adresseViewModel.AdresseId = Guid.NewGuid();
            Adresse adresse = adresseViewModel.ToEntity();
            _gestionClients.AjouterAdresse(clientId, adresse);
            adresseViewModel.AdresseId = adresse.AdresseId;

            return CreatedAtAction(nameof(Get), new { clientId = clientId, id = adresse.AdresseId }, adresseViewModel);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{adresseId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(AdresseViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AdresseViewModel> Put(Guid clientId, Guid adresseId, [FromBody] AdresseViewModel adresseViewModel)
        {
            if (adresseViewModel is null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            if (adresseId != adresseViewModel.AdresseId)
            {
                return BadRequest();
            }

            Adresse? c = _gestionClients.ObtenirAdresse(clientId, adresseId);
            if (c is null)
            {
                return NotFound();
            }

            _gestionClients.ModifierAdresse(clientId, adresseViewModel.ToEntity());

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{adresseId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(Guid clientId, Guid adresseId)
        {
            Adresse? c = _gestionClients.ObtenirAdresse(clientId, adresseId);

            if (c is null)
            {
                return NotFound();
            }

            _gestionClients.EffacerAdresse(clientId, adresseId);

            return NoContent();
        }
    }
}
