# AuthService

Sistema de autenticação para deckbuilder pessoal baseado em Clean Architecture.

## 🎯 Objetivo do Serviço

O **AuthService** é um serviço de autenticação desenvolvido para fornecer funcionalidades de autenticação e autorização para aplicações de deckbuilder. O serviço oferece:

- Autenticação de usuários com JWT
- Gerenciamento de refresh tokens
- Hash seguro de senhas
- API REST para integração com outras aplicações

## 🏗️ Arquitetura - Clean Architecture

O projeto segue os princípios da Clean Architecture, organizando o código em camadas bem definidas:

### 📁 Estrutura de Pastas

```
src/
├── AuthService.Api/              # Camada de Apresentação
│   ├── Controllers/              # Controllers da API
│   ├── Program.cs               # Configuração da aplicação
│   └── appsettings.json         # Configurações
├── AuthService.Application/      # Camada de Aplicação
│   ├── Abstractions/            # Interfaces dos serviços
│   └── Auth/                    # Casos de uso de autenticação
├── AuthService.Domain/           # Camada de Domínio
│   ├── Common/                  # Entidades base
│   └── Users/                   # Entidades de usuário
└── AuthService.Infrastructure/   # Camada de Infraestrutura
    └── Persistence/             # Contexto do banco de dados
```

### 🔧 Papéis de Cada Projeto

#### **AuthService.Api** (Camada de Apresentação)
- **Responsabilidade**: Interface HTTP da API
- **Contém**: Controllers, configuração do Swagger, middleware
- **Dependências**: Application e Infrastructure

#### **AuthService.Application** (Camada de Aplicação)
- **Responsabilidade**: Casos de uso e regras de negócio da aplicação
- **Contém**: Interfaces de serviços, casos de uso de autenticação
- **Dependências**: Apenas Domain

#### **AuthService.Domain** (Camada de Domínio)
- **Responsabilidade**: Entidades e regras de negócio centrais
- **Contém**: Entidades, value objects, interfaces de domínio
- **Dependências**: Nenhuma (camada mais interna)

#### **AuthService.Infrastructure** (Camada de Infraestrutura)
- **Responsabilidade**: Implementações concretas e acesso a dados
- **Contém**: DbContext, repositórios, serviços externos
- **Dependências**: Application e Domain

## 🚀 Como Rodar a API Local

### Pré-requisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior
- [PostgreSQL](https://www.postgresql.org/download/) (versão 12 ou superior)

### Passos para Execução

1. **Clone o repositório**
   ```bash
   git clone <url-do-repositorio>
   cd APIGIT
   ```

2. **Configure o banco de dados**
   - Instale e configure o PostgreSQL
   - Crie um banco de dados chamado `AuthServiceDb`
   - Atualize a connection string em `src/AuthService.Api/appsettings.json` se necessário:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=AuthServiceDb;Username=seu_usuario;Password=sua_senha"
     }
   }
   ```

3. **Execute as migrações** (quando implementadas)
   ```bash
   cd src/AuthService.Api
   dotnet ef database update
   ```

4. **Execute a aplicação**
   ```bash
   cd src/AuthService.Api
   dotnet run
   ```

5. **Acesse a API**
   - API: `https://localhost:7000` ou `http://localhost:5000`
   - Swagger UI: `https://localhost:7000/swagger` ou `http://localhost:5000/swagger`

### Comandos Úteis

```bash
# Restaurar dependências
dotnet restore

# Compilar o projeto
dotnet build

# Executar testes
dotnet test

# Executar com hot reload
dotnet watch run --project src/AuthService.Api
```

## 🤝 Como Contribuir

### Padrões de Commit

Seguimos o padrão de commits convencionais com mensagens no imperativo:

```bash
# ✅ Bons exemplos
git commit -m "feat: adiciona autenticação JWT"
git commit -m "fix: corrige validação de senha"
git commit -m "docs: atualiza README com instruções de instalação"
git commit -m "refactor: melhora estrutura do AuthDbContext"

# ❌ Evitar
git commit -m "adicionado JWT"
git commit -m "correção de bugs"
git commit -m "WIP"
```

### Tipos de Commit
- `feat`: Nova funcionalidade
- `fix`: Correção de bug
- `docs`: Documentação
- `style`: Formatação, sem mudança de código
- `refactor`: Refatoração de código
- `test`: Adição ou correção de testes
- `chore`: Tarefas de manutenção

### Processo de Contribuição

1. **Commits Pequenos e Focados**
   - Faça commits frequentes com mudanças pequenas
   - Cada commit deve representar uma mudança lógica completa
   - Evite commits grandes com múltiplas funcionalidades

2. **Mensagens Descritivas**
   - Use o imperativo ("adiciona" ao invés de "adicionado")
   - Seja específico sobre o que foi alterado
   - Inclua contexto quando necessário

3. **Branch Strategy**
   ```bash
   # Criar branch para feature
   git checkout -b feature/autenticacao-jwt
   
   # Fazer commits pequenos
   git add .
   git commit -m "feat: adiciona interface IJwtService"
   
   # Push e criar PR
   git push origin feature/autenticacao-jwt
   ```

### Estrutura de Pull Request

- **Título**: Descritivo e no imperativo
- **Descrição**: Explicar o que foi implementado e por quê
- **Commits**: Pequenos e bem organizados
- **Testes**: Incluir testes quando aplicável

---

## 📋 Status do Projeto

- [x] Estrutura base da Clean Architecture
- [x] Configuração do DbContext
- [x] Interfaces de abstração
- [ ] Implementação dos repositórios
- [ ] Implementação dos serviços de autenticação
- [ ] Controllers da API
- [ ] Testes unitários
- [ ] Documentação da API
