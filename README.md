# EtherumIntegration

Este é um exemplo de serviço que integra sua rede blockchain usando netherum com aplicações que não são Dapps

# Como configurar o projeto:

### 1. Instaleo visual studio

### 1. Substitua onde contém dados da sua rede blockchain e smart contract por dados reais

### 2. Instale as os pacotes perdidos do nuget

### 3. De play no projeto

# Requisição dos dados

A chamada é do tipo HTTP e deve ser feita pela url abaixo:

- Localhost:
  `http://localhost:5000/api`

# Endpoints:

- Add:
  `http://localhost:5000/api/add`
  
  Chamada do tipo POST, onde pode ser enviado um data para ser salvo na sua rede blockchain de acordo com seu smart contract

- Get:
  `http://localhost:5000/api/get`
  
  Chamada do tipo GET, onde pode ser recuperado um data para ser salvo na sua rede blockchain de acordo com seu smart contract

> Obs: Deve se ter um smart contract deployado em uma rede etherum

