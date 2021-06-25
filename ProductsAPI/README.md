# ProductsAPI
Aplicação ASP .Net Core no modelo WebAPI

#### 📖 Anotações

- Por padrão a API será executada na URL `https://localhost:44393/weatherforecast`
- O arquivo `launchSettings.json` serve para definir os ambientes a serem trabalhados, portas da aplicação e etc
- A Controller herda de *ControllerBase* por ser um modelo mais simplificado de controller diferente do modelo MVC, justamente para deixar a API mais leve
- A Controller tem o decorador *ApiController* que recebe várias outras contribuições de uma controller para outra API
- O MVC e o WebAPI segue algumas convenções, por exemplo os métodos possui o nome dos verbos, desta forma o próprio nome do método já diz o método que ele trabalha
- FromBody significa que a informação está vindo do corpo da request e não do header
- Por padrão é sempre bom inserir o atributo com o tipo de verbo que ele aceita [HttpGet]
- O arquivo `appsettings.json` é onde se informa chaves de acesso, logs e etc, assim como definir chaves por tipo de ambiente
- O arquivo `Program.cs` é o inicio da aplicação, ela que contém o método main e cria o IWebHostBuilder que é a criação de um HOST para rodar essa aplicação setando o arquivo `Startup` que é o mais importante da aplicação, pois é ele que contém todas as configurações da aplicação
- O metodo `Configure` do arquivo `Startup`é aonde define os comportamentos para o ambiente, por exemplo: Se eu estiver em um ambiente de desenvolvimento se tiver um erro quero exibir uma página
