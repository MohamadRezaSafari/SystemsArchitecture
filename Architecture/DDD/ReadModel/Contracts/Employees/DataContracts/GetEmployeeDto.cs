using System.Diagnostics;

namespace ReadModel.Contracts.Employees.DataContracts;

[DebuggerDisplay("Employee {Id}: {FirstName} - {LastName}")]
public record GetEmployeeDto(long Id, string FirstName, string LastName);
