using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Trailler.Data;
using API_Trailler.Models;
using API_Trailler.Services.Interface;
using API_Trailler.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API_Trailler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TraillersController : ControllerBase
    {
        private readonly ITraillerServices _traillerServices;
        protected ResponseDto _responseDto;
        public TraillersController(ITraillerServices traillerServices)
        {
            _traillerServices = traillerServices;
            _responseDto = new ResponseDto();
        }

        // GET: api/Traillers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trailler>>> GetTraillers()
        {
            try
            {
                var listaTrailler = await _traillerServices.GetTraillers();
                _responseDto.Result = listaTrailler;
                _responseDto.Mensaje = "Lista de Trailler";
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.ErrorMensaje = new List<string> { ex.ToString() };
            }

            return Ok(_responseDto);
        }

        // GET: api/Traillers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trailler>> GetTrailler(int id)
        {
            var trailler = await _traillerServices.GetTraillerById(id);
            if(trailler == null)
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "El trailler no existe";
                return NotFound(_responseDto);
            }
            _responseDto.Result = trailler;
            _responseDto.Mensaje = "Informacion del trailler";

            return Ok(_responseDto);
        }

        // PUT: api/Traillers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTrailler(int id, TraillerDto traillerDto)
        {
            try
            {
                TraillerDto model = await _traillerServices.UpdateTrailler(traillerDto);
                _responseDto.Result = model;
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "Error al actualizar el trailler";
                _responseDto.ErrorMensaje = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }  
        }

        // POST: api/Traillers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Trailler>> PostTrailler(TraillerDto traillerDto)
        {
            try
            {
                TraillerDto model = await _traillerServices.AddTrailler(traillerDto);
                _responseDto.Result = model;

                return CreatedAtAction("GetTrailler", new { id = model.Id }, _responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "Error al insertar el trailler";
                _responseDto.ErrorMensaje = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }

        // DELETE: api/Traillers/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTrailler(int id)
        {
            try
            {
                bool eliminado = await _traillerServices.DeleteTrailler(id);
                if (eliminado)
                {
                    _responseDto.Result = eliminado;
                    _responseDto.Mensaje = "Trailler eliminado correctamente";
                    return Ok(_responseDto);
                }
                else
                {
                    _responseDto.Correcto = false;
                    _responseDto.Mensaje = "Error al eliminar un cliente";
                    return BadRequest(_responseDto);
                }
            }
            catch (Exception ex)
            {
                _responseDto.Correcto = false;
                _responseDto.Result = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }

    }
}
