using Api_Clase_12_05.Data;
using Api_Clase_12_05.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api_Clase_12_05.Controllers
{
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ContextDB _contexto;
        private readonly IMediator _mediator;
        public PersonaController(ContextDB contexto, IMediator mediator)
        {
            _contexto = contexto;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/personas/getPersonas")]
        public ActionResult<List<Persona>> GetPersonas()
        {
            var personas = _contexto.Personas.ToList();
            return Ok(personas);
        }

        [HttpGet]
        [Route("api/personas/getPersonaById/{id}")]
        public async Task<Persona> GetPersonaById(int id)
        {
            //var persona = _contexto.Personas.Where(c => c.Id == id).FirstOrDefault();
            //return Ok(persona);
            return await _mediator.Send(new Business.PersonaBusiness.GetPersonasById.GetPersonaByIdComando 
            {
                IdPersona = id
            });
        }
    }
}