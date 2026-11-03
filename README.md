# 🧁 KappukeekiApp

Sistema de gestão e pedidos para doceria/confeitaria especializada em cupcakes, desenvolvido em **C# Windows Forms** com **.NET 10**, **Entity Framework Core** e banco de dados local **SQLite**.

---

## 📋 Sobre o Projeto

O **KappukeekiApp** foi projetado para atender operações de balcão e gestão de cardápio de cupcakes, com controle de acesso baseado em cargos/setores, armazenamento seguro de credenciais e geração de códigos de retirada para clientes.

---

## ✨ Funcionalidades Principais

### 1. 🔐 Autenticação e Controle de Acesso (RBAC)
- **Login Seguro**: Validação de credenciais utilizando **Hash e Salt criptográfico (PBKDF2)**.
- **Sessão Global (`SessaoUsuario`)**: Mantém os dados e permissões do usuário logado durante o ciclo de vida do app.
- **Níveis de Permissão por Setor**:
  - **Nível 3 (Administração)**: Acesso completo ao sistema (cadastro de produtos, pedidos e gestão).
  - **Nível 2+**: Permissão para adicionar e editar novos sabores de cupcakes no catálogo.
  - **Nível < 2**: Acesso restrito (apenas realização de pedidos e consulta; campos de cadastro desabilitados).
- **Regra de Bloqueio**: Colaboradores marcados como desativados/demitidos têm o acesso bloqueado automaticamente no login.
- **Usuário Padrão (Seed)**: Criado automaticamente na primeira execução:
  - **E-mail:** `admin@kappukeeki.com`
  - **Senha inicial:** `admin123`

### 2. 🧁 Catálogo de Cupcakes
- Cadastro de cupcakes com:
  - Nome do produto
  - Preço unitário
  - Sabor da massa
  - Sabor do recheio
  - Disponibilidade imediata
- Listagem em tempo real via tabela (`DataGridView`).

### 3. 🛍️ Gestão de Pedidos de Balcão
- Seleção de cupcakes e quantidade.
- Associação a clientes de balcão ou clientes identificados.
- Geração automática de **código de retirada** (ex: `RET-5482`).
- Cálculo automático do valor total do pedido.
- Acompanhamento do status do pedido (padrão: `Em Preparo`).
- Listagem ordenada dos pedidos mais recentes com descrição detalhada dos itens.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET 10 - Windows Forms)
- **ORM:** Entity Framework Core 10 (`Microsoft.EntityFrameworkCore.Sqlite`)
- **Banco de Dados:** SQLite (`kappukeeki.db`)
- **Arquitetura:** Code-First com Migrations automáticas na inicialização

---

## 📁 Estrutura do Projeto

```text
KappukeekiApp/
│
├── Data/
│   └── AppDbContext.cs          # Contexto do EF Core e configuração do SQLite
├── Models/
│   ├── Pessoa.cs                # Entidade base de usuários (com hash e salt)
│   ├── Funcionario.cs           # Vínculo de funcionário e setor
│   ├── Cliente.cs               # Entidade de clientes
│   ├── Setor.cs                 # Setores da empresa com nível de permissão
│   ├── Cupcake.cs               # Modelo do produto cupcake
│   └── Pedido.cs                # Modelos de Pedido e ItemPedido
├── Services/
│   ├── AuthService.cs           # Regras de negócio de autenticação
│   ├── PasswordHelper.cs        # Geração e conferência de PBKDF2/Salt
│   └── SessaoUsuario.cs         # Controle estático da sessão logada
├── Migrations/                  # Histórico de migrações do banco de dados
├── Form1.cs                     # Tela principal (Catálogo e Pedidos)
├── LoginForm.cs                 # Tela de Login e validação
├── Program.cs                   # Ponto de entrada, migração e seed inicial
└── KappukeekiApp.csproj         # Configuração do projeto .NET
```

---

## 🚀 Como Executar o Projeto

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado ou Visual Studio 2022+ com suporte a .NET 10.

### Executando Localmente
1. Clone o repositório:
   ```bash
   git clone https://github.com/Pedro-Lanner/KappukeekiApp.git
   ```
2. Acesse a pasta do projeto:
   ```bash
   cd KappukeekiApp
   ```
3. Execute o aplicativo:
   ```bash
   dotnet run
   ```
4. Ao abrir a tela de login, utilize as credenciais padrão do administrador:
   - **E-mail:** `admin@kappukeeki.com`
   - **Senha:** `admin123`

---

## 📦 Como Gerar o Executável (.exe)

Para gerar uma versão autônoma (*Self-Contained*) que funciona em qualquer PC com Windows sem precisar instalar o .NET:

```powershell
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o ./publish
```
O arquivo `KappukeekiApp.exe` estará disponível dentro da pasta `publish/`.

---

## 📄 Licença
Distribuído sob licença livre para fins acadêmicos e de portfólio.
