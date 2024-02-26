# FuncionariosApp

O FuncionariosApp é um projeto Asp.Net API desenvolvido com Entity Framework, Code First e DDD – Domain Driven Design, que mantém os dados de um funcionário. 
Abaixo os seguintes ENDPOINTS / METHODS:

/api/Empresas
POST (Razão Social, Nome Fantasia e CNPJ)
PUT (Id Empresa, Razão Social, Nome Fantasia e CNPJ)
DELETE (Id Empresa)
GET (Id Empresa, Razão Social, Nome Fantasia, CNPJ e Data/Hora de Cadastro)

/api/Funcionarios
POST (Nome, Matrícula, CPF, Data de Admissão e Id Empresa)
PUT (Id Funcionário Nome, Matrícula, CPF, Data de Admissão e Id Empresa)
DELETE (Id Funcionário)
GET (IdFuncionário, Nome, Matrícula, CPF, Data de Admissão, Id Empresa e Data/Hora de Cadastro) .

## Estrutura do Projeto

O projeto está organizado em três camadas principais:

1. **Servicos:** Contém os controladores e modelos.

2. **Domínio:** Responsável pela lógica de negócios e pela definição das entidades do sistema.

3. **Infraestrutura:** Inclui a configuração do banco de dados, migrações e outros aspectos relacionados à infraestrutura do projeto.

## Configuração do Projeto

Para executar o projeto, siga os passos abaixo:

1. Altere a string de conexão na classe `DataContext` localizada na camada de Infraestrutura para refletir as configurações do seu banco de dados.

2. Execute o seguinte comando para aplicar as migrações e criar o banco de dados:
    ```bash
    update-database
    ```

## Pré-requisitos

Certifique-se de ter o Visual Studio 2022 instalado para executar o projeto.

## Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests para melhorar o projeto.



