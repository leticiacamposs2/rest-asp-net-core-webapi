# REST

### Sumário

- [Protocolo HTTP](#protocolo-http)
  - [HTTP Request](#http-request)
  - [HTTP Response](#http-response)

- [REST vs SOAP](#rest-vs-soap)
  - [REST - Representation State Transfer](#rest)
  - [SOAP - Simple Object Access Protocol](#soap)

- [Arquitetura REST](#arquitetura-rest)
  - [Arquitetura REST em Microservices](#arquitetura-rest-microservices)

### <a id="protocolo-http" /> Protocolo HTTP

O Protocolo HTTP é o marco principal da formação da Web que conhecemos hoje, tudo isso gira em torno de você conversar com o servidor através dos conceitos de **request** e **response**, ou seja, você faz um pedido ao **server** e ele te da uma resposta.

![cliente-server](https://user-images.githubusercontent.com/34458509/123019870-b84d3980-d3a7-11eb-8355-3d1fb6b9370f.png)

Entendendo melhor sobre request e response:

![request-response](https://user-images.githubusercontent.com/34458509/123019652-44ab2c80-d3a7-11eb-82cc-da99beece538.png)

#### <a id="http-request" /> {🌐} HTTP Request

- **VERB:** Tipo do método GET (obter), HEAD (obter sem corpo de resposta), POST (criar), PUT (alterar), DELETE (excluir), PATCH (atualizar)
- **URI:** Seu endereço na internet
- **VERSION:** Versão do protocolo HTTP 
- **REQUEST HEADER:** Cabeçalho da requisição (suas informações ex: estou no browser, sou windows, versão X, autenticação e etc)
- **REQUEST MESSAGE:** Informação de fato de acordo com o Verb utilizado

#### <a id="http-response" /> {🌐} HTTP Response

- **RESPONSE CODE:** Resposta do servidor, ex: 200 (OK), 203 (Não permitido), 403 (Forbidden) e etc
- **HTTP VERSION:** Versão do protocolo HTTP 
- **RESPONSE HEADER:** Cabeçalho da requisição (se você passou uma autenticação ele vai devolver o seu cookie, um token e etc)
- **RESPONSE MESSAGE:** Informação solicitada

![visao-request-response](https://user-images.githubusercontent.com/34458509/123021013-ad93a400-d3a9-11eb-84cb-2cbe39433917.png)

#### {📚} Links de estudo:

- [An overview of HTTP](https://developer.mozilla.org/en-US/docs/Web/HTTP/Overview)
- [HTTP Messages](https://developer.mozilla.org/en-US/docs/Web/HTTP/Messages)

---

### <a id="rest-vs-soap" /> REST vs SOAP

Antes do padrão REST surgir e dominar o mercado existia uma padrão anterior chamado SOAP que não ficou pra trás, pois ainda é utilizado em algumas situações.

#### <a id="rest" /> REST - Representation State Transfer

![rest](https://user-images.githubusercontent.com/34458509/123023563-f8171f80-d3ad-11eb-9db7-a3a3bd524029.png)

É o estado de representação do dado através da transferência, e este estado de representação é puramente texto e por isto torna o padrão REST tão interessante por ele ser leve. 
Olhando a imagem é possivel fazer a seguinte leitura: O cliente quer transferir dados (que vai na parte do body) e  isso é transmitido através do protocolo HTTP dentro de um envelope (request) - chamam de envelope por ele estar formato no padrão com cabeçalho, corpo e etc - e o servidor recebe a mensagem.

#### <a id="soap" /> SOAP - Simple Object Access Protocol

![soap](https://user-images.githubusercontent.com/34458509/123024255-234e3e80-d3af-11eb-908e-f39666780d4a.png)

No caso do SOAP o cliente também transfere os dados via HTTP junto com o SOAP que é um padrão de formatação deste tipo de mensagem ele é baseado em XML e é bem verboso, parecido com o REST porém tem mais informações e dependendo da utilização a autenticação, transação e outras coisas que o protocolo SOAP faz, ele vai tornar a mensagem muito mais pesada porque o dado enviado não é representacional pois existe um envelope SOAP envelopando a própria mensagem e por ser baseado em XML a mensagem aumenta muito de tamanho.
O SOAP dominou o mercado no surgimento dos observables, microsoft wcf e outros, que quando surgiu o REST apresentando um modelo tão simples de representar a informação baseado em Json que é muito mais leve que o XML e etc, o mundo mudou. AS APis passaram a usar o REST e o SOAP continua sendo usado para outras situações talvez um pouco mais complexa que exiga mais padrões e transmissões nas informações que o SOAP consiga atender bem, porém, vem perdendo cada vez mais mercado.

---

### <a id="arquitetura-rest" /> Arquitetura REST

Se trata de criar um nível de abstração entre as APIs

![arquitetura-rest](https://user-images.githubusercontent.com/34458509/123025755-7b864000-d3b1-11eb-92d4-9b48c53a2d93.png)

Neste exemplo eu tenho 3 APIs, sendo a API A com a tecnologia Java, a API B usando a tecnologia .NET e a API C usando a tecnologia Node.JS e isso é possível porque elas trocam informações que são mensagens REST baseadas em HTTP que é baseado em texto, ou seja, a API A tem a sua lógica de negócio e persiste em MYSQL a API B também tem a sua lógica de negócio e persiste em SQL Server e a API C tem a sua lógica de negócio e persiste em MongoDB, basta a API se independente e cumprir o seu papel que ela irá abstrair um pedaço do seu negócio e entregar o negócio funcionando. Desta forma uma aplicação pode utilizar essa API ou várias aplicações pode utilizar a mesma API, sendo chamado pelo conceito de **programação distribuida** que é ter o seu negócio funcionando em pequenos pedaços.
Pode haver situações em que as APIs troquem informações umas com as outras, porém não serão dependentes uma das outras, elas vão trocar essas informações através de um barramento, de uma fila e etc de acordo com a definição de arquitetura.
Ao usar a arquitetura REST você diz justamente sobre como tudo funciona e sim que a sua lógica de negócio escrita na sua aplicação esta distribuida em APIs.

#### <a id="arquitetura-rest-microservices" /> Arquitetura REST em Microservices

O conceito de microserviços é uma arquitetura REST onde cada API tem uma responsabilidade pequena e bem definida, por isso o termo micro.

![arquitetura-rest-microservices](https://user-images.githubusercontent.com/34458509/123026867-44189300-d3b3-11eb-90fe-cbad6f22ce8a.png)

Serviço que faz uma unica coisa, por exemplo na imagem a figura a esquerda é uma representação de um modelo monolítico que dentro do hexágono contém tudo o que a aplicação faz e em volta tem as operações satélites (módulos) utilizando toda a lógica. Reforçando o modelo monolítico tem tudo concentrado em um único lugar e em volta fica os satélites (módulos) consumindo. Já no modelo de microserviços (figura a direita), cada pedaço do monolítico é quebrado em pequenos pedaços responsáveis e  cada API faz apenas uma coisa. Exemplo tem uma API que cuida dos passageiros, outra do gerenciamento do motorista, outra de pagamentos e etc, ao distribuir tudo isso em serviços pequenos onde cada um tem uma responsabilidade única e bem definida pode se dizer que tem uma estrutura de microserviços. Porém, pra ser considerado de fato um microserviço você tem que fazer a gestão de tudo isso, ou seja, garantir que eles não parem de funcionar, ser possível identificar quando algum serviço para, ser possível voltar, ter a comunicação bem definida se será por fila, barramentos e etc, sendo um assunto complexo assim como a sua implementação.
