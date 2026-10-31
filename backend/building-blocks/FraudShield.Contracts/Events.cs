namespace FraudShield.Contracts.Events;

public record CustomerStatusChangedEvent(
    Guid EventId,
    Guid CustomerId,
    string PreviousStatus,
    string NewStatus,
    DateTime Timestamp
);

public record TransactionAssessedEvent(
    Guid EventId,
    Guid TransactionId,
    Guid CustomerId,
    decimal RiskScore,
    string Decision,
    IReadOnlyList<string> TriggeredRules,
    DateTime Timestamp
);

public record FraudAlertCreatedEvent(
    Guid AlertId,
    Guid TransactionId,
    Guid CustomerId,
    string Severity,
    string Reason,
    DateTime Timestamp
);

