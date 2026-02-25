# Zetatech Accelerate Framework
## 📋 Descripción
**Zetatech Accelerate** es un framework robusto para aplicaciones .NET que proporciona una arquitectura completamente desacoplada y extensible. Desarrollado por **Zeta Technologies**, está diseñado para acelerar el desarrollo de aplicaciones empresariales modernas, ofreciendo patrones de diseño consolidados y componentes reutilizables. El framework actúa como una **librería de contratos y abstracciones** que establece los cimientos arquitectónicos para:
- **Aplicaciones multicapa** con separación clara de responsabilidades.
- **Sistemas distribuidos** con capacidades de publicación/suscripción de mensajes.
- **Rastreo integral** de operaciones, errores y métricas.
- **Caché** en memoria con control de expiración.
- **Acceso a datos** a través del patrón Repository con Entity Framework Core.
- **Inyección de dependencias** administrada de forma centralizada.
- **Manejo robusto de excepciones** con tipos específicos por escenario.
## 🏗️ Estructura
```
Zetatech.Accelerate
├── Application              # Interfaces principales de la capa de aplicación
│   ├── Abstractions         # Clases base y abstracciones de la capa de aplicación
├── Domain                   # Interfaces principales de la capa de dominio
│   ├── Abstractions         # Clases base y abstracciones de la capa de dominio
├── Infrastructure           # Implementaciones de los servicios principales del framework
├── Exceptions               # Excepciones específicas del framework
├── Extensions               # Clases de extensión y utilidades
├── DependencyInjection      # Configuración e inyección de dependencias
└── Web                      # Componentes de la capa web
    └── Middlewares          # Middlewares especificos del framework
```
## 🔧 Características clave
- **Arquitectura desacoplada**: basada en interfaces y abstracciones.
- **Patrón Repository**: acceso a datos con LINQ y EF Core.
- **Pub/Sub messaging**: sistema de colas y suscriptores.
- **Caché en memoria**: con TTL y límites configurables.
- **Tracking & Telemetría**: errores, eventos, métricas, visualizaciones de áginas y trazas.
- **DI Container**: configuración centralizada de servicios.
- **Excepciones**: gestión centralizada de errores con mapeo automático a códigos HTTP.
- **Request tracking**: correlación y monitoreo de solicitudes.
- **Validación y seguridad**: manejo escalonado de errores.
## 🤝 Contribución
- Repositorio: [GitHub](https://github.com/josemaria-toro/zetatech.git)
- Todo el código es open source disponible bajo la licencia GNU GPL
## 🏢 Desarrollado por
Zeta Technologies - Building robust solutions for modern development challenges.
