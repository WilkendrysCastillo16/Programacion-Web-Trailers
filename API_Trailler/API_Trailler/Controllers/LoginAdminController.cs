using API_Trailler.Models;
using API_Trailler.Models.DTOs;
using API_Trailler.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAdminController : ControllerBase
    {
        private readonly ILoginAdminServices _loginAdminServices;
        protected ResponseDto _responseDto;
        public LoginAdminController(ILoginAdminServices loginAdminServices)
        {
            _loginAdminServices = loginAdminServices;
            _responseDto = new ResponseDto();
        }

        [HttpPost("Register")]
        [Authorize]
        public async Task<ActionResult> Register(LoginAdminDto loginAdminDto)
        {
            var respuesta = await _loginAdminServices.Registrar(
                    new LoginAdmin
                    {
                        Email = loginAdminDto.email
                    }, loginAdminDto.pass);

            if (respuesta == "existe")
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "El usuario ya existe";

                return BadRequest(_responseDto);
            }

            if (respuesta == "error")
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "Error al crear el usuario";

                return BadRequest(_responseDto);
            }

            _responseDto.Mensaje = "Registrado con exito";
            return Ok(_responseDto);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginAdminDto loginAdminDto)
        {
            var respuesta = await _loginAdminServices.Login(loginAdminDto.email, loginAdminDto.pass);

            if(respuesta == "No Encontrado")
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "El usuario no existe";

                return BadRequest(_responseDto);
            }
            if(respuesta == "Pass Incorrecta")
            {
                _responseDto.Correcto = false;
                _responseDto.Mensaje = "El password es incorrecto";

                return BadRequest(_responseDto);
            }

            _responseDto.Result = respuesta;
            _responseDto.Mensaje = "Administrador conectado";
            return Ok(_responseDto);


        }
    }
}
