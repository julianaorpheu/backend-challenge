
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BackEnd.CrossCutting.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BackEnd.Application.Command.Generic
{
    public class FindPedidoCommand : IRequestHandler<FindPedidoRequest, FindPedidoResponse>
    {
        #region Properties
        #endregion
        #region Constructor
        public FindPedidoCommand()
        {
        }
        #endregion
        #region IRequestHandler implementation

         public async Task<FindPedidoResponse> Handle(FindPedidoRequest item, CancellationToken cancellationToken)
        {
            FindPedidoResponse result = new FindPedidoResponse();
            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Pedidos")
                .Options;
                using (var context = new ApplicationDbContext(options))
                {           
                    var find = context.Pedido.FirstOrDefault(i => i.pedido == item.pedido); 
                   
                    var findItens = context.Itens.Where(i => i.idIPedido == item.pedido);  
                    
                    if (find == null)
                    {
                        result.mensagem = "Pedido não localizado";
                        result.statusCode = (int)HttpStatusCode.NotFound;
                    }
                    else
                    {
                        //se existir itens no pedido, adiciona na list de itens
                       List<itens> itens = new List<itens>();
                        if(findItens != null)
                        {
                            foreach (var novoitem in findItens)
                            {
                                itens itempedido = new itens ();
                                itempedido.id = novoitem.idItem;
                                itempedido.descricao = novoitem.descricao;
                                itempedido.precoUnitario = novoitem.precoUnitario;
                                itempedido.qtd = novoitem.qtd;
                                itens.Add(itempedido);
                            }
                        }
                        result.mensagem = "Pedido localizado com sucesso";
                         result.statusCode = (int)HttpStatusCode.OK;
                         result.id = find.id;
                         result.pedido = find.pedido;
                         result.itens = itens;
                    }
                }                 
            }
            catch (Exception ex)
            {
                result.mensagem = "Houve um erro ao localizar o pedido: " + ex.Message;
                result.statusCode = (int)HttpStatusCode.BadRequest;
            }

            return await Task.FromResult<FindPedidoResponse>(result);
        }
         #endregion
        #region Methods
        #endregion
    }
}