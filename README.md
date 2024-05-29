# Watermark-challenge - Funimage

Esse teste tem o objetivo de me ajudar a passar no processo seletivo da vaga de desenvolvedor Backend | Frontend. Segue abaixo algumas informações sobre como ele foi feito e como rodá-lo.

A linguagem escolhida para realizá-lo foi o C# com o auxílio do servidor de Asp.Net para rodar e fazer as requisições.

## Comandos para executar a aplicação

Certifique-se que você possui o sdk de desenvolvimento .NET para executar o servidor e os códigos em C#

```
  dotnet --version
```

Caso o SDK esteja baixado, será retornada a versão baixada na máquina (no meu caso é a versão 8.0.300)

Clone o projeto utilizando o comando 

```
	https://github.com/MatheusAlvesPereiraRosa/Watermark-challenge.git
```

Depois entre no projeto com seu terminal de escolha e o rode com o comando

```
	dotnet run
```

Após isso seu projeto ira compilar, gerar um arquivo bin e o servidor conseguirá responder a suas requisições

## A aplicação

O teste é composto por basicamente duas rotas, sendo elas:

### GET

```
	http://localhost:5271/api/home
```

### POST

```
	http://localhost:5271/api/images/watermark
```

body:

```
  {
    	"Base64Image": "Base64daImage",
	"WatermarkText": "Marca d'água",
    	"X": 0,
    	"Y": 0,
    	"FontSize": 24,
    	"Opacity": 200,
    	"R": 255,
    	"G": 0,
    	"B": 0
}
```

Ambas as rotas podem ser importadas via o arquivo "Funimage-challenge.postman_collection.json" na pasta "Postman" nos arquivos do projeto.

## Ferramentas para testar a API e observações

Utilizei bastante o site **https://www.base64decode.org/** para fazer o base64 das imagens, seja para criar um base64 inicial ou para extrair a imagem marcada retornada pela API.

Gravei um video tutorial do funcionamento da API disponivel pelo link **https://youtu.be/QbGb2yNYUsc**



