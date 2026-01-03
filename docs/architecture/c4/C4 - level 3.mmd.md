C4Component
title ProviderOptimizerService – Componentes

Container(optimizer, "ProviderOptimizerService", ".NET")

Component(controller, "OptimizeController", "API REST")
Component(usecase, "OptimizeProviderUseCase", "Application Logic")
Component(domain, "Provider Domain", "DDD Entities & Rules")
Component(repo, "ProviderRepository", "EF Core")
Component(calc, "DistanceCalculator", "Haversine Algorithm")

Rel(controller, usecase, "Invokes")
Rel(usecase, domain, "Uses")
Rel(usecase, calc, "Calculates distance")
Rel(usecase, repo, "Reads providers")
