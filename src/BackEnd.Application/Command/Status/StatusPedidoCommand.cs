using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BackEnd.CrossCutting.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Application.Command.Generic
{   
    public class StatusPedidoCommand : IRequestHandler<StatusPedidoRequest, StatusPedidoResponse>
    {
        #region Properties
        #endregion
        #region Constructor
        public StatusPedidoCommand()
        {
        }
        #endregion
        
        #region IRequestHandler implementation
        public async Task<StatusPedidoResponse> Handle(StatusPedidoRequest item, CancellationToken cancellationToken)
        {
           StatusPedidoResponse result = new StatusPedidoResponse();
            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Pedidos")
                .Options;
                using (var context = new ApplicationDbContext(options))
                {           
                    var find = context.Pedido.FirstOrDefault(i => i.pedido == item.pedido); 
                    var findItens = context.Itens.Where(i => i.idIPedido == item.pedido);  
                    result.pedido = item.pedido;

                    if (find == null)
                    {
                        result.status = "CODIGO_PEDIDO_INVALIDO";
                        result.statusCode = (int)HttpStatusCode.NotFound;   
                    }
                    else
                    {   
                        switch (item.status)
                        {
                        case "REPROVADO":
                            result.status = "REPROVADO";
                            break;
                        
                        case "APROVADO":
                           int valorTotalPedido = 0;
                           int valorTotalItems = 0;
                             List<Itens> itens = new List<Itens>();
                                if(findItens != null)
                                {
                                    foreach (var novoitem in findItens)
                                    {
                                        valorTotalPedido = valorTotalPedido + (novoitem.precoUnitario * novoitem.qtd);
                                        valorTotalItems = valorTotalItems + novoitem.qtd;
                                    }  
                                }
                            if(item.itensAprovados == valorTotalItems && item.valorAprovado == valorTotalPedido)
                            { 
                                result.status = "APROVADO";
                            }
                             else if(item.itensAprovados > valorTotalItems && item.valorAprovado > valorTotalPedido)
                            { 
                                result.status = "APROVADO_VALOR_A_MAIOR, APROVADO_QTD_A_MAIOR";
                            }
                            else if(item.valorAprovado > valorTotalPedido)
                            { 
                                result.status = "APROVADO_VALOR_A_MAIOR";

                            }
                            else if(item.valorAprovado < valorTotalPedido)
                            { 
                                result.status = "APROVADO_VALOR_A_MENOR";
                            }
                            else if(item.itensAprovados < valorTotalItems)
                            { 
                                result.status = "APROVADO_QTD_A_MENOR";
                            }                          
                            break;
                        }
                        result.statusCode = (int)HttpStatusCode.OK;                     
                    }
                }                 
            }
            catch (Exception)
            {
                result.statusCode = (int)HttpStatusCode.BadRequest;
            }

            return await Task.FromResult<StatusPedidoResponse>(result);

        }

        #endregion
        #region Methods
        #endregion
    }
}