![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![.Vscode](https://img.shields.io/badge/Made%20with-VSCode-1f425f.svg)
<img src="https://play-lh.googleusercontent.com/m0wKmUdoSnpwnhZpbin1gL7kzACIlq_s8QnqSS2RfR34GHw58OW1E1tbQ9RY7xgPqFA" width="140" 
height="140" align="right">

<br clear="left"/>

# Projeto Clima Tempo (Auvo Tecnologia) :computer:

Para este projeto não foi utilizado scaffolding (code first approach) pois o banco de dados e tabelas foram fornecidos com o enunciado do teste. O Docker foi utilizado para criar um container SQL Server, o script fornecido foi executado neste container gerando as tabelas.

O que foi finalizado até o momento:
- [x] As cidades mais frias e quentes do dia
- [x] Previsão do tempo dos próximos 7 dias da cidade selecionada
- [x] Uso do select2 (possibilidade de selecionar múltiplas cidades)
- [x] Uso do ajax para requisição assíncrona (evitar reloading da página)
- [ ] Criação de testes unitários
- [x] Uso do Entity Framework, data annotations para mapear os dados na tabela já existente
- [x] Uso Unity para injeção de dependência
- [x] Utilização de Partial Views
- [x] Utilização dos Html Helpers para chamada de actions
- [x] Commits feitos seguindo o padrão "Conventional Commits"

# Configuração
- Connection String: neste projeto a connection deve ser configurada no arquivo "connection.config". O nome padrão está como "DefaultConnection".

- Banco de dados: É necessário executar os scripts sql para geração do banco de dados. Primeiro executar o arquivo "create_database.sql" e depois o arquivo "create_tables.sql".

- Pacotes Nugets utilizados:
    - Entity Framework (Versão 6.44)
    - Unity (Versão 5.11.1)
    - Unity MVC5 (Versão 1.4.0)

# Utilização

1. fazer o download do código fonte deste projeto:
    ```
    git clone https://github.com/sidneyfrancois/ProjetoClimaTempo.git
    ```
2. Abrir a solution dentro da pasta do projeto "ProjetoClimaTempo.sln"

4. Executar Build

# Melhorias

- Aplicar Repository Patterns
- Inserção de mais camadas para diminuir quantidade de código no controller.
- Melhorar scripts para uso do select2
- Clean Architecture
- Remover ambiguidades de idioma no código (algumas variáveis e nomes de função estão em portugues enquanto outras estão em inglês)
- Bundle Config para maior performance do bootstrap e demais scripts