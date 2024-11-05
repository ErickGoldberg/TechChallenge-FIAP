# Tech Challeng - FIAP

## Technologies and practices
- .NET 8
- DDD
- Clean Architecture
- Entity Framework Core
- Padrao Repository
- Fluent Validation
- Middlewares


### Requisitos Funcionais
- Cadastro de contatos: permitir o cadastro de novos contatos, incluindo
nome, telefone e e-mail. Associe cada contato a um DDD correspondente
à região.
- Consulta de contatos: implementar uma funcionalidade para consultar e
visualizar os contatos cadastrados, os quais podem ser filtrados pelo DDD
da região.
- Atualização e exclusão: possibilitar a atualização e exclusão de contatos
previamente cadastrados.

### Requisitos Técnicos
- Persistência de Dados: utilizar um banco de dados para armazenar as
informações dos contatos. Escolha entre Entity Framework Core ou
Dapper para a camada de acesso a dados.
- Validações: implementar validações para garantir dados consistentes
(por exemplo: validação de formato de e-mail, telefone, campos
obrigatórios).
- Testes Unitários: desenvolver testes unitários utilizando xUnit ou NUnit.
