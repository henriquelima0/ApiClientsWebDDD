# 🏢 **ApiClientsDDD** 

Um projeto de **CRUD de Clientes** desenvolvido em **.NET Core** com arquitetura **DDD (Domain-Driven Design)**. Este repositório demonstra a implementação de um sistema simples de gerenciamento de clientes com endereços associados, utilizando **Entity Framework Core**, **AutoMapper**, e seguindo as melhores práticas de **DDD**.

<p align="center">
  <img src="https://img.shields.io/badge/.NET%20Core-5.0-blue" alt=".NET Core 8.0">
  <img src="https://img.shields.io/badge/Entity%20Framework-5.0-brightgreen" alt="Entity Framework">
  <img src="https://img.shields.io/badge/Architecture-DDD-important" alt="Domain Driven Design">
</p>

## 🎯 **Objetivo do Projeto**

Este projeto foi desenvolvido com o intuito de mostrar a aplicação prática dos conceitos de DDD (Domain-Driven Design) em um CRUD simples para **Clientes** e seus **Endereços**. O foco está na separação clara das camadas, uso de **AutoMapper** para mapeamento entre DTOs e entidades, e a persistência de dados com **Entity Framework Core**.

## 📚 **Principais Tecnologias**

- **.NET Core 5.0**
- **Entity Framework Core**
- **AutoMapper**
- **SQL Server** (para persistência de dados)
- **DDD (Domain-Driven Design)**

## 📂 **Arquitetura do Projeto**

O projeto foi organizado em camadas seguindo o padrão **DDD (Domain-Driven Design)**:

```bash
📦 ApiClientsDDD
 ┣ 📂 Application
 ┃ ┣ 📂 DTOs           # Data Transfer Objects
 ┃ ┣ 📂 Interfaces      # Interfaces de serviços
 ┃ ┣ 📂 Mappings        # AutoMapper Profile
 ┃ ┗ 📂 Services        # Lógica de aplicação
 ┣ 📂 Domain
 ┃ ┣ 📂 Models          # Entidades do domínio (Client, Address, etc.)
 ┃ ┣ 📂 ValueObjects    # Objetos de Valor (AddressType)
 ┃ ┗ 📂 Interfaces      # Interfaces de Repositório
 ┣ 📂 Infrastructure
 ┃ ┣ 📂 Data            # DbContext e configurações de banco de dados
 ┃ ┗ 📂 Repositories    # Implementações de repositórios
 ┣ 📂 Web               # Controllers e configuração da API
 ┗ README.md            # Documentação do projeto
