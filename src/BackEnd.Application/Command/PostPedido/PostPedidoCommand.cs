using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BackEnd.CrossCutting.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Application.Command.Generic
{   
    public class PostPedidoCommand : IRequestHandler<PostPedidoRequest, PostPedidoResponse>
    {
        private IHttpClientFactory HttpClientFactory { get; }
        #region Properties
        #endregion
        #region Constructor
        public PostPedidoCommand()
        {
        }
        #endregion
        
        #region IRequestHandler implementation
        public async Task<PostPedidoResponse> Handle(PostPedidoRequest item, CancellationToken cancellationToken)
        {
        PostPedidoResponse result = new PostPedidoResponse();
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
                       List<Itens> itens = new List<Itens>();
                        if(findItens != null)
                        {
                            foreach (var novoitem in item.itens)
                            {
                                Itens itempedido = new Itens ();
                                itempedido.descricao = novoitem.descricao;
                                itempedido.precoUnitario = novoitem.precoUnitario;
                                itempedido.qtd = novoitem.qtd;
                                context.Itens.Update(itempedido);
                            }  
                        }
                         context.Pedido.Update(find);
                         context.SaveChanges();
                        result.mensagem = "Pedido atualizado com sucesso";
                        result.statusCode = (int)HttpStatusCode.OK;                     
                    }
                }                 
            }
            catch (Exception ex)
            {
                result.mensagem = "Houve um erro ao atualizar os dados: " + ex.Message;
                result.statusCode = (int)HttpStatusCode.BadRequest;
            }

            return await Task.FromResult<PostPedidoResponse>(result);

        }

        #endregion
        #region Methods
        #endregion
    }
}