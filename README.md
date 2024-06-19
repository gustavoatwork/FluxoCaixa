# FluxoCaixa
<br>

##  ✅Pré-requisitos
Antes de rodar a aplicação é necessário instalar:
-  [Docker](https://docs.docker.com/desktop/install/windows-install/)
-  [MySQL](https://dev.mysql.com/downloads/installer/)
-  [MongoDb](https://www.mongodb.com/try/download/community)
-  [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
-  [Dotnet 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
-  Visual Studio 2022
-  RabbitMQ
  
#
<br>

## ✅Instalando o ambiente da aplicação
<br>

## MySQL
Para o Mysql crie um usuário e senha <b> de preferência com permissão de admin </b>. E altere as configurações do appsettings, para os projetos das pastas:
<br>
![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/3e6c7f1d-0562-404f-adcf-105cd6638225)
<br>
![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/39b426c4-fd1d-4c33-b86a-6f2dd29557aa)

## MongoDb
O MongoDB deve ser criado com o usuário de rede. <b>Mas se quiser criar usuário e senha, altere o appsettings.</b>
<br>
![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/28385566-2a02-4890-bd02-c86b9ff64959)

## Docker
O Docker basta apenas baixar e rodar o executavel:
<a href="https://docs.docker.com/desktop/install/windows-install/">Link para baixar o Docker</a>

## RabbitMQ
Após instalar o docker, abra o prompt e execute o código abaixo para iniciar o RabbitMQ

```cmd
docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management
```

## Entity Framework Core Tools
Instale executando o código abaixo no prompt

```cmd
dotnet tool install --global dotnet-ef
```

#
<br>

## ✅Preparando o banco de dados MySQL
Abra o prompt na pasta do projeto <b>FluxoDeCaixa.Infra.Repository.Mysql</b>
<br>
![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/37483e97-ea89-4db3-8075-f8ffc54516ee)
<br>
![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/c284958e-1d25-4169-a397-86e151d36b68)

E execute o comando do entity framework
```cmd
dotnet ef --startup-project ../FluexoDeCaixa.Caixa.Api/ database update
```
#
<br>

## ✅ Rodando a aplicação
Após fazer o passo a passo acima, é só rodar a aplicação no Visual Studio. A solução já ira abrir os 3 projetos da pasta <b>1- Application</b>
<br>
![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/b577cf44-a847-4e58-9e3e-bb1813f91b99)
<br>
![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/9b2e9674-e43a-4c7c-96c6-792b076140a1)

#
<br>

## ✅ Arquitetura do Sistema
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/641dac9c-e35c-4d48-bfda-f56c03250a8c)


## ✅ Funcionamento do sistema
<br>

## 1 - Execute o endpoint Auth do microserviço de Caixa 
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/1389fee5-2992-4878-95cb-5803eabe6a5b)
<br>

Feito isso, copie o token gerado e cole no Authorize dos microserviços de Caixa e Consolidado. ![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/68e2ea9c-3afd-4f3f-a84f-74689cee6cd6)

<br>
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/293ce110-ef8e-4d60-81a9-8073d3a34f65)


## 2 - Execute o endpoint de Caixa do microserviço de Caixa 
<br>
Ele irá retornar o caixa. O caixa já foi criado ao rodar o update database.

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/d3ac3dc2-bc03-45d9-b01b-009d31206328)
<br>

<b>Copie o id do caixa, poís irá ser usado novamente</b>
<br>

```cmd
5c4a3177-785e-44c0-b21b-fc54ddb64976
```

## 3 - Execute o endpoint Lancamento do microserviço de Caixa 
<br>

Esse endpoint é responsável por criar uma lançamento de crédito ou débito no caixa. O dado é persistido no Mysql e também no MongoDB.
O microserviço de Consolidado é chamado por Facade, e carrega o histórico da transação no MongoDb.
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/f9af755a-5a7e-4efb-9a2c-e81247f1db48)
<br>

<b>Payload</b>
<br>

```json
{
  "caixaId": "5c4a3177-785e-44c0-b21b-fc54ddb64976",
  "descricao": "Credito X",
  "valor": 25.90,
  "tipoLancamento": 1
}
```
<br>

TipoLancamento = 1 - Crédito
<br>
TipoLancamento = 2 - Débito
<br>
<br>

<b>Dado da transação no MongoDB</b>
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/a69bae04-6562-4ab1-af30-cc7a3b2f1c57)
<br>

## 4 - Execute o endpoint Consolidado do microserviço de Consolidado
<br>
Esse endpoint é responsável por receber os parâmetros de consulta, para preparar os dados consolidados do caixa. Ele recebe os parâmetros, e manda uma mensagem para o RabbitMQ. O serviço <b>FluxoDeCaixa.Consolidado.RabbitMQ.Receiver</b> lê a mensagem, e deixa os dados consolidados preparados no MongoDb.
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/568a7bfa-91d5-44e0-acb1-d251f8acb670)

<b>Payload</b>
<br>

```json
{
  "messageId": "321d5ee7-a7b1-4264-a2d8-61575a78ddbf",
  "caixaId": "5c4a3177-785e-44c0-b21b-fc54ddb64976",
  "dataInicial": "2024-06-19",
  "dataFinal": "2024-06-19"
}
```
<br>

O parâmetro <b>messageId</b> pode ser qualquer Guid. E os campos de datas devem ser no padrão <b>yyyy-mm-dd</b>
<br>
<br>

<b>Mensagem recebida no serviço de receiver</b>
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/577771e5-297c-4fa3-a8fb-7c9034f51d55)


## 5 - Execute o endpoint Buscar do microserviço de Consolidado
<br>
Esse endpoint retorna os dados consolidados do caixa, de acordo com os parâmetros enviados para o RabbitMQ.
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/689bf1b3-9c48-4847-9b7b-20dd9fcb144f)
<br>

<b>Retorno do enpoint</b>
<br>
```
{
  "isSuccess": true,
  "errors": [],
  "data": {
    "messageId": "321d5ee7-a7b1-4264-a2d8-61575a78ddbf",
    "caixaId": "5c4a3177-785e-44c0-b21b-fc54ddb64976",
    "nomeCaixa": "Caixa1",
    "valorConsolidado": 343.77,
    "transacoes": [
      {
        "descricao": "Credito 1",
        "valor": 345.45,
        "tipoLancamento": 1,
        "dataCadastro": "2024-06-19T03:00:00Z"
      },
      {
        "descricao": "Credito 2",
        "valor": 99.99,
        "tipoLancamento": 1,
        "dataCadastro": "2024-06-19T03:00:00Z"
      },
      {
        "descricao": "Credito 3",
        "valor": 5.51,
        "tipoLancamento": 1,
        "dataCadastro": "2024-06-19T03:00:00Z"
      },
      {
        "descricao": "Credito 4",
        "valor": 17.78,
        "tipoLancamento": 1,
        "dataCadastro": "2024-06-19T03:00:00Z"
      },
      {
        "descricao": "Credito 5",
        "valor": 27.18,
        "tipoLancamento": 1,
        "dataCadastro": "2024-06-19T03:00:00Z"
      },
      {
        "descricao": "Credito 6",
        "valor": 134.88,
        "tipoLancamento": 1,
        "dataCadastro": "2024-06-19T03:00:00Z"
      },
      {
        "descricao": "Debito 1",
        "valor": 55.31,
        "tipoLancamento": 2,
        "dataCadastro": "2024-06-19T03:00:00Z"
      },
      {
        "descricao": "Debito 2",
        "valor": 3.23,
        "tipoLancamento": 2,
        "dataCadastro": "2024-06-19T03:00:00Z"
      },
      {
        "descricao": "Debito 3",
        "valor": 176.39,
        "tipoLancamento": 2,
        "dataCadastro": "2024-06-19T03:00:00Z"
      },
      {
        "descricao": "Debito 4",
        "valor": 77.99,
        "tipoLancamento": 2,
        "dataCadastro": "2024-06-19T03:00:00Z"
      },
      {
        "descricao": "Credito X",
        "valor": 25.9,
        "tipoLancamento": 1,
        "dataCadastro": "2024-06-19T03:00:00Z"
      }
    ],
    "dataRefInicial": "2024-06-19T03:00:00Z",
    "dataRefFinal": "2024-06-19T03:00:00Z",
    "dataConsolidado": "2024-06-19T09:07:53.842Z"
  }
}
```


<b>Dados consolidados no MongoDb</b>
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/23357d3c-aec5-4882-b503-871803d81abb)


