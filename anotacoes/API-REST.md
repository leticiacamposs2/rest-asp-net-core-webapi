#### API-REST

Comandos

- Gerar uma migration: `Add-Migration Initial`
- No DBContext será a classe da minha conexão e configuro isso na Startup
- Criei a connectionString, coloquei em database o nome da solution (ProductsAPI)

```javascript
  "ConnectionStrings": {
    "ApiDbContext": "Server=(localdb)\\mssqllocaldb;Database=ProductsAPI;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

- Executei os comandos Install-Package EntityFramework, Install-Package Microsoft.EntityFrameworkCore.Tools, Add-Migration Initial, update-database
- Cria um controlador pelo add controller

### Escopo do Projeto

#### Camadas da arquitetura:

**🏛️ [CAMADA DE NEGÓCIOS]**
- Entidade de negócios (Fornecedor, Endereço, Produto)
  - As entidades possui regras, validações e etc e algum tipo de serviço nesse caso para o fornecedor 
  - Essas entidades nesse caso também representa uma tabela no banco de dados e se relacionam: Fornecedor e Endereço (1:1) / Fornecedor e Produtos (1:N)

