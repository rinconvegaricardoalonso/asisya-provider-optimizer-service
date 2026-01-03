C4Container
title Plataforma de Asistencias – Contenedores

Person(user, "Usuario App")
Person(provider, "Proveedor App")

System_Boundary(system, "Vehicular Assistance Platform") {

    Container(lb, "Load Balancer", "ALB", "Distribuye tráfico")
    Container(api, "API Gateway", "AWS API Gateway", "Entry point")
    Container(auth, "Auth Service", "OAuth2 / JWT", "Autenticación")

    Container(assistance, "AssistanceRequestService", ".NET", "Gestión de casos")
    Container(optimizer, "ProviderOptimizerService", ".NET", "Algoritmo de asignación")
    Container(location, "LocationService", ".NET", "Tracking y ubicación")
    Container(notification, "NotificationsService", ".NET", "Push / SMS / Email")

    ContainerDb(db, "RDS PostgreSQL", "PostgreSQL", "Datos transaccionales")
    Container(cache, "Redis Cache", "Redis", "Datos temporales")
    Container(queue, "Message Broker", "SQS / SNS", "Eventos async")
    Container(storage, "S3", "Object Storage", "Logs, adjuntos")

    Container(obs, "Observability", "CloudWatch / OpenTelemetry", "Logs y métricas")
}

Rel(user, lb, "HTTPS")
Rel(lb, api, "Routes")
Rel(api, auth, "JWT validation")
Rel(api, assistance, "REST")
Rel(assistance, optimizer, "REST")
Rel(assistance, queue, "Publica eventos")
Rel(queue, notification, "Eventos")
Rel(location, cache, "Ubicación en tiempo real")
Rel(assistance, db, "CRUD")
Rel(optimizer, db, "Read")
Rel(api, obs, "Logs / Metrics")
Rel(assistance, obs, "Logs / Metrics")
Rel(optimizer, obs, "Logs / Metrics")
Rel(notification, obs, "Logs / Metrics")
Rel(user, provider, "Solicita asistencia")
