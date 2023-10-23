# API-IBGE - Documentação

API-IBGE é uma API para consulta de informações relacionadas a localidades do Brasil. Esta API oferece recursos para autenticação de usuários, consulta de cidades, estados e códigos do IBGE.

## Funcionalidades

A API-IBGE oferece as seguintes funcionalidades:

### Autenticação e Autorização

- Cadastro de E-mail e Senha
- Login com geração de Token JWT para autenticação de usuários

### CRUD de Localidade

- Criação, leitura, atualização e exclusão de localidades
- Localidades incluem: Código IBGE, Cidade e Estado

### Pesquisa

- Pesquisa por cidade
- Pesquisa por estado
- Pesquisa por código (IBGE)

### Boas Práticas da API

- Versionamento de API
- Padronização de código
- Documentação usando Swagger

## Documentação

A documentação completa da API pode ser encontrada no Swagger:
[Documentação da API](http://balta-ibge.esesistem.com.br/swagger/index.html)

## Configuração

Certifique-se de configurar as seguintes informações no projeto:

- **Conexão com o Banco de Dados**: A API requer uma conexão com um banco de dados apropriado. Certifique-se de configurar a string de conexão em `appsettings.json`.

- **Chave Secreta JWT**: A chave secreta usada para assinar os tokens JWT deve ser configurada corretamente em `appsettings.json`.

- **Políticas de Autorização**: Configure as políticas de autorização para controlar o acesso às diferentes partes da API com base nos papéis dos usuários.

## Uso

Você pode usar as rotas definidas na API para acessar as funcionalidades. Veja a documentação Swagger para obter detalhes sobre como usar cada endpoint.

Exemplo de solicitação de token JWT para autenticação:

```http
POST /api/v1/account/login
Content-Type: application/json

{
  "userName": "seu_nome_de_usuario",
  "password": "sua_senha"
}

## Autores

    Leandro Sobral
    Elanã Scarabeli
    Murilo Cavalcanti

## Licença

Este projeto está licenciado sob a Licença MIT - consulte o arquivo LICENSE para obter detalhes.
