# Organizzi

## Descrição
Organizzi é um servidor ASP.NET que permite aos clientes divulgarem seus serviços e aos clientes deles atenderem serviços. Esta aplicação facilita a conexão entre prestadores de serviços e seus consumidores de maneira eficiente e organizada.

## Instalação e Execução

### Pré-requisitos
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [.NET SDK](https://dotnet.microsoft.com/download)

### Passos para Instalar e Rodar

1. **Clone o repositório**

    ```bash
    git clone https://github.com/usuario/organizzi.git
    cd organizzi
    ```

2. **Construir e iniciar os containers**

    ```bash
    docker-compose up --build
    ```

3. **Configurar o Banco de Dados**

    Em um novo terminal, execute o seguinte comando para aplicar as migrações do Entity Framework:

    ```bash
    docker-compose exec web dotnet ef database update
    ```

4. **Acessar a aplicação**

    Acesse a aplicação em `http://localhost:5000`.

Pronto! Agora sua aplicação Organizzi deve estar rodando em um container Docker com um banco de dados SQL Server configurado.

## Licença
Este projeto está licenciado sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.