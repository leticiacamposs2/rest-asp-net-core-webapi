# CONTROLLERS 
Controller é muito importante para uma aplicação ASP .Net seja ela MVC ou WebAPI, a controller é a coluna servical da aplicação porque é através dela que você manipula o request recebido e devolve o response, faz o tratamento de todos os elementos dentro dela. Cerca de 90% do trabalho do desenvolvimento aproximadamente fica na controller e o resto na aplicação.

## Sumário

- [Anotações](#anotacoes)
- [Propriedades da ControllerBase](#propriedades-controller-base)
- [Rotas](#rotas)
- [Action Results e Formatadores de Respostas](#action-results)
- [Analisadores e Convenções](#analisadores-e-convencoes)

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

#### Exemplo do uso da ActionResult

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

![obter-todos](https://user-images.githubusercontent.com/34458509/123530690-ab945280-d6d3-11eb-87c7-727681c27a97.png)
![image](https://user-images.githubusercontent.com/34458509/123530696-bc44c880-d6d3-11eb-9661-8aa6c77041e4.png)

Quando se tem uma action e não especifica o tipo não é possível retornar o valor direto e sim no formato de uma action, exemplo:

```javascript
// ---- ERRADO ---- //

[HttpGet("obter-resultado")]
public ActionResult ObterResultado()
{
    var valores = new string[] { "value1", "value2" };

    if (valores.Length > 5000)
        return BadRequest();

    return valores;
}


// ---- CORRETO ---- //

[HttpGet("obter-resultado")]
public ActionResult ObterResultado()
{
    var valores = new string[] { "value1", "value2" };

    if (valores.Length > 5000)
        return BadRequest();

    return Ok(valores);
}
```

#### Modificadores de um método

No método POST temos o modificador **FromBody** que indica que o valor enviado vai vim dentro do corpo do request Http

```javascript
// POST teste
[HttpPost]
public void Post([FromBody] string value)
{
}
```

No método PUT temos o modificador **FromRoute** que indica que o valor enviado vai vim pela rota

```javascript
// PUT teste/5
[HttpPut("{id}")]
public void Put([FromRoute] int id, [FromBody] string value)
{
}
```

*(na versão 2.1 em diante não é necessário incluir o FromRoute se você tiver especificado dentro do metodo e receber um parametro com o mesmo nome)*

```javascript
// PUT teste/5
[HttpPut("{id}")]
public void Put(int id, [FromBody] string value)
{
}
```

No método PUT temos o modificador **FromForm** que indica que o valor enviado vai vim de um form utilizando o atributo FormData dentro do request

```javascript
// PUT teste/5
[HttpPut("{id}")]
public void Put(int id, [FromForm] string value)
{
}
```

Quando se recebe um tipo complexo não é necessário especificar FromBody

```javascript
// POST teste
[HttpPost]
public void Post(Product value)
{
}

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }
}
```

**Modificadores**

Modificador   | Descrição
--------- | ------
[FromQuery]	| Obtém valores da string de consulta.
[FromRoute]	 | Obtém valores dos dados da rota.
[FromForm]	 | Obtém valores de campos de formulário postados.
[FromBody]	 | Obtém valores do corpo da solicitação.
[FromHeader]	 | Obtém valores de cabeçalhos HTTP.
[FromService]	 | Terá valor injetado pelo resolvedor DI (Injeção de Dependências).

**Definindo respostas diferentes de acordo com o resultado**

Com o uso do `ProducesResponseType` vai ser resolvido o tipo, no meu caso ele vai resolver o tipo Product com o retorno de um status code 201 e caso não seja do tipo Product ele retorna um status code 400

```javascript
    //POST /teste
    [HttpPost]
    [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Post(Product product)
    {
        if (product.Id == 0) return BadRequest();

        // add no banco
        return CreatedAtAction("Post", product);
    }
```

Uma vantagem de usar o `ProducesResponseType` é que na hora de documentar usando o Swagger por exemplo ele já vai entender os tipos de retornos possíveis e o que ela devolve.

#### <a id="analisadores-e-convencoes" /> Analisadores e Convenções

- Para o análisador de código utilizado foi o pacote `Microsoft Asp Net Core Mvc Api Analyzers`;

Exemplo do funcionamento:

Nesta implementação, quando coloco erro 200

