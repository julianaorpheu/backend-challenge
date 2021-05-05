using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Application.Command.Generic;
using Ardalis.GuardClauses;
using System.Net;

namespace BackEnd.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {
        #region Properties

        private IMediator Mediator { get; }
        #endregion

        #region Constructor
        public APIController(IMediator mediator)
        {
            Guard.Against.Null(mediator, nameof(mediator));
            Mediator = mediator;
        }
        #endregion

        #region Actions

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> Pedido([FromBody] CreatePedidoRequest request)
        {
            var response = await Mediator.Send(request);
            if (response.statusCode == (int)HttpStatusCode.OK)
            {
                return Ok(response);
            }
            return StatusCode(response.statusCode, response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Pedido([FromBody] PostPedidoRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            if (response.statusCode == (int)HttpStatusCode.OK)
            {
                return Ok(response);
            }
            return StatusCode(response.statusCode, response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> Pedido([FromBody] FindPedidoRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
           if (response.statusCode == (int)HttpStatusCode.OK)
            {
                return Ok(response);
            }
            return StatusCode(response.statusCode, response);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<ActionResult> Pedido([FromBody] DeletePedidoRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
           if (response.statusCode == (int)HttpStatusCode.OK)
            {
                return Ok(response);
            }
            return StatusCode(response.statusCode, response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Status([FromBody] StatusPedidoRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            if (response.statusCode == (int)HttpStatusCode.OK)
            {
                return Ok(response);
            }
            return StatusCode(response.statusCode, response);
        }
        #endregion
    }
}