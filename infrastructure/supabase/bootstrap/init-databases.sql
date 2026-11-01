-- =============================================================================
-- FraudShield Database Initialization Script
-- Architecture Rule #2: Database ownership per microservice
-- =============================================================================

SELECT 'CREATE DATABASE fraudshield_identity'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'fraudshield_identity')\gexec

SELECT 'CREATE DATABASE fraudshield_customer'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'fraudshield_customer')\gexec

SELECT 'CREATE DATABASE fraudshield_transaction'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'fraudshield_transaction')\gexec

SELECT 'CREATE DATABASE fraudshield_fraud'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'fraudshield_fraud')\gexec

SELECT 'CREATE DATABASE fraudshield_alert'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'fraudshield_alert')\gexec

