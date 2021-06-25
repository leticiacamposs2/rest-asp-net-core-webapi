# CONTROLLERS 
Controller é muito importante para uma aplicação ASP .Net seja ela MVC ou WebAPI, a controller é a coluna servical da aplicação porque é através dela que você manipula o request recebido e devolve o response, faz o tratamento de todos os elementos dentro dela. Cerca de 90% do trabalho do desenvolvimento aproximadamente fica na controller e o resto na aplicação.

### 📖 Anotações

- A Controller de uma WebAPI herda de uma ControllerBase diferente do MVC que herda apena de Controller
- ControllerBase é uma base de uma controller, ou seja, ela implementa apenas algumas funcionalidades da controller mas ela pode ser especializada implementando mais funcionalidades.
- A Controller do MVC herda da ControllerBase
- Apenas a ControllerBase por si própria não faz tudo o que precisamos e por isso é feito a implementação do atributo [ApiController] dessa forma ela complementa o que a ControllerBase oferece

#### Propriedades da ControllerBase

Nome   | Descrição
--------- | ------
ControllerContext	| Obtém ou define o ControllerContext.
HttpContext	 | Obtém o HttpContext para a ação em execução.
MetadataProvider	 | Obtém ou define o IModelMetadataProvider.
ModelBinderFactory	 | Obtém ou define o IModelBinderFactory.
ModelState		 | Obtém o ModelStateDictionary que contém o estado do modelo e a validação de associação de modelo.
ObjectValidator		 | Obtém ou define o IObjectModelValidator.
ProblemDetailsFactory		 | Obtém ou define o ProblemDetailsFactory.
Request		 | Obtém o HttpRequest para a ação em execução.
Response		 | Obtém o HttpResponse para a ação em execução.
RouteData		 | Obtém o RouteData para a ação em execução.
Url		 | Obtém ou define o IUrlHelper.
User		 | Obtém o ClaimsPrincipal para o usuário associado à ação em execução.


