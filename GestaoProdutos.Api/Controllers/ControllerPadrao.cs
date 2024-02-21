using AutoMapper;
using GestaoProdutos.Aplicacao;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GestaoProdutos.Controllers
{
    [ApiController]
    public abstract class ControllerPadrao : Controller
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult ToActionResult<T>(Resposta<T> resposta = null)
        {
            if (resposta.Sucesso)
                return Ok(resposta);

            return BadRequest(resposta);
        }

        protected ActionResult ToActionResult<T>(Resposta<IEnumerable<object>> resposta, IMapper mapper)
        {
            if (ResultadoSucesso())
                return Ok(mapper.Map<T>(resposta));

            return BadRequest(resposta);
        }

        protected ActionResult ToActionResult<T>(Resposta<object> resposta, IMapper mapper)
        {
            if (resposta.Sucesso)
                return Ok(mapper.Map<T>(resposta));

            return BadRequest(resposta);
        }

        protected bool ResultadoSucesso()
        {
            return !Erros.Any();
        }
    }
}
