#### API-REST
- [Comandos](#comandos)
- [Escopo do Projeto](#escopo-do-projeto)

---

### 🤖 <a id="comandos" /> Comandos

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

---

### 💻 <a id="escopo-do-projeto" /> Escopo do Projeto

1. CAMADA DE NEGÓCIOS
- Entidade de negócios (Fornecedor, Endereço, Produto)
  - As entidades possui regras, validações e etc e algum tipo de serviço nesse caso para o fornecedor 
  - Essas entidades nesse caso também representa uma tabela no banco de dados e se relacionam: Fornecedor e Endereço (1:1) / Fornecedor e Produtos (1:N)

![Entidade](https://user-images.githubusercontent.com/34458509/129821766-0d21e2e5-d1bf-4008-b00d-3fedc87586a4.png)

2. FLUXO DA ARQUITETURA
- Leitura de dados através da Arquitetura:

![fluxo-de-leitura](https://user-images.githubusercontent.com/34458509/129826647-77162ad5-4472-4785-8168-8d4a9b78e0ce.png)

  Nesse exemplo o browser solicita através de um request (GET) para a API as informações do produto de ID 10, a API recebe o request e de forma automática vai acessar a base de dados através de um repositório (Existe uma classe de repositório que está implementada na camada de dados, porém ela esta injetada na API através de uma interface no construtor da controller, desta forma a API lê direto a camada de dados através de uma abstração e por ser uma leitura simples não é necessário passar pela camada de negócios, só passaria se tivesse alguma regra de negócio a ser considerada o que não é o caso). Nesta leitura é retornado uma entidade de negócio (delivery), porque o repositório converteu essa leitura em uma entidade através do EntityFramework e precisa devolver a entidade para o client.
  Não é uma boa prática expor as entidades de negócios, pelo risco de expor mais coisas do que deveria e muitas vezes o resultado retornado pode não ser apenas uma entidade e sim uma composição de entidades, nesse caso a idéia é retornar um dado de transformação ou seja um DTO ou simplesmente uma ViewModel (VM) que será uma model exibida na View de algum lugar, porém para transformar a entidade em uma view model é necessário passar por um outro processo que é feito através do AutoMapper.
  Uma vez que tem a ViewModel já mapeada com o produto (no caso) que obtive no banco a WebAPI transforma esse dado em JSON e a resposta para o client será um OK e serializer esse produto em JSON que é o objeto solicitado.


3. FLUXO DA GRAVAÇÃO


**Caso de Falha (cenário onde se obtém um problema na gravação):**

![gravacao2](https://user-images.githubusercontent.com/34458509/129828795-ca9e45bf-6191-4a7b-bd0e-3b1e6722d1aa.png)

 Pensando no método PUT a API vai receber o imput com um request que vai ter o Content-Type do tipo form-data (no caso de upload de imagem) e a API que está exposta vai ficar esperando receber uma ViewModel e ela vai transformar automaticamente, porém existe alguns desafios: No caso de uma imagem será necessário converter em base64 ou utilizar um outro artificio para receber uma imagem maior porque ao serializar um base64 de uma imagem muito grande pelo request não será possivel passar essa informação sendo necessário fazer uma streaming.
 
 Desafio: Receber esse input via API, transformar em ViewModel e converter isso em uma entidade, uma vez estando com a entidade em mãos (produto) será necessário envocar um método assincrono na camada de negócios e insere o produto, como a camada de negócios tem um fluxo e vai ser feito todo o processo de validação de regra de negócio subtendo essa entidade ao fluxo de forma a validar: persistência, se os dados foram preenchidos corretamente, se o valor inserido é aceitável, consulta no banco se aquele produto já não possui uma cópia similar e faz o que for necessário e caso encontre algum problema deverá ser lançado EVENTOS e não uma exception, os eventos estarão atrelados ao request sendo válido apenas durante a requisição e esses eventos deverão ser um eventos de erro, guardando cada erro encontrado ou seja, será possivel ter diversos eventos de erros um para a imagem, oturo para o produto e assim por diante. De forma que esses eventos fiquem a disposição da API, quando a camada de negócios terminar a validação encontrando erros ela não deverá notificar a API informando que tem erros e simplesmente por ter sido chamada de forma assincrona vai ter um await esperando, que será informando que o processamento foi finalizado e a camada de API terá a inteligência de verificar na lista de eventos se existe algum evento de erro e uma vez que esse evento for localizado será serializado esses eventos para serem enviados para o client. Ou seja, será implementado um nível de abstração onde os erros serão apresentados através de eventos sem a necessidade de ficar retornando tipos desssa forma a camada de aplicação vai ter acessos aos eventos de erros de qualquer camada e devolve para o client um BAD REQUEST 
 
**Caso de Sucesso (cenário onde se obtém sucesso na gravação):**

![gravacao3](https://user-images.githubusercontent.com/34458509/129829353-310d43ef-76ab-4394-9050-69e91c23c971.png)

  Segue o mesmo fluxo acima, só que a informação será gravada no banco, a camada de negócios vai terminar esse processo que envolve a atualização no banco de dados e vai informar a API que terminou a API vai obter a lista de eventos para verificar se teve algum erro e no caso de não encontrando erros ela irá pegar esse produto do qual foi persistido na base e que já possui visto que recebeu via input e irá serializar e devolver para o client através de um response com o código 200.
