# Simulador de Investimentos

📌 **Sobre o Projeto:**

O **Simulador de Investimentos** é uma aplicação que permite ao usuário simular o rendimento de diferentes tipos de investimentos (como Renda Fixa e Ações) ao longo do tempo. A aplicação foi construída utilizando uma arquitetura em camadas, com uma **Web API RESTful**, biblioteca de classes com regras de negócio, e integração com **banco de dados Oracle** utilizando o **Entity Framework Core**.

---

## 🧱 Estrutura da Solução

- **SimuladorInvestimentos.API** – Projeto principal com endpoints REST
- **SimuladorInvestimentos.Core** – Biblioteca com regras de negócio e modelos
- **SimuladorInvestimentos.Data** – Camada de persistência com EF Core e Oracle


## 🛠️ Tecnologias Utilizadas

- .NET 6+
- C#
- ASP.NET Core Web API
- Entity Framework Core
- Oracle (via `Oracle.EntityFrameworkCore`)
- Swagger / OpenAPI
- Git + GitHub

---

## 🔗 Endpoints da API

| Método | Rota                          | Descrição                                  | Status HTTP Esperado         |
|--------|-------------------------------|--------------------------------------------|-------------------------------|
| GET    | `/api/investimentos`          | Lista os tipos de investimentos            | 200 OK                        |
| POST   | `/api/investimentos/simular`  | Simula rendimento com valor e prazo        | 201 Created / 400 Bad Request |
| PUT    | `/api/investimentos/{id}`     | Atualiza informações do investimento       | 200 OK / 404 Not Found        |
| DELETE | `/api/investimentos/{id}`     | Remove um tipo de investimento             | 204 No Content / 404 Not Found|

---

## 🧪 Exemplo de Simulação (POST)

**Requisição:**
```json
POST /api/investimentos/simular
{
  "tipo": "RendaFixa",
  "valorInicial": 2550,
  "meses": 6
}

Resposta esperada:
{
  "valorFinal": 2830.47
}


## ⚙️ Como Rodar o Projeto

### 1. Clonar o Repositório

```bash
git clone https://github.com/seu-usuario/SimuladorInvestimentos.git
cd SimuladorInvestimentos

### 2. Configurar Banco Oracle

No arquivo `appsettings.json` do projeto `SimuladorInvestimentos.API`, edite a connection string conforme o seu ambiente:

```json
"ConnectionStrings": {
  "OracleConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=//localhost:1521/XEPDB1;"
}

### 3. Aplicar Migrations e Rodar

Execute os comandos abaixo para aplicar as migrations e iniciar a aplicação:

```bash
dotnet ef database update -p SimuladorInvestimentos.Data -s SimuladorInvestimentos.API
dotnet run --project SimuladorInvestimentos.API

### 4. Acessar a Documentação Swagger

Após iniciar a aplicação, acesse a documentação interativa da API via Swagger no navegador:

https://localhost:{porta}/swagger
