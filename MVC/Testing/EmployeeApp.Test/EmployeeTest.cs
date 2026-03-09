using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Testing.Services;
using Testing.Model;
using Testing.Repositories;


namespace EmployeeApp.Test;
[TestFixture]


public sealed class EmployeeTest
{
    private Mock<IEmployeeRepository> _repoMock = default!;
    private EmployeeServices _services = default!;
    [SetUp]
    public void Setup()
            {
        _repoMock = new Mock<IEmployeeRepository>(MockBehavior.Strict);
        _services = new EmployeeServices(_repoMock.Object);
    }
    [Test]
    public void GetEmployeeOrThrow_ShouldReturnEmployee_WhenEmployeeExists()
    {
        // Arrange
        var expected = new Employee { Id = 10, Name = "John Doe", Age = 30 };
        _repoMock.Setup(r => r.GetById(10)).Returns(expected);

        var result = _services.GetEmployeeOrThrow(10);

        //Assert

        //Assert.That(10,Is.EqualTo(result.Id));
        //Assert.That(30, Is.EqualTo(result.Age));
        //Assert.That(result, Is.SameAs(expected));

        //Assert.IsNull(result);
        Assert.AreEqual(10, result.Id);
        Assert.IsNotNull(result);
        Assert.AreEqual("John Doe", result.Name);
        Assert.AreSame(expected, result);
        _repoMock.Verify(r=>r.GetById(10),Times.Once());
        _repoMock.VerifyNoOtherCalls();
    }

    [Test]
    public void AddEmployee_shouldReturnEmployee()
    {
        var expected = new Employee { Id = 2, Name = "Aakarsh",Age= 21 };

        _repoMock.Setup(r => r.Add(expected));
        //ACt
        _services.AddEmployee(expected);

        //Assert
        _repoMock.Verify(r => r.Add(expected), Times.Once);
    }
}
