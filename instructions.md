# Introduction 
Esse projeto foi feito com um diferencial, utiliza o pattern Mediator (lib MediatR do .NET Core) em conjunto com o CQRS (Command Query Responsibility Segregation). Esse conceito é utilizado para separar a responsabilidade de escrita e leitura dos dados.

Basicamente temos dois componentes principais chamados de Request e Handler, que implementamos através das interfaces IRequest e IRequestHandler<TRequest> respectivamente.
Request → o que será processado (pode ter uma resposta/Response associada à ele usando a interface IRequest<TResponse>).
Handler → responsável por processar as mensagens.

Usando a interface IMediator as classes não irão saber quem/quais componentes irão realizar determinada ação. Apenas enviamos para o Mediator e ele irá se encarregar de chamar a classe que irá executar o que precisamos.
É possível ainda implementar o CancellationToken, que faz parte da biblioteca do Mediator para cancelar uma ação (aqui não implementado).

-----------------------Camadas do projeto-------------------------

BackEnd.API - Camada de API
Nessa camada temos as Controllers do projeto

BackEnd.Application - Camada de aplicação
Nessa camada temos os arquivos de CQRS - Request/Response/Command

BackEnd.CrossCutting - Camada comum por toda aplicação
Nessa camada temos arquivos de Injeção de Dependência para os services.

BackEnd.Infrastructure - Camada de infraestrutura
Nessa camada temos arquivos de acesso a dados (Entity Framework in memory)

BackEnd.UnitTest - Camada de testes
Para executar os testes unitários executar o comando:
dotnet test (dentro da pasta test/unit/backend.unittest)

# Build and Test
Endpoints:

http://localhost:5001/api/pedido

http://localhost:5001/api/status
