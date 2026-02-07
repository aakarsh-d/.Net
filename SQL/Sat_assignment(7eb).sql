
Create Database Sat_assignment;

use Sat_assignment;


CREATE TABLE Department
(
    DepartmentId INT IDENTITY PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL UNIQUE
);


CREATE TABLE Employee
(
    EmpId INT PRIMARY KEY,
    EmpName VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL UNIQUE,
    DepartmentId INT NOT NULL,

    CONSTRAINT FK_Employee_Department
        FOREIGN KEY (DepartmentId)
        REFERENCES Department(DepartmentId)
);


CREATE TABLE Sales
(
    EmpId INT NOT NULL,
    SaleMonth INT NOT NULL,
    SaleYear INT NOT NULL,
    SaleAmount DECIMAL(12,2) NOT NULL,

    CONSTRAINT PK_Sales
        PRIMARY KEY (EmpId, SaleMonth, SaleYear),

    CONSTRAINT FK_Sales_Employee
        FOREIGN KEY (EmpId)
        REFERENCES Employee(EmpId)
);


INSERT INTO Sales (EmpId, SaleMonth, SaleYear, SaleAmount)
VALUES 
(1, 1, 2025, 45000),
(2, 1, 2025, 38000),
(3, 1, 2025, 42000);

INSERT INTO Sales (EmpId, SaleMonth, SaleYear, SaleAmount)
VALUES 
(1, 2, 2025, 5000),
(2, 3, 2025, 9000),
(3, 2, 2025, 2000);
select * from sales;

select * from Employee;



--q2
ALTER Table Employee add BonusPoints Int NOT NULL 
Constraint defaultvalue Default 0;

Select * from Employee;

--q3
Alter TABLE Employee Add Constraint RangeValue Check( BonusPoints Between 0 And 100);

--q4

select Employee.[EmpName], Department.DepartmentName,
Sales.SaleMonth,Sales.SaleYear,Sales.SaleAmount from Department 
INner Join Employee On Department.DepartmentId=Employee.DepartmentId 
Inner Join Sales On Employee.EmpId =Sales.EmpId;


--q5  total sales for current year

Select Employee.EmpId,Employee.EmpName, Sum(Sales.SaleAmount) as Totalsale from Employee
Inner Join Sales on Sales.EmpId=Employee.EmpId
Where Sales.SaleYear=Year(GetDate())
Group by Employee.EmpName,Employee.EmpId;
select * from Sales;

--q6 


SELECT
    LEFT(Employee.EmpName,3) +
    SUBSTRING(Department.DepartmentName,1,2) +
    CAST(Employee.EmpId AS VARCHAR) AS UserName
FROM Employee 
INNER JOIN Department 
    ON Employee.EmpId = Department.DepartmentId;


--q7 total sales > avg sales
Select Employee.EmpName,Sum(Sales.SaleAmount) as TotalSales
from Employee Inner Join Sales On Sales.EmpId=Employee.EmpId Group By Employee.EmpName
Having SUM(Sales.SaleAmount)>( Select Avg(Total) from
(Select Sum(Sales.SaleAmount) as Total From Sales Group by EmpId)H);


--q8 union of sal>50k and sal<10k

Select Employee.EmpName,Sales.SaleAmount, 'High' aS Category
From Employee Inner Join Sales on Sales.EmpId=Employee.EmpId where Sales.SaleAmount>50000
Union

Select Employee.EmpName,Sales.SaleAmount, 'low' aS Category
From Employee Inner Join Sales on Sales.EmpId=Employee.EmpId where Sales.SaleAmount<10000


--q9 trigger 
ALTER TABLE Sales
DROP CONSTRAINT PK_Sales;

Create Trigger trg_updatebonus
ON SALES
After INsert
AS 
BEGIN
    Update e
    SET BonusPoints=BonusPoints+
    CASE 
        When i.SaleAmount>=50000 THEN 10
        WHEN i.SaleAmount>=20000 THEN 5
        ELSE 0
    End
    from Employee e
    Inner Join inserted i
    on e.EmpId=i.EmpId;
End;

--q10  

select Employee.EmpName,
Department.DepartmentName,
Sum(Sales.SaleAmount) As TotalSales,
CASE 
    WHEN Employee.BonusPoints>=50 THen 'A'
    When Employee.BonusPoints BETWEEN 20 and 49 then 'B'
    ELSE 'C'
    END As perforamanceGrade
from Employee
Inner Join Department on Employee.EmpId=Department.DepartmentId
Inner Join Sales On Sales.EmpId=Department.DepartmentId
Group BY Employee.EmpName,
Department.DepartmentName,
Employee.BonusPoints;


select * from Employee;
