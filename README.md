# 📦 DELYPORT - Plataforma Logística y Cotizador

¡Bienvenido a **DELYPORT**! Este proyecto es una solución integral (Backend + Frontend) diseñada para gestionar la logística, cotización y asignación de servicios de entrega de mercancías, partiendo siempre desde un punto de origen centralizado.

Desarrollado con arquitectura moderna, utilizando **ASP.NET Core Web API** para un backend robusto y una interfaz gráfica estilizada en Vanilla JS.

---

## 🚀 Características Principales

- **Dashboard del Operador (UI Moderna):** Interfaz gráfica intuitiva con estilo *Glassmorphism* que permite al operador administrar todo desde un solo lugar.
- **Cotizador Multi-Producto:** Algoritmo dinámico que permite añadir "N" cantidad de productos por solicitud (Pequeños, Medianos y Grandes) sumando tarifas de envío basadas en distritos del cliente (Callao, Comas, Santa Anita, etc.).
- **Flujo de Trabajo Automatizado (Workflow):** Aprobación de cotizaciones con un solo clic. Una vez que la solicitud es aprobada, el sistema genera automáticamente un **Servicio Asignado** estableciendo su punto de partida en el "Almacén Central Santa Anita".
- **Historial Global en Tiempo Real:** Monitorización de todas las rutas de la flota, el conductor encargado y sus respectivos estados (Pendiente, En Proceso, Completado).
- **Backend Escalable:** API REST construida bajo principios de inyección de dependencias (DI) y separación de responsabilidades.
- **Persistencia Ligera:** Uso de **SQLite** a través de **Entity Framework Core (Code-First)** para garantizar un arranque rápido y portabilidad.

---

## 🛠️ Stack Tecnológico

| Tecnología | Descripción |
| :--- | :--- |
| **.NET (C#)** | Framework base para la API REST (Soporte .NET 8 / .NET 10) |
| **Entity Framework Core**| ORM utilizado para interactuar con la Base de Datos bajo el enfoque Code-First |
| **SQLite** | Base de Datos relacional, liviana y embebida |
| **HTML5 / CSS3 / JS** | Frontend interactivo y responsivo servido a través del middleware estático `wwwroot` |

---

## 📂 Estructura del Proyecto

```text
DELYPORT/
├── Delyport.Api/                 # Proyecto Principal Backend (.NET)
│   ├── Controllers/              # Controladores REST API (Solicitudes, Asignaciones)
│   ├── Data/                     # Contexto de Base de Datos y Seed Data (Data Inicial)
│   ├── Migrations/               # Archivos de Migración (EF Core)
│   ├── Models/                   # Entidades (DB) y Data Transfer Objects (DTOs)
│   ├── Services/                 # Capa de Lógica de Negocio (Cotizador, Asignación)
│   └── wwwroot/                  # Carpeta de Frontend (HTML, CSS, JS estático)
└── README.md                     # Documentación del Proyecto
```

---

## ⚙️ Instalación y Ejecución Local

Dado que la aplicación cuenta con un middleware para servir archivos estáticos (`app.UseStaticFiles()`), puedes correr tanto el backend como la interfaz web en un solo paso.

### 1. Requisitos Previos
- Instalar **.NET SDK** (Versión correspondiente a tu compilación, ej. .NET 8 o superior).
- Visual Studio 2022 o VS Code.
- *Opcional:* Tener las EF Core Tools (`dotnet tool install --global dotnet-ef`).

### 2. Clonar y Compilar
Abre una terminal (PowerShell o CMD) y ejecuta:
```bash
git clone https://github.com/Faus-DTA/DELYPORT.git
cd DELYPORT/Delyport.Api
dotnet build
```

### 3. Base de Datos (Opcional si ya existe SQLite)
El proyecto ya incluye código para inyectar datos falsos (10 Servicios Asignados de prueba) en `ApplicationDbContext.cs`. Para aplicar las últimas actualizaciones a la base de datos, corre:
```bash
dotnet ef database update
```

### 4. Iniciar Servidor (Con bypass de Antivirus si aplica)
A veces en entornos restringidos el comando `run` bloquea el `.exe`. Puedes iniciar de forma segura llamando directamente a la librería compilada:
```bash
dotnet bin\Debug\net10.0\Delyport.Api.dll
```

### 5. Explorar la Web
Abre tu navegador y dirígete a:
**`http://localhost:5276/`** *(El puerto exacto aparecerá en la consola una vez que inicies la API)*

---

## 📖 Guía de Uso del Sistema

1. **Cotizar Envíos:** Ve a la pestaña **Solicitudes**. Da clic en "+ Nueva Solicitud". Selecciona un distrito, añade múltiples productos y sus tamaños. El sistema te mostrará el precio total a cobrar.
2. **Aprobar una Carga:** Una vez cotizado, presiona **"✅ Aprobar"** en la tabla. Verás cómo el sistema la envía hacia el equipo de logística.
3. **Validar la Operación:** Ve a **Historial de Carreras**, y verás tu nueva solicitud transformada en un viaje real, con conductor asignado (Código ficticio) y punto de partida programado en "Almacén Central Santa Anita".
4. **Cambiar Estados:** En **Servicios Asignados**, busca la carrera por su ID y cambia su status (Ej. "En Proceso" o "Completado"). 

---
*Desarrollado y estructurado modularmente para fines académicos/profesionales enfocados en calidad de software.*
