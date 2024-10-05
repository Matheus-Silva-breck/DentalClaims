# DentalClaims API

## Objetivo do Projeto
Este projeto tem como objetivo fornecer uma API para gerenciamento de consultas odontológicas, permitindo que clínicas odontológicas e pacientes possam agendar, gerenciar e acompanhar consultas de forma eficiente.

## Escopo
- Gerenciamento de usuários (pacientes e dentistas)
- Agendamento de consultas
- Acompanhamento de tratamentos
- Previsão de consultas futuras

## Requisitos Funcionais
1. Cadastro e gerenciamento de usuários
2. Agendamento de consultas
3. Visualização de histórico de consultas
4. Atualização de status de consultas
5. Registro de tratamentos realizados

## Requisitos Não Funcionais
1. Segurança: Autenticação e autorização de usuários
2. Performance: Tempo de resposta inferior a 2 segundos
3. Disponibilidade: Sistema disponível 99.9% do tempo
4. Escalabilidade: Suporte a múltiplos usuários simultâneos

## Arquitetura
Este projeto utiliza Clean Architecture para manter o código organizado e desacoplado:

### Camadas
1. Domain
   - Entidades
   - Interfaces
   - Regras de negócio
2. Application
   - DTOs
   - Interfaces de serviços
   - Implementação de casos de uso
3. Infrastructure
   - Implementação de repositórios
   - Configuração de banco de dados
4. API
   - Controllers
   - Configuração da aplicação

## Como Executar
1. Clone o repositório
2. Configure a string de conexão no arquivo appsettings.json
3. Execute as migrações: `dotnet ef database update`
4. Execute o projeto: `dotnet run`

## Tecnologias Utilizadas
- .NET 6
- Entity Framework Core
- Oracle Database
- AutoMapper
