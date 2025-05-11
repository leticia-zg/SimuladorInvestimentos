# 💰 Simulador de Investimentos

## 📌 Sobre o Projeto

O **Simulador de Investimentos** é uma aplicação que permite ao usuário estimar o rendimento de diferentes tipos de investimentos ao longo do tempo.  
O usuário informa um valor inicial, um prazo e uma taxa de juros mensal, e o sistema calcula quanto o valor investido pode render ao longo dos meses.

O projeto utiliza uma arquitetura em camadas, com:

- API RESTful desenvolvida em ASP.NET Core
- Biblioteca de regras de negócio e modelos (Camada Core)
- Camada de persistência com Entity Framework Core e banco de dados Oracle

---

## 🧱 Estrutura da Solução

- **SimuladorInvestimentos.API** – Projeto principal com os endpoints REST
- **SimuladorInvestimentos.Core** – Contém modelos e lógica de negócio
- **SimuladorInvestimentos.Data** – Gerencia a persistência dos dados usando EF Core e Oracle

---

## 🛠️ Tecnologias Utilizadas

- [.NET 6+](https://dotnet.microsoft.com/)
- C#
- ASP.NET Core Web API
- Entity Framework Core
- Oracle (via `Oracle.EntityFrameworkCore`)
- Swagger / OpenAPI
- Git + GitHub

---

## 🔗 Endpoints da API

| Método | Rota                              | Descrição                                  | Status HTTP Esperado         |
|--------|-----------------------------------|--------------------------------------------|-------------------------------|
| POST   | `/api/investimentos/calcular`     | Simula o rendimento de um investimento     | 200 OK / 400 Bad Request      |

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

Resposta esperada (HTTP 200 OK):
{
  "valorFinal": 1061.52
}```

## ⚙️ Como Rodar o Projeto

### 1. Clonar o Repositório

```bash
git clone https://github.com/seu-usuario/SimuladorInvestimentos.git
cd SimuladorInvestimentos

### 2. Configurar o Banco de Dados Oracle

Edite o arquivo `appsettings.json` do projeto `SimuladorInvestimentos.API` com a sua string de conexão:

```json
"ConnectionStrings": {
  "OracleConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=//localhost:1521/XEPDB1;"
}

### 3. Aplicar Migrations e Iniciar a Aplicação

Execute os comandos abaixo no terminal para aplicar as migrations e iniciar o projeto:

```bash
dotnet ef database update -p SimuladorInvestimentos.Data -s SimuladorInvestimentos.API
dotnet run --project SimuladorInvestimentos.API

### 4. Acessar a Documentação Swagger

Após iniciar a aplicação, acesse no navegador:
```bash
https://localhost:{porta}/swagger

📌 Autor:
[Letícia Zago de Souza] – www.linkedin.com/in/letícia-zago-de-souza
