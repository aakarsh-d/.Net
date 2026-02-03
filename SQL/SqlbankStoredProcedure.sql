create Database TopBrains;
use TopBrains;


-- Table customers

CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    PhoneNumber VARCHAR(15),
    City VARCHAR(50),
    CreatedDate DATE
);

--Table Accounts


CREATE TABLE Accounts
(
    AccountID INT PRIMARY KEY,
    CustomerID INT,
    AccountNumber VARCHAR(20),
    AccountType VARCHAR(20), -- Savings / Current
    OpeningBalance DECIMAL(12,2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);


--Table Transactions

CREATE TABLE Transactions
(
    TransactionID INT PRIMARY KEY,
    AccountID INT,
    TransactionDate DATE,
    TransactionType VARCHAR(10), -- Deposit / Withdraw
    Amount DECIMAL(12,2),
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);



--Table Bonus 
CREATE TABLE Bonus
(
    BonusID INT PRIMARY KEY,
    AccountID INT,
    BonusMonth INT,
    BonusYear INT,
    BonusAmount DECIMAL(10,2),
    CreatedDate DATE,
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);


--insertion in customers

INSERT INTO Customers VALUES
(1, 'Ravi Kumar', '9876543210', 'Chennai', '2023-01-10'),
(2, 'Priya Sharma', '9123456789', 'Bangalore', '2023-03-15'),
(3, 'John Peter', '9988776655', 'Hyderabad', '2023-06-20');


--insertion in accounts

INSERT INTO Accounts VALUES
(101, 1, 'SB1001', 'Savings', 20000),
(102, 2, 'SB1002', 'Savings', 15000),
(103, 3, 'SB1003', 'Savings', 30000);


--insertion in transactions

INSERT INTO Transactions VALUES
(1, 101, '2024-01-05', 'Deposit', 30000),
(2, 101, '2024-01-18', 'Withdraw', 5000),
(3, 101, '2024-02-10', 'Deposit', 25000),

(4, 102, '2024-01-07', 'Deposit', 20000),
(5, 102, '2024-01-25', 'Deposit', 35000),
(6, 102, '2024-02-05', 'Withdraw', 10000),

(7, 103, '2024-01-10', 'Deposit', 15000),
(8, 103, '2024-01-20', 'Withdraw', 5000);




--q1  sp to get total deposited and withdrawn amount during the given period

ALTER PROC usp_gettotalfromAccounts
@StartDate Date,
@EndDate Date,
@AccountId int
AS 
BEGIN
Select SUM([dbo].[Transactions].Amount) as TotalDeposited from [dbo].[Transactions]
        WHERE 
        (TransactionType='Deposit' AND TransactionDate BETWEEN @StartDate AND @EndDate AND AccountID=@AccountId);
Select SUM([dbo].[Transactions].Amount) as TotalWithdrawn from [dbo].[Transactions]
        WHERE 
        (TransactionType='Withdraw' AND TransactionDate BETWEEN @StartDate AND @EndDate AND AccountID=@AccountId);

END;

EXEC usp_gettotalfromAccounts '2024-01-05','2024-02-10',101;


--q2 monthly bonus update

create procedure usp_BonusUpdate
as
begin
insert into Bonus(BonusID,AccountID,BonusMonth,BonusYear, BonusAmount,CreatedDate)
select ROW_NUMBER() OVER (ORDER BY AccountID), AccountID , Month(TransactionDate),
Year(TransactionDate), 1000, GetDate() from Transactions
where TransactionType ='Deposit' group by AccountID , Month(TransactionDate), Year(TransactionDate) 
having sum(Amount) >50000;
end;
exec usp_BonusUpdate;


--q3 Check current bal

Alter PROC usp_CurrentBal
AS 
BEGIN
Select [dbo].[Customers].CustomerName, 
    Accounts.AccountNumber, 
    Accounts.OpeningBalance+ISNULL(SUM(CASE 
                                When Transactions.TransactionType='Deposit'
                                THEN Transactions.Amount
                                ELSE 0
                                END),0)
                -ISNULL(Sum(CASE 
                      When Transactions.TransactionType='Withdraw'
                                THEN Transactions.Amount
                                ELSE 0
                                END),0)
                +ISNULL(SUM(Bonus.BonusAmount),0)
            AS TotalBal
From Customers Inner JOIN Accounts On Customers.CustomerId=Accounts.CustomerId
Left JOIN Transactions on Transactions.AccountID=Accounts.AccountID
Left Join Bonus On Transactions.AccountId=Bonus.AccountId

Group by Customers.CustomerName,Accounts.AccountNumber,Accounts.OpeningBalance;
END;

EXEC usp_CurrentBal;