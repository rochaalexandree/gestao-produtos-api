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

        protected ActionResult ToActionResult(object result = null)
        {
            if (ResultadoSucesso())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }

        protected ActionResult ToActionResult<T>(Resposta<IEnumerable<object>> resposta, IMapper mapper)
        {
            if (ResultadoSucesso())
                return Ok(mapper.Map<T>(resposta));

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }

        protected ActionResult ToActionResult<T>(Resposta<object> resposta, IMapper mapper)
        {
            if (ResultadoSucesso())
                return Ok(mapper.Map<T>(resposta));

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }

        protected bool ResultadoSucesso()
        {
            return !Erros.Any();
        }
    }
}
