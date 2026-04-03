using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstCode.Models;

[Index("Email", Name = "UQ__Employee__A9D105348A000C9D", IsUnique = true)]
public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string? Email { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Salary { get; set; }

    public int? DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Employees")]
    public virtual Department? Department { get; set; }
}
