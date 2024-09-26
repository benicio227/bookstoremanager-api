## Sobre o projeto

Este projeto foi desenvolvido como parte de um desafio prático, onde o objetivo principal foi criar uma **API** para uma livraria online, permitindo aos usuários gerenciar um catálogo de livros de forma eficiente. A **API** suporta operações de **CRUD(Criar, Ler, Atualizar e Deletar)** e foi estruturada seguindo boas práticas de desenvolvimento, incluindo o uso de padrões de **arquitetura em camadas**.

Dentre os pacotes NuGet utilizados, o **AutoMapper** é o responsável pelo mapeamento entre objetos de domínio e requisição/resposta, reduzindo a necessidade de código repetitivo e manual. O **FluentAssertions** é utilizado nos testes de unidade para tornar as verificações mais legíveis, ajudando a escrever testes claros e compreensíveis. Para as validações, o **FluentValidation** é usado para implementar regras de validação de forma simples e intuitiva nas classes de requisições, mantendo o código limpo e fácil de manter. Por fim, o **EntityFramework** atua como um ORM(Object-Relational Mapper) que simplifica as interações com o banco de dados, permitindo o uso de objetos **.NET** para manipular dados diretamente, sem a necessidade de lidar com consultas SQL.

### Features

- **Domain-Driven Design (DDD)**: Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
- **Testes de Unidade**: Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade.
- **RESTful API com Documentação Swagger**: Intterface documentada que facilita a integração e o teste por parte dos desenvolvedores.

## Getting Started

Para obter uma cópia local funcionando, siga estes passos simples.

### Requisitos

* Visual Studio versão 2022+ ou Visual Studio Code
* Windows 10+ ou Linux/MacOS com [.NET SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) instalado
* MySql Server

## Instalação

1. Clone o repositório:
    ```sh
    git clone git@github.com:benicio227/bookstoremanager-api.git
    ```
2. Preencha as informações no arquivo `appsettings.Development.json`.
3. Execute a API e aproveite o seu teste
