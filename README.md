![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/34ba006b-569e-4f6e-9bc1-17f1813de1c1)# FluxoCaixa
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
Após fazer o passo a passo acima, é só rodar a aplicação no Visual Studio. A solução já ira abrir os 3 projetos da pasta <b>1- Application</br>
<br>
![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/b577cf44-a847-4e58-9e3e-bb1813f91b99)
<br>
![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/9b2e9674-e43a-4c7c-96c6-792b076140a1)

#
<br>

## ✅ Funcionamento do sistema
<br>

## 1 - Execute o endpoint de Auth do microserviço de Caixa 
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/1389fee5-2992-4878-95cb-5803eabe6a5b)
<br>

Feito isso, copie o token gerado e cole no Authorize dos microserviços de Caixa e Consolidado.
<br>
<br>

![image](https://github.com/gustavoatwork/FluxoCaixa/assets/5661530/293ce110-ef8e-4d60-81a9-8073d3a34f65)




