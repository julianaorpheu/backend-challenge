
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BackEnd.CrossCutting.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Application.Command.Generic
{
    public class DeletePedidoCommand : IRequestHandler<DeletePedidoRequest, DeletePedidoResponse>
    {
        #region Properties
        #endregion
        #region Constructor
        public DeletePedidoCommand()
        {

        }
        #endregion
        #region IRequestHandler implementation

         public async Task<DeletePedidoResponse> Handle(DeletePedidoRequest item, CancellationToken cancellationToken)
        {
          DeletePedidoResponse result = new DeletePedidoResponse();
            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Pedidos")
                .Options;
                using (var context = new ApplicationDbContext(options))
                {           
                    var excluir = context.Pedido.FirstOrDefault(i => i.pedido == item.pedido); 
                    var excluirItens = context.Itens.Where(i => i.idIPedido == item.pedido);  
                    
                    if (excluir == null)
                    {
                        result.mensagem = "Pedido não localizado";
                        result.statusCode = (int)HttpStatusCode.NotFound;
                    }
                    else
                    {
                        //remove item ou itens associados ao pedido, se houver
                        if(excluirItens != null)
                        {
                            foreach (var i in excluirItens)
                            { 
                                context.Itens.Remove(i);
                            }
                        }
                        context.Pedido.Remove(excluir);
                        context.SaveChanges(); 
                        result.mensagem = "Dados deletados com sucesso";
                        result.statusCode = (int)HttpStatusCode.OK;
                    }
                }                 
            }
            catch (Exception ex)
            {
                result.mensagem = "Houve um erro ao deletar os dados: " + ex.Message;
                result.statusCode = (int)HttpStatusCode.BadRequest;
            }

            return await Task.FromResult<DeletePedidoResponse>(result);

        }
         #endregion
        #region Methods
        #endregion
    }
}