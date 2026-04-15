## Gerenciamento de Veículos e Administradores (Minimal API)

[![.NET Version](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Database](https://img.shields.io/badge/MySQL-8.0+-4479A1?logo=mysql&logoColor=white)](https://www.mysql.com/)
[![Testing](https://img.shields.io/badge/Testing-MSTest-blue)](#)
[![Deployment](https://img.shields.io/badge/Deploy-AWS-FF9900?logo=amazonaws&logoColor=white)](#)

Uma aplicação **Back-end** robusta, escalável e de alta performance, desenvolvida sob o paradigma de **Minimal APIs do .NET 10**. O ecossistema foi projetado para o gerenciamento de frotas e controle de acessos (RBAC), implementando autenticação *Stateless* via **Tokens JWT** e provisionado em ambiente de produção na nuvem da **AWS**.

---

## 🎯 Escopo do Projeto

Este projeto foi desenvolvido como um desafio prático do bootcamp da **Digital Innovation One (DIO)**. O objetivo principal foi consolidar o ciclo de vida completo (*End-to-End*) de uma aplicação moderna: desde a modelagem do banco de dados relacional e arquitetura de rotas otimizadas, até a camada de segurança, cobertura de testes automatizados e a esteira de deploy em Cloud (Amazon Web Services).

---

## 🛠 Stack Tecnológica e Recursos

- **Core & Framework:** C# 13, .NET 10 (Arquitetura baseada em Minimal APIs)
- **Persistência & ORM:** Entity Framework Core (Abordagem *Code-First* e *Migrations*)
- **Database:** MySQL (Instância local para desenvolvimento e **Amazon RDS** para produção)
- **Segurança & Auth:** Autenticação e Autorização baseadas em Bearer JWT (JSON Web Tokens)
- **Documentação & Sandbox:** Swagger (Swashbuckle) estendido com suporte a esquemas de segurança (Authorize)
- **Testes Automatizados:** MSTest (Foco em Testes de Integração com ciclo de vida dinâmico de DB)
- **Infraestrutura / Cloud Computing:** AWS (Provisionamento em instâncias EC2 e banco gerenciado RDS)

---

## 🏗 Arquitetura e Features do Ecossistema

A aplicação adota o modelo enxuto de Minimal APIs para reduzir o *boilerplate code* (código repetitivo) tradicional dos *Controllers* do MVC, garantindo baixíssima latência no processamento de requisições HTTP e consumo reduzido de memória.

### Principais Implementações:

1. **Autenticação e Autorização (RBAC):**
   - Endpoint de *Sign-in* exclusivo para administradores.
   - Emissão de *payloads* JWT auto-contidos contendo tempo de expiração e *Claims* de escopo (Email e Perfil de acesso).

2. **Camada de Endpoints RESTful:**
   - Operações completas de **CRUD** (Create, Read, Update, Delete) mapeadas para as entidades `Veículos` e `Administradores`.
   - Rotas privadas protegidas por *Middlewares* de validação de token no *Header* de autorização.

3. **Inversão de Controle (IoC) e Injeção de Dependência (DI):**
   - Serviços de domínio (Ex: `AdministradorServico`, `VeiculoServico`) acoplados via contêiner nativo de DI do .NET, promovendo testabilidade e baixo acoplamento (SOLID).

---

## 🛡 Estratégia de Testes (Integração)

Visando a garantia de qualidade (QA) e prevenção de quebras em produção (regressões), o projeto conta com uma suíte isolada de testes de integração via **MSTest**.

- O ambiente de testes intercepta o `DbContexto` real através da injeção de dependência.
- Utiliza o método `EnsureCreated()` para recriar o esquema do banco de dados em tempo de execução de forma isolada, garantindo que as operações de escrita e leitura de teste não poluam a base persistente de desenvolvimento.

---

## ☁️ Cloud & DevOps (AWS)

A topologia de infraestrutura da aplicação está hospedada na Amazon Web Services:

- **Camada de Dados:** Migrada com sucesso para o **Amazon RDS**, usufruindo de rotinas de backup e alta disponibilidade automatizadas pela AWS.
- **Camada de Aplicação:** A API foi compilada e distribuída para uma instância **EC2**, configurada com mapeamento de portas para expor os serviços para a web de forma performática.
- **Segurança de Ambiente:** Chaves privadas (como a assinatura do JWT) e *strings* de conexão são injetadas estritamente via Variáveis de Ambiente, mitigando riscos de vazamento de credenciais no código-fonte.

---

## 👨‍💻 Autor

Desenvolvido por **Artur Silva** - Full Stack Developer & UI/UX Designer.  
Fique à vontade para contribuir abrindo *Issues* ou enviando *Pull Requests*!
