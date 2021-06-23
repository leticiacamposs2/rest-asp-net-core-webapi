# REST

### Sumário

- [Protocolo HTTP](#protocolo-http)
- [REST vs SOAP](#rest-vs-soap)

### <a id="protocolo-http" /> Protocolo HTTP

O Protocolo HTTP é o marco principal da formação da Web que conhecemos hoje, tudo isso gira em torno de você conversar com o servidor através dos conceitos de **request** e **response**, ou seja, você faz um pedido ao **server** e ele te da uma resposta.

![cliente-server](https://user-images.githubusercontent.com/34458509/123019870-b84d3980-d3a7-11eb-8355-3d1fb6b9370f.png)

Entendendo melhor sobre request e response:

![request-response](https://user-images.githubusercontent.com/34458509/123019652-44ab2c80-d3a7-11eb-82cc-da99beece538.png)

#### {🌐} HTTP Request

- **VERB:** Tipo do método GET (obter), HEAD (obter sem corpo de resposta), POST (criar), PUT (alterar), DELETE (excluir), PATCH (atualizar)
- **URI:** Seu endereço na internet
- **VERSION:** Versão do protocolo HTTP 
- **REQUEST HEADER:** Cabeçalho da requisição (suas informações ex: estou no browser, sou windows, versão X, autenticação e etc)
- **REQUEST MESSAGE:** Informação de fato de acordo com o Verb utilizado

#### {🌐} HTTP Response

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

#### REST - Representation State Transfer

![rest](https://user-images.githubusercontent.com/34458509/123023563-f8171f80-d3ad-11eb-9db7-a3a3bd524029.png)

É o estado de representação do dado através da transferência, e este estado de representação é puramente texto e por isto torna o padrão REST tão interessante por ele ser leve. 
Olhando a imagem é possivel fazer a seguinte leitura: O cliente quer transferir dados (que vai na parte do body) e  isso é transmitido através do protocolo HTTP dentro de um envelope (request) - chamam de envelope por ele estar formato no padrão com cabeçalho, corpo e etc - e o servidor recebe a mensagem.

#### SOAP - Simple Object Access Protocol

![soap](https://user-images.githubusercontent.com/34458509/123024255-234e3e80-d3af-11eb-908e-f39666780d4a.png)

No caso do SOAP o cliente também transfere os dados via HTTP junto com o SOAP que é um padrão de formatação deste tipo de mensagem ele é baseado em XML e é bem verboso, parecido com o REST porém tem mais informações e dependendo da utilização a autenticação, transação e outras coisas que o protocolo SOAP faz, ele vai tornar a mensagem muito mais pesada porque o dado enviado não é representacional pois existe um envelope SOAP envelopando a própria mensagem e por ser baseado em XML a mensagem aumenta muito de tamanho.
O SOAP dominou o mercado no surgimento dos observables, microsoft wcf e outros, que quando surgiu o REST apresentando um modelo tão simples de representar a informação baseado em Json que é muito mais leve que o XML e etc, o mundo mudou. AS APis passaram a usar o REST e o SOAP continua sendo usado para outras situações talvez um pouco mais complexa que exiga mais padrões e transmissões nas informações que o SOAP consiga atender bem, porém, vem perdendo cada vez mais mercado.


