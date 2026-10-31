# FraudShield

FraudShield is a microservices-based banking fraud detection simulator using ASP.NET Core, PostgreSQL, RabbitMQ, Redis, YARP, and React + TypeScript.

## Architecture

- **Independent Microservices**:
  - `IdentityService`: User authentication, roles, JWT tokens.
  - `CustomerService`: Customer profiles, KYC verification, status tracking.
  - `TransactionService`: Banking transactions ingestion, state lifecycle.
  - `FraudDetectionService`: Velocity checks, rule evaluation, scoring engine.
  - `AlertService`: Suspicious alert generation, case management, investigations.
  - `NotificationService`: Event-driven alerts and communication worker.
- **YARP API Gateway**: Centralized reverse proxy handling routing and rate limiting.
- **Event-Driven Messaging**: RabbitMQ with versioned integration event contracts, transactional outbox, and idempotent consumers.
- **Caching & Velocity Engine**: Redis for real-time velocity calculations and rate limiting.
- **Data Persistence**: Database-per-service pattern backed by PostgreSQL with EF Core migrations.
- **Observability**: OpenTelemetry metrics, traces, and structured logging.
- **Frontend**: React + TypeScript dashboard with Vite and modern component architecture.

