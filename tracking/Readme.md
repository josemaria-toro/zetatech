# Zetatech Tracking System
## 📋 Descripción
**Zetatech Tracking** es un sistema para la ingesta y procesamiento de mensajes con datos de telemetría, provenientes de las aplicaciones existentes en el ecosistema. El sistema esta compuesto por 2 componentes que permitirán, por un lado, la ingesta de mensajes, y por otro, el procesamiento de los mismos.
## 🏗️ Estructura
```
Zetatech.Tracking
├── Domain                   # Entidades del dominio
├── Scripts                  # Scripts SQL para la creación del modelo de datos en un SGBD
Zetatech.Tracking.Ingestion  # Api pública para la ingesta de datos de telemetría desde las aplicaciones
├── DependencyInjection      # Clases de extensión para configurar la inyección de dependencias
├── Extensions               # Clases de extensión genéricas
├── Web                      # Componentes de la capa web
Zetatech.Tracking.Processor  # Servicio para el procesamiento de mensajes en segundo plano
├── DependencyInjection      # Clases de extensión para configurar la inyección de dependencias
├── Infrastructure           # Componentes de la capa de infraestructura
```
## 🔧 Características clave
- **Arquitectura de eventos**: basada en el intercambio de mensajes de manera asíncrona.
- **Patrón Repository**: acceso a datos con LINQ y EF Core.
- **Pub/Sub messaging**: sistema de colas y suscriptores.
## 🤝 Contribución
- Repositorio: [GitHub](https://github.com/josemaria-toro/zetatech.git)
- Todo el código es open source disponible bajo la licencia GNU GPL
## 🏢 Desarrollado por
Zeta Technologies - Building robust solutions for modern development challenges.