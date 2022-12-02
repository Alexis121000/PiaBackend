using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiLoteria.DTOs;
using WebApiLoteria.Entidades;

namespace WebApiLoteria.Controllers
{
    [ApiController]
    [Route("cuentas")]
    public class CuentasController: ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public CuentasController(UserManager<IdentityUser> userManager, IConfiguration configuration,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<AutenticacionResp>> Registrar(SistemaUsuario sistema)
        {
            var user = new IdentityUser { UserName = sistema.Correo, Email = sistema.Correo };
            var result = await userManager.CreateAsync(user, sistema.Contraseña);

            if (result.Succeeded)
            {
                return await ConstruirToken(sistema);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("iniciarSeccion")]
        public async Task<ActionResult<AutenticacionResp>> Login(SistemaUsuario sistemaUsuario)
        {
            var result = await signInManager.PasswordSignInAsync(sistemaUsuario.Correo,
                sistemaUsuario.Contraseña, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await ConstruirToken(sistemaUsuario);
            }
            else
            {
                return BadRequest("Error al iniciar sección");
            }

        }

        [HttpGet("cambiarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AutenticacionResp>> Renovar()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "correo").FirstOrDefault();
            var email = emailClaim.Value;

            var credenciales = new SistemaUsuario()
            {
                Correo = email
            };

            return await ConstruirToken(credenciales);

        }

        private async Task<AutenticacionResp> ConstruirToken(SistemaUsuario sistemaUsuario)
        {
         
            var claims = new List<Claim>
            {
                new Claim("correo", sistemaUsuario.Correo)
                
            };

            var usuario = await userManager.FindByEmailAsync(sistemaUsuario.Correo);
            var claimsDB = await userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(45);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: creds);

            return new AutenticacionResp()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiration
            };
        }

        [HttpPost("hacerAdmin")]
        public async Task<ActionResult> HacerAdmin(EditarAdminDTO editarAdminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(editarAdminDTO.Email);

            await userManager.AddClaimAsync(usuario, new Claim("Autorizado", "Si"));

            return NoContent();
        }

        [HttpPost("eliminarAdmin")]
        public async Task<ActionResult> RemoverAdmin(EditarAdminDTO editarAdminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(editarAdminDTO.Email);
            await userManager.RemoveClaimAsync(usuario, new Claim("Autorizado", "Si"));
            return NoContent();
        }

    }
}