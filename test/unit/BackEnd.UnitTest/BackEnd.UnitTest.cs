using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using BackEnd.Application.Command.Generic;
using Xunit;

namespace BackEnd.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void CreatePedido_InputPedido_ReturnOk()
        {
            List<itens> listaItens = new List<itens>();
            itens i = new itens ();
            i.descricao="Item A";
            i.precoUnitario = 10;
            i.qtd = 1;
            listaItens.Add(i);
            itens i2 = new itens ();
            i2.descricao="Item B";
            i2.precoUnitario = 5;
            i2.qtd = 2;
            listaItens.Add(i2);

            CancellationToken cancellationToken = new CancellationToken();
            CreatePedidoRequest item = new CreatePedidoRequest();
            item.pedido = "123456";
            item.itens = listaItens;

            CreatePedidoCommand createpedido = new CreatePedidoCommand();
            var response = createpedido.Handle(item, cancellationToken);

            Assert.Equal((int)HttpStatusCode.OK, (int)response.Result.statusCode); 
        }

        [Fact]
        public void Status_InputStatus_ReturnNotFound()
        {
            CancellationToken cancellationToken = new CancellationToken();

            StatusPedidoRequest statusItem = new StatusPedidoRequest();
            statusItem.pedido="11111111";
            statusItem.valorAprovado = 0;
            statusItem.itensAprovados = 0;
            statusItem.status = "REPROVADO";

            StatusPedidoCommand status = new StatusPedidoCommand();
            var response = status.Handle(statusItem, cancellationToken);

            Assert.Equal((int)HttpStatusCode.NotFound, (int)response.Result.statusCode); 
        }

        [Fact]
        public void Status_InputStatus_ReturnStatusReprovado()
        {
            CancellationToken cancellationToken = new CancellationToken();

            StatusPedidoRequest statusItem = new StatusPedidoRequest();
            statusItem.pedido="123456";
            statusItem.valorAprovado = 0;
            statusItem.itensAprovados = 0;
            statusItem.status = "REPROVADO";

            StatusPedidoCommand status = new StatusPedidoCommand();
            var response = status.Handle(statusItem, cancellationToken);

            Assert.Equal("REPROVADO", response.Result.status); 
        }
    }
}
