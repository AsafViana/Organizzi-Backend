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
    docker-compose exec api dotnet ef database update
    ```

4. **Acessar a aplicação**

    Acesse a aplicação em `http://localhost:80`.

### Configuração do Docker Compose

Aqui está a configuração do `docker-compose.yml` usada neste projeto:

```yaml
version: '3.9'

services:
  sql-service-db:
    container_name: sql-veniti
    image: mcr.microsoft.com/mssql/server:2019-latest
    ports: 
      - "1433:1433"
    environment:
      SA_PASSWORD: "Q!w2e3r4"
      ACCEPT_EULA: "Y"
    restart: always

  api:
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - "80:80"
    depends_on:
      - sql-service-db