using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Events;

public record StudentCreated(
    Guid EnrollmentId,
    Guid StudentId,
    string FullName,
    string Email,
    Guid CourseId
);

public record SeatReserved(
    Guid EnrollmentId,
    Guid StudentId,
    Guid CourseId,
    string CourseName,
    string CourseCode,
    decimal CourseFeeAmount,
    int SeatNumber
);

public record SeatReservationFailed(
    Guid EnrollmentId,
    Guid StudentId,
    Guid CourseId,
    string Reason
);

public record SeatReleased(
    Guid EnrollmentId,
    Guid CourseId,
    int SeatNumber,
    string Reason
);

public record FeeCreated(
    Guid EnrollmentId,
    Guid StudentId,
    Guid CourseId,
    Guid FeeRecordId,
    decimal Amount,
    DateTime DueDate
);

public record EnrollmentFailed(
    Guid EnrollmentId,
    Guid StudentId,
    Guid CourseId,
    string Reason,
    DateTime FailedAt
);

public record StudentEnrollmentCancelled(
    Guid EnrollmentId,
    Guid StudentId,
    string Reason
);