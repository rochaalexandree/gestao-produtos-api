using AutoMapper;
using GestaoProdutos.Aplicacao;
using GestaoProdutos.Aplicacao.Dto;
using GestaoProdutos.Aplicacao.Servicos;
using GestaoProdutos.Dominio.Entidades;
using GestaoProdutos.Modelos.Requests;
using GestaoProdutos.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : ControllerPadrao
    {
        private readonly IProdutoServico _servicoProduto;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoServico servicoProduto, IMapper mapper)
        {
            _servicoProduto = servicoProduto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] FiltroProdutoRequest filtro, CancellationToken cancellationToken)
        {
            var produtoDto = _mapper.Map<FiltroProdutoDto>(filtro);

            var resultado = await _servicoProduto.ListarProdutosAsync(produtoDto, cancellationToken);

            return ToActionResult<BaseViewModel<IEnumerable<ProdutoViewModel>>>(resultado, _mapper);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetPorCodigoAsync([FromRoute] int codigo, CancellationToken cancellationToken)
        {
            var resultado = await _servicoProduto.ObterProdutoPorCodigoAsync(codigo, cancellationToken);

            return ToActionResult<BaseViewModel<ProdutoViewModel>>(resultado, _mapper);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProdutoDto produto, CancellationToken cancellationToken)
        {
            var resultado = await _servicoProduto.AdicionarProdutoAsync(produto, cancellationToken);

            return ToActionResult(resultado);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutAsync([FromRoute] int codigo, [FromBody] ProdutoDto produto, CancellationToken cancellationToken)
        {
            var resultado = await _servicoProduto.AtualizarProdutoAsync(codigo, produto, cancellationToken);
            
            return ToActionResult(resultado);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int codigo, CancellationToken cancellationToken)
        {
            var resultado = await _servicoProduto.ExcluirProdutoAsync(codigo, cancellationToken);
            return ToActionResult(resultado);
        }
    }
}
