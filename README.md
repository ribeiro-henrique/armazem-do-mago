# Documentação da API do Armazém do Mago

Esta documentação descreve a API RESTful desenvolvida para o Armazém do Mago, que permite ao mago gerenciar seus itens mágicos. A API foi desenvolvida em .NET 6.0/7.0 e utiliza o Entity Framework Core como ORM. A aplicação é capaz de adicionar, remover, listar, atualizar e classificar os itens mágicos do mago.

## Configuração

### Pré-requisitos

- [.NET SDK 6.0 ou 7.0](https://dotnet.microsoft.com/download)
- Banco de dados (por exemplo, SQL Server, PostgreSQL, SQLite)

### Instalação

1. Clone o repositório GIT da aplicação:


2. Navegue até o diretório da aplicação:


3. Execute o aplicativo:


### Configuração do Banco de Dados

Para acessar o banco de dados, selecione a aba "view" no Visual Studio e clique em "Sql Server Object Explorer", ou execute o comando "Ctrl+j, Ctrl+s".

## Endpoints da API

A API possui os seguintes endpoints:

- `POST /api/items`: Adiciona um novo item mágico.
- `PUT /api/items/{id}`: Atualiza as informações de um item mágico existente.
- `GET /api/items`: Lista todos os itens mágicos.
- `DELETE /api/items/{id}`: Remove um item mágico.
- `GET /api/items/{itemName}/alert`: Verifica se o mago tem menos de 3 unidades de um item específico e retorna um alerta.
- `GET /api/items/sorted`: Lista os itens mágicos classificados por poder mágico, do mais poderoso ao menos poderoso.

## Autenticação

A API utiliza autenticação básica para acessar os endpoints. Certifique-se de fornecer as credenciais ao fazer chamadas à API.

## Estrutura do Banco de Dados

A aplicação utiliza um banco de dados para armazenar informações sobre os itens mágicos. A estrutura da tabela é a seguinte:

- Tabela `MagicItems`:
- `Id` (Chave Primária, Inteiro): Identificador único do item.
- `Nome` (Texto): Nome do item mágico.
- `Descrição` (Texto): Descrição do item mágico.
- `Quantidade` (Inteiro): Quantidade de unidades do item.
- `PoderMágico` (Inteiro): Valor que representa o poder mágico do item.

## Exemplos de Uso

Aqui estão alguns exemplos de como usar os endpoints da API:

### Adicionar um novo item

```http
POST /api/Magicitems
Content-Type: application/json

{
"nome": "Poção de Cura",
"descrição": "Cura instantaneamente ferimentos",
"quantidade": 5,
"poderMágico": 10
}
```

### Atualizar um item

```http
PUT /api/Magicitems/1
Content-Type: application/json

{
  "quantidade": 4
}
```

### Listar todos os itens

```http
GET /api/Magicitems
```

### Listar um item específico

```http
GET /api/Magicitems/2
```

### Remover um item

```http
DELETE /api/Magicitems/1


```

### Receber o alerta sobre o item

```http
DELETE /api/Magicitems/Alert/1


```
