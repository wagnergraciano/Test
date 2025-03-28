# Instruções para Executar o Projeto .NET (backend)

Este guia explica como executar o projeto em seu ambiente local.

## Pré-requisitos

Antes de rodar o projeto, você precisa garantir que as seguintes ferramentas estão instaladas:

- [SDK .NET](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)
- [Editor de código](https://code.visualstudio.com/) (Visual Studio Code ou Visual Studio)

## Passos para Executar o Projeto

### 1. Navegar até o Diretório do Projeto

```bash
cd TestAPI
```

### 2. Restaurar as Dependências
```bash
dotnet restore
```

### 3. Construir o Projeto
```bash
dotnet build
```

### 4. Rodar o Projeto
```bash
dotnet run
```

### Isso irá inicializar o WebAPI do backend, ficar atento com o endereço e a porta, ex: http://localhost:5000 para poder apontar o mesmo endereço na requisição no frontend

# Instruções para Executar o Projeto Angular (frontend)

Este guia explica como executar o projeto Angular em seu ambiente local.

## Pré-requisitos

Antes de rodar o projeto, você precisa garantir que as seguintes ferramentas estão instaladas:

- [Node.js](https://nodejs.org/) (versão 14.0 ou superior)
- [npm](https://www.npmjs.com/) (gerenciador de pacotes do Node.js)
- [Angular CLI](https://angular.io/cli) (ferramenta de linha de comando do Angular)
- Verificar se os endpoints (ex: http://localhost:5000) estão mapeados corretamente nos arquivos:
test-frontend\src\app\legislator\legislator.component.ts  (linha 19)
test-frontend\src\app\bill\bill.component.ts (linha 19)

### Verificando as versões instaladas:

Para verificar se o Node.js e npm estão instalados, você pode executar os seguintes comandos:

```bash
node -v
npm -v
```
### 1. Navegar até o Diretório do Projeto

```bash
cd test-frontend
```

### 2. Restaurar as Dependências
```bash
npm install
```

### 3. Rodar o Projeto
```bash
ng serve
```

### 4. Acessar aplicação no seu nagevador padrão
http://localhost:4200
