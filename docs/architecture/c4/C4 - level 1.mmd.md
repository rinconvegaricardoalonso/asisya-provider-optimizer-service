C4Context
title Sistema de Asistencias Vehiculares – Contexto

Person(user, "Usuario", "Solicita asistencia desde app móvil")
Person(provider, "Proveedor", "Recibe solicitudes de servicio")

System(system, "Vehicular Assistance Platform", "Plataforma central de asistencias")

Rel(user, system, "Solicita asistencia")
Rel(system, provider, "Notifica y asigna servicios")
