# REST

### Protocolo HTTP

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
