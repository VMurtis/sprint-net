<div align="center">
  
  ![Badge .NET 8](https://img.shields.io/badge/.NET-8.0-blueviolet?style=for-the-badge&logo=dotnet)
  ![Badge EF Core 8](https://img.shields.io/badge/EF%20Core-8-blue?style=for-the-badge&logo=c-sharp)
  ![Badge Oracle](https://img.shields.io/badge/Oracle-Database-red?style=for-the-badge&logo=oracle)
  ![Badge Docker](https://img.shields.io/badge/Docker-Ready-blue?style=for-the-badge&logo=docker)
  ![Status](https://img.shields.io/badge/status-ativo-success?style=for-the-badge)

</div>

---
## ✍️ Autores

<div align="center">

| Nome | RM |
| :--- | :--- |
| **Vinicius Murtinho Vicente** | 551151 |
| **Lucas Barreto Consentino** | 557107 |
| **Gustavo Bispo Cordeiro** | 558515 |

</div>

---

## 🧭 Índice

1.  [**🎯 Sobre o Projeto**](#-sobre-o-projeto)
2.  [**✨ Funcionalidades Principais**](#-funcionalidades-principais)
3.  [**🏗️ Filosofia de Arquitetura**](#️-filosofia-de-arquitetura)
    -   [Decisões de Arquitetura](#-decisões-de-arquitetura)
4.  [**🛠️ Tech Stack**](#️-tech-stack)
5.  [**🗃️ Modelo de Dados**](#️-modelo-de-dados)
6.  [**🐳 Docker**](#-docker)
7.  [**🚀 Como Executar**](#-como-executar)
8. [**📖 Guia da API**](#-guia-da-api)
9. [**🔗Deploy No Render**](#-deploy-no-render)


---

## 🎯 Sobre o Projeto

> Esta API foi desenvolvida como parte de um **Challenge .NET**.  
O sistema possibilita o gerenciamento de **Usuários** e **Motos**, fornecendo operações CRUD completas, documentação interativa com Swagger, e implementando boas práticas como **HATEOAS** e **Rate Limiting**.

---

## ✨ Funcionalidades

- ✔️ CRUD de Usuários  
- ✔️ CRUD de Motos
- ✔️ CRUD de Filiais 
- ✔️ Relacionamento entre `Usuario`, `Moto`  `Filial` 
- ✔️ Validações com DataAnnotations (Email, CPF, Telefone, etc.)  
- ✔️ Documentação interativa com **Swagger**  
- ✔️ Suporte a **HATEOAS** nas respostas (`links` para navegação da API)  
- ✔️ Rate Limiting configurado  

---

## 🏗️ Arquitetura

Seguindo os princípios da **Clean Architecture**:



---


## 🛠️ Tech Stack

-   🌐 **Framework**: .NET 8
-   🗄️ **ORM**: Entity Framework Core 8
-   🐘 **Banco de Dados**: Oracle
-   📦 **Gerenciador de Pacotes**: NuGet

---



---



# Inicia a aplicação
dotnet run 
```

### Acessar a API

-   **URL Base da API**: `http://localhost:5215/swagger/index.html`


---

## 📖 Guia da API

A documentação interativa no Swagger é a fonte da verdade para todos os endpoints.

### Endpoints de `Filial`
| Método | Rota             | Descrição                 |
| :----- | :--------------- | :------------------------ |
| `GET`  | `/api/filial`    | Lista filiais (paginado). |
| `GET`  | `/api/filial/{id}`| Busca uma filial por ID. |
| `POST` | `/api/filial`    | Cria uma nova filial.     |
| `PUT`  | `/api/filial/{id}`| Atualiza uma filial.     |
| `DELETE`|`/api/filial/{id}`| Deleta uma filial.       |


### Endpoints de `Moto`
| Método | Rota                      | Descrição                    |
| :----- | :------------------------ | :-------------------------   |
| `GET`  | `/api/moto`               | Lista motos (paginado).      |
| `GET`  | `/api/moto/{id}`          | Busca uma moto por ID.       |
| `POST` | `/api/moto`               | Cria uma nova moto.          |
| `PUT`  | `/api/moto/{id}`          | Atualiza uma moto.           |
| `DELETE`|`/api/moto/{id}`          | Deleta uma moto.             |

### Endpoints de `Usuario`
| Método | Rota                   | Descrição                    |
| :----- | :--------------------- | :--------------------------- |
| `GET`  | `/api/usuario`         | Lista usuários (paginado).   |
| `GET`  | `/api/usuario/{id}`    | Busca um usuário por ID.     |
| `POST` | `/api/usuario`         | Cria um novo usuário.        |
| `PUT`  | `/api/usuario/{id}`    | Atualiza um usuário.         |
| `DELETE`|`/api/usuario/{id}`    | Deleta um usuário.           |

---


