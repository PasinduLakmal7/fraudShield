# FraudShield — AI Development Instructions & Rules

You are building FraudShield, a microservices-based banking fraud detection simulator using .NET.

## Architecture
- ASP.NET Core Web APIs
- Independent microservices
- Database ownership per microservice
- PostgreSQL + EF Core
- RabbitMQ for asynchronous integration events
- Redis for caching/velocity features
- YARP API Gateway
- React + TypeScript frontend
- Docker Compose for local development

## Engineering Rules
1. Follow the approved architecture and contracts.
2. Never introduce a shared business database.
3. Never couple services through EF Core entities.
4. Keep business logic out of controllers.
5. Use dependency injection and async APIs.
6. Implement validation and error handling.
7. Use versioned integration event contracts.
8. Use idempotency and the transactional outbox wherever reliable event publication is required.
9. Add relevant automated tests.
10. Use synthetic data only.
11. Never implement real payment execution.
12. Do not implement features from future phases.

## Agent Workflow
For every task:
1. Inspect the existing project and documentation.
2. Explain the files you plan to change.
3. Implement only the requested phase.
4. Add or update tests.
5. Run build and relevant tests.
6. Report the changed files and test results.
7. Explain blockers and outstanding work.

Never claim tests passed without executing them.
Never silently change public API or event contracts.

