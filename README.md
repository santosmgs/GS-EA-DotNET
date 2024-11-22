# GS-EnergyAwarenessDotNET

---

## Energy Awareness API

## Resumo do Projeto

**Energy Awareness** é uma API desenvolvida com .NET 8, projetada para calcular o consumo de energia de dispositivos eletrônicos, como geladeiras e ar-condicionados. Baseia-se na potência, horas de uso e dias de operação. A solução permite que os usuários calculem o consumo total de energia dos dispositivos cadastrados e o custo com base na tarifa de energia. O projeto integra autenticação via Firebase e utiliza um banco de dados Oracle para armazenar dados de usuários, dispositivos e consumo de energia.

## Solução do Projeto

O objetivo do projeto é fornecer uma plataforma onde empresas e consumidores possam monitorar e calcular o gasto energético dos seus dispositivos, otimizando o uso de energia. A API oferece funcionalidades como:

- **Cadastro e autenticação de usuários.**
- **Cadastro de dispositivos eletrônicos** (como geladeiras, ar-condicionados).
- **Registro de consultas** com o tempo de uso de dispositivos e a região.
- **Cálculo do consumo total de energia** com base na potência e no tempo de uso dos dispositivos.

### Funcionalidades Implementadas

- **Autenticação via Firebase.**
- **API RESTful** com endpoints para operações CRUD (Create, Read, Update, Delete).
- **Validações de dados** para garantir a consistência da entrada.
- **Swagger** para testes e documentação da API.

## Tecnologias Utilizadas

- **.NET 8**
- **Entity Framework Core**
- **Oracle Database**
- **Firebase Admin SDK** (para autenticação)
- **Swagger** (para documentação e testes)

## Bibliotecas Necessárias

Antes de rodar o projeto, instale as seguintes bibliotecas:

### Entity Framework Core (Oracle):

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.3
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.3
dotnet add package Oracle.EntityFrameworkCore --version 8.23.60
```

### Firebase Admin SDK:

```bash
dotnet add package FirebaseAdmin --version 2.5.0
dotnet add package Google.Apis.Auth --version 1.54.0
```

### Swagger (Swashbuckle.AspNetCore):

```bash
dotnet add package Swashbuckle.AspNetCore --version 6.0.10
```

### Autenticação JWT:

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 6.0.1
```

## Passo a Passo para Rodar o Projeto

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/SEU_USUARIO/GS-EnergyAwarenessDotNET.git
   ```

2. **Instale as dependências:** Navegue até a pasta do projeto e execute:

   ```bash
   dotnet restore
   ```

3. **Configure o arquivo `appsettings.json`:** Verifique se as credenciais do Firebase e a conexão com o banco Oracle estão corretamente configuradas.

4. **Executando o Projeto:** Para rodar o projeto, execute:

   ```bash
   dotnet run
   ```

   A API estará disponível em `http://localhost:5119`.

5. **Testando a API:**

   Abra o Swagger UI em `http://localhost:5119/swagger` e teste os endpoints de usuários, eletrônicos, consultas e valores.

## Endpoints da API

### Usuários:

- **GET** `/api/usuario`: Listar todos os usuários.
- **POST** `/api/usuario`: Criar um novo usuário.
- **GET** `/api/usuario/{id}`: Obter detalhes de um usuário.
- **PUT** `/api/usuario/{id}`: Atualizar um usuário.
- **DELETE** `/api/usuario/{id}`: Remover um usuário.

### Eletrônicos:

- **GET** `/api/eletronico`: Listar todos os dispositivos.
- **POST** `/api/eletronico`: Criar um novo dispositivo.
- **GET** `/api/eletronico/{id}`: Obter detalhes de um dispositivo.
- **PUT** `/api/eletronico/{id}`: Atualizar um dispositivo.
- **DELETE** `/api/eletronico/{id}`: Remover um dispositivo.

### Consultas:

- **GET** `/api/consulta`: Listar todas as consultas.
- **POST** `/api/consulta`: Criar uma nova consulta.
- **GET** `/api/consulta/{id}`: Obter detalhes de uma consulta.

### Valores:

- **GET** `/api/valor`: Listar todos os valores de potência.
- **POST** `/api/valor`: Criar um novo valor de potência.
- **GET** `/api/valor/consumo-total/{idUsuario}`: Obter o consumo total de um usuário.

## Testes e Validações

- **Swagger UI:** Todos os endpoints estão documentados e podem ser testados diretamente na interface do Swagger.
- **Validação de CPF:** Implementada para garantir que o CPF não seja duplicado.
- **Validação de entrada:** Verificação de campos obrigatórios e dados válidos.

## Autenticação JWT

Para autenticar um usuário e obter o JWT, faça um **POST** no endpoint `api/auth/login` com os dados do usuário:

```json
{
    "Email": "eaadmin@energy.com",
    "Password": "admin007"
}
```

O retorno será um token JWT, que você deve incluir no cabeçalho Authorization para acessar os endpoints protegidos:

```
Authorization: Bearer <seu-token-jwt>
```

## Conclusão

O **Energy Awareness API** é uma solução que calcula o consumo energético de dispositivos eletrônicos e oferece controle sobre o uso de energia. Com a integração com Firebase para autenticação e Oracle para armazenamento de dados, a aplicação fornece segurança, escalabilidade e facilidade de uso. O projeto foi desenvolvido para facilitar a monitorização do consumo energético e otimizar as operações de gestão de energia.

---

## Integrantes
