# 📝 Reto Técnico Tekton - Arnold Ramirez

## 📌 Descripción General

Este proyecto implementa una API RESTful en .NET 9, aplicando patrones de arquitectura moderna y buenas prácticas de desarrollo, orientadas a mantenibilidad, escalabilidad y testabilidad.

Tiene 4 endpoints para: crear, actualizar, obtener por id y listar

## 🏗️ Patrones y Arquitectura Utilizada

### 1️⃣ Clean Architecture
- Separación estricta por capas: `Domain`, `Application`, `Infrastructure`, `Api`, `Tests`.
- Cada capa tiene su responsabilidad única y desacoplada.

### 2️⃣ CQRS (Command Query Responsibility Segregation)
- Separación de comandos (`CreateProductCommand`) y queries (`GetProductByIdQuery`) para operaciones de escritura y lectura.
- Implementado con `MediatR` como bus de mensajes.

### 3️⃣ Repository & Unit of Work
- Los repositorios encapsulan el acceso a datos (`ProductRepository`).
- El `UnitOfWork` controla la transacción y la persistencia de cambios.

### 4️⃣ Domain Driven Design (DDD)
- Uso de `ValueObjects` (`VOStatus`) para modelar comportamientos del dominio.
- Encapsulamiento de estados, evitando valores mágicos.

### 5️⃣ Dependency Injection
- Toda la configuración de dependencias es inyectada vía `Microsoft.Extensions.DependencyInjection`.

### 6️⃣ IMemoryCache
- Cache de estados (`StatusCache`) implementado con `IMemoryCache` y configuración dinámica de TTL vía `IOptionsMonitor<RZConfig>`.

### 7️⃣ External API Consumption
- El descuento es consultado externamente vía `IDiscountService` que consume `IHttpRequester`.

### 8️⃣ Testing Estratégico
- Pruebas de integración reales utilizando SQL Server local.
- Fixtures de test (`SqlServerFixture`) para levantar el contexto real de base de datos.
- Se probo la logica con el command para crear y query para obtener por id

---

## 🛠️ Tecnologías

- .NET 9
- C# 13
- MediatR
- Entity Framework Core
- SqlServer
- FluentAssertions
- xUnit
- HttpClientFactory
- IMemoryCache

---

## 🚀 Pasos para ejecutar el proyecto localmente

### 1. Instalar:
.Net SDK 9.0.300 y Microsoft.WindowsDesktop.App 9.0.5

### 2. Ejecutar los siguiente comandos

Add-Migration InitialCreate -Project Reto.Infrastructure -StartupProject Reto.Api
Update-Database

### 3. Levantar el proyecto.