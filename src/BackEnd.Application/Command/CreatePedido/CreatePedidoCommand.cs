using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BackEnd.CrossCutting.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Application.Command.Generic
{
    public class CreatePedidoCommand : IRequestHandler<CreatePedidoRequest, CreatePedidoResponse>
    {
        #region Properties
        #endregion
        #region Constructor
        public CreatePedidoCommand()
        {
        }
        #endregion
        #region IRequestHandler implementation

        public async Task<CreatePedidoResponse> Handle(CreatePedidoRequest item, CancellationToken cancellationToken)
        {
            CreatePedidoResponse result = new CreatePedidoResponse();
            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Pedidos")
                .Options;
                using (var context = new ApplicationDbContext(options))
                {           
                    var novoPedido = new Pedido
                    {
                        pedido = item.pedido
                    };

                    foreach (itens itemPedido in item.itens )
                    {
                        var novoItem = new Itens
                        {
                            idIPedido = item.pedido,
                            descricao = itemPedido.descricao,
                            qtd = itemPedido.qtd,
                            precoUnitario = itemPedido.precoUnitario
                        }; 
                         context.Itens.Add(novoItem);
                    }   
                    context.Pedido.Add(novoPedido);
                    context.SaveChanges();
                }   
                 result.mensagem = "Dados inseridos com sucesso";
                 result.statusCode = (int)HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.mensagem = "Houve um erro ao inserir os dados: " + ex.Message;
                result.statusCode = (int)HttpStatusCode.BadRequest;
            }

            return await Task.FromResult<CreatePedidoResponse>(result);
        }
        #endregion
        #region Methods
        #endregion
    }
}