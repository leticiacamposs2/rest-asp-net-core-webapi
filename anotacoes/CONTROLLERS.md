# CONTROLLERS 
Controller é muito importante para uma aplicação ASP .Net seja ela MVC ou WebAPI, a controller é a coluna servical da aplicação porque é através dela que você manipula o request recebido e devolve o response, faz o tratamento de todos os elementos dentro dela. Cerca de 90% do trabalho do desenvolvimento aproximadamente fica na controller e o resto na aplicação.

## Sumário

- [Anotações](#anotacoes)
- [Propriedades da ControllerBase](#propriedades-controller-base)
- [Rotas](#rotas)
- [Action Results e Formatadores de Respostas](#action-results)

## <a id="anotacoes" /> 📖 Anotações

- A Controller de uma WebAPI herda de uma ControllerBase diferente do MVC que herda apena de Controller
- ControllerBase é uma base de uma controller, ou seja, ela implementa apenas algumas funcionalidades da controller mas ela pode ser especializada implementando mais funcionalidades.
- A Controller do MVC herda da ControllerBase
- Apenas a ControllerBase por si própria não faz tudo o que precisamos e por isso é feito a implementação do atributo [ApiController] dessa forma ela complementa o que a ControllerBase oferece

#### <a id="propriedades-controller-base" /> Propriedades da ControllerBase

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

---

## <a id="rotas" /> Rotas

Assim como no MVC a Rota é feita da mesma maneira, sendo uma rota um atributo que recebe uma string que é o template.

![route-web-api](https://user-images.githubusercontent.com/34458509/123529561-e98b7980-d6c7-11eb-95a1-c615d601bf00.png)

Neste exemplo o atributo da rota é a própria controller, que neste caso é a "WeatherForecast"

![endpoint](https://user-images.githubusercontent.com/34458509/123529602-3d965e00-d6c8-11eb-8b52-1d465df174ac.png)

Também é possível especificar um template de rota

![endpoint-teste](https://user-images.githubusercontent.com/34458509/123529676-0b393080-d6c9-11eb-8307-d58f108a34ed.png)

Também é possível definir o tipo de dado que deverá ser lido

![tipo-de-dado](https://user-images.githubusercontent.com/34458509/123529691-4176b000-d6c9-11eb-8acf-f93a784a87f7.png)

**Outros tipos de sintaxes para definir o template de rota:**

- Definição dentro da rota

![template de rota no metodo](https://user-images.githubusercontent.com/34458509/123529722-7a168980-d6c9-11eb-917c-9912359c3c5b.png)

- Definição do tipo do método e rota no mesmo atributo

![tipo-metodo-rota](https://user-images.githubusercontent.com/34458509/123529754-eabda600-d6c9-11eb-9d82-836d0b87dfea.png)

*Ambos os casos são redundantes, já que no primeiro caso você pode eliminar o uso do Route

Caso deseje customizar a rota, por exemplo obter-por-id/5

![rota-obter](https://user-images.githubusercontent.com/34458509/123529826-a67ed580-d6ca-11eb-9465-adecdd57ae7a.png)

![result](https://user-images.githubusercontent.com/34458509/123529877-1c833c80-d6cb-11eb-8204-d51dd2276030.png)

Outra coisa interessante, que ao definir o tipo de dado que deve ser lido, se a aplicação não conseguir fazer o databind, ou seja, se definir que leia um int e recebo um string ao tentar converter essa string para um int e não for possível a aplicação já irá retornar por padrão erro 404 - Not Found

![not-found](https://user-images.githubusercontent.com/34458509/123529933-ac28eb00-d6cb-11eb-95c0-9a1b5de5e8da.png)

Caso não defina direto no atributo, será feito uma validação pelo tipo definido no parametro do método retornando erro 400 - Bad Request com uma mensagem padrão

![api](https://user-images.githubusercontent.com/34458509/123529985-20fc2500-d6cc-11eb-8019-b68e8adcdee5.png)
![erro](https://user-images.githubusercontent.com/34458509/123530000-40934d80-d6cc-11eb-8a55-3dcd098076db.png)

---

## <a id="action-results" /> Action Results e Formatadores de Respostas

- ActionResult é o resultado de uma Action, na minha aplicação eu a uso como um método da controller que diz que este método terá um ação como resultado.

**Exemplo do uso da ActionResult:**

Imagine que eu tenha 2 métodos o **ObterTodos** que utiliza o ActionResult e o método **ObterValores** que retorna direto o IEnumerable *(ambos vão funcionar)*.

```javascript
[HttpGet("obter-todos")]
public ActionResult<IEnumerable<string>> ObterTodos()
{
    var valores = new string[] { "value1", "value2" };

    return valores;
}

[HttpGet("obter-valores")]
public IEnumerable<string> ObterValores()
{
    var valores = new string[] { "value1", "value2" };

    return valores;
}
```

Porém em uma situação hipotética eu precise retornar um BadRequest se uma condição não for atendida. No método ObterValores não será possível porque um BadRequest não é do tipo IEnumerable já no método ObterTodos será possivel, por se tratar de uma ação.

```javascript
[HttpGet("obter-todos")]
public ActionResult<IEnumerable<string>> ObterTodos()
{
    var valores = new string[] { "value1", "value2" };

    if (valores.length < 5000)
        return BadRequest();

    return valores;
}
```

Outra coisa bacana de usar uma ActionResult é que eu posso retornar o meu resultado junto com o status code de sucesso

```javascript
[HttpGet("obter-todos")]
public ActionResult<IEnumerable<string>> ObterTodos()
{
    var valores = new string[] { "value1", "value2" };

    if (valores.length < 5000)
        return BadRequest();

    return Ok(valores);
}
```