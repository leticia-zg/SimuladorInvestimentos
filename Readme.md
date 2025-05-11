# 💰 Simulador de Investimentos

## 📌 Sobre o Projeto

O **Simulador de Investimentos** é uma aplicação que permite ao usuário estimar o rendimento de diferentes tipos de investimentos ao longo do tempo.  
O usuário informa um valor inicial, um prazo e uma taxa de juros mensal, e o sistema calcula quanto o valor investido pode render ao longo dos meses.

O projeto utiliza uma arquitetura em camadas, com:

- API RESTful desenvolvida em ASP.NET Core
- Biblioteca de regras de negócio e modelos (Camada Core)
- Camada de persistência com Entity Framework Core e banco de dados Oracle

---

## 🔗 Rotas da API

| Método | Rota                          | Descrição                                  | Status HTTP Esperado         |
|--------|-------------------------------|--------------------------------------------|-------------------------------|
| GET    | `/api/investimentos`          | Lista os tipos de investimentos            | 200 OK                        |
| GET    | `/api/investimentos/{id}`     | Retorna um investimento específico pelo ID | 200 OK / 404 Not Found        |
| POST   | `/api/investimentos`          | Cria um novo investimento                  | 201 Created / 400 Bad Request |
| PUT    | `/api/investimentos/{id}`     | Atualiza informações do investimento       | 200 OK / 400 Bad Request / 404 Not Found |
| DELETE | `/api/investimentos/{id}`     | Remove um tipo de investimento             | 204 No Content / 400 Bad Request / 404 Not Found |

---

## 📋 Pré-requisitos

- .NET SDK 6.0 ou superior
- Banco de dados Oracle configurado

---

## ⚙️ Como Instalar e Rodar o Projeto

### 1. Clonar o Repositório

Clone o repositório do projeto para sua máquina local:

### 2. Configurar o Banco de Dados Oracle

Edite o arquivo `appsettings.json` do projeto `SimuladorInvestimentos.API` com a sua string de conexão:

```json
"ConnectionStrings": {
  "OracleConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=//localhost:1521/XEPDB1;"
}
```

### 3. Aplicar Migrations e Iniciar a Aplicação

Execute os comandos abaixo no terminal para aplicar as migrations e iniciar o projeto:

```bash
dotnet ef database update -p SimuladorInvestimentos.Data -s SimuladorInvestimentos.API
dotnet run --project SimuladorInvestimentos.API
```

### 4. Acessar a Documentação Swagger

Após iniciar a aplicação, acesse no navegador:
```bash
https://localhost:{porta}/swagger
```

---

### ✅ Exemplo de Requisição e Resposta

**Requisição:**

```http
POST /api/investimentos/calcular
Content-Type: application/json

{
  "nome": "",
  "valorInicial": 1000,
  "prazoMeses": 6,
  "taxaJurosMensal": 0.01
}
```

Resposta esperada (HTTP 200 OK):
```http
{
  "valorFinal": 1061.52
}
```

---

📌 Autor:
[Letícia Zago de Souza] – www.linkedin.com/in/letícia-zago-de-souza
