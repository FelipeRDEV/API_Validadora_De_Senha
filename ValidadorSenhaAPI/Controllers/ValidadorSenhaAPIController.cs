using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using ValidadorSenhaAPI.Models;
using ValidadorSenhaAPI.ApiBLL;

namespace ValidadorSenhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidadorSenhaAPIController : ControllerBase
    {
        [HttpPost]
        public ActionResult<SenhaModel> ValidarSenha([FromBody] [Description("Digite a senha a ser validada:")] SenhaModel senhaModel)
        {
            if (senhaModel == null || string.IsNullOrWhiteSpace(senhaModel.Senha))
            {
                return BadRequest("É necessário preencher uma senha ao fazer uma requisição.");
            }

            ValidadorSenhaApiBLL apiBLL = new ValidadorSenhaApiBLL();

            SenhaRetornoAPIModel senhaRetornoAPIModel = apiBLL.VerificarParametrosSenhaValida(senhaModel.Senha);

            return Ok(senhaRetornoAPIModel);
        }

    }

}
