# AppCrud API

API RESTful desarrollada en ASP.NET Core Web API aplicando principios de Arquitectura Hexagonal/Clean Architecture, separación de responsabilidades y buenas prácticas de desarrollo.

El proyecto permite la gestión de productos mediante operaciones CRUD, incluyendo paginación, filtros dinámicos y validaciones.

---

# Tecnologías utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- Arquitectura Hexagonal
- Dependency Injection
- LINQ
- Git & GitHub

---

# Estructura del proyecto

```bash
AppCrud
│
├── Application
│   ├── DTOs
│   └── UseCases
│
├── Domain
│   ├── Entities
│   └── Interfaces
│
├── Infrastructure
│   ├── Persistence
│   └── Repositories
│
├── Presentation
│   ├── Controllers
│
└── Program.cs
```

---

# Arquitectura implementada

El proyecto sigue una arquitectura basada en separación de capas:

## Domain
Contiene:
- entidades
- contratos/interfaces
- reglas de negocio principales

## Application
Contiene:
- casos de uso
- DTOs
- lógica de aplicación

## Infrastructure
Contiene:
- Entity Framework Core
- repositorios
- acceso a datos
- persistencia SQLite

## Presentation
Contiene:
- controladores
- endpoints REST
- Swagger

---

# Características implementadas

## CRUD completo de productos

- Crear producto
- Obtener productos
- Obtener producto por ID
- Actualizar producto
- Eliminar producto

---

# Paginación

Endpoint soporta:

```bash
/api/products?Filter=all&Limit=10
```

---

# Filtros dinámicos

Soporta filtros por:

- all
- name
- category
- sku

Ejemplo:

```bash
/api/products?filter=category&query=Tecnologia&page=1&limit=10
```

---

# Respuestas estandarizadas

Todas las respuestas retornan:

```json
{
  "success": true,
  "message": "Mensaje",
  "statusCode": 200,
  "data": {}
}
```

---

# Validaciones implementadas

- SKU único
- Manejo de errores
- Validaciones básicas de paginación
- Respuestas HTTP correctas

---

# Seed de datos

La aplicación carga automáticamente 5 productos iniciales usando `HasData()` de Entity Framework Core.

---

# Ejecución del proyecto

## 1. Clonar repositorio

```bash
git clone https://github.com/MrStephen22/AppCrud.git
```

---

## 2. Entrar al proyecto

```bash
cd AppCrud
```

---

## 3. Restaurar dependencias

```bash
dotnet restore
```

---

## 4. Ejecutar migraciones

```bash
Update-Database
```

o:

```bash
dotnet ef database update
```

---

## 5. Ejecutar proyecto

```bash
dotnet run
```

---

# Swagger

Swagger estará disponible en:

```bash
https://localhost:{puerto}/swagger
```

---

# 📌 Endpoints principales

| Método | Endpoint | Descripción |
|---|---|---|
| GET | `/api/products` | Obtener productos |
| GET | `/api/products/{id}` | Obtener producto por ID |
| POST | `/api/products` | Crear producto |
| PUT | `/api/products/{id}` | Actualizar producto |
| DELETE | `/api/products/{id}` | Eliminar producto |

---

# Ejemplo de búsqueda con filtros

```bash
/api/products?filter=name&query=Mouse&page=1&limit=5
```

---

# Autor

Desarrollado por Esteban Sanabria como prueba técnica para evaluación de conocimientos en desarrollo backend con .NET.