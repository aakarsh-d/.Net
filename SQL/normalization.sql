INSERT INTO SalesPersonDetails(SalesId, Name)
VALUES
(1, 'Anitha'),
(2, 'Suresh');


INSERT INTO ProductMaster (Id,Item, Price)
VALUES
(1,'Laptop',  '55000'),
(2,'Mouse',   '500'),
(3,'Keyboard','1500'),
(4,'Monitor', '12000');


INSERT INTO OrderDetails
(Id, CustomerId, PurchaseDate, SalesId)
VALUES
(101, 1, '2024-01-05', 1),
(102, 2, '2024-01-06', 1),
(103, 1, '2024-01-10', 2),
(104, 3, '2024-02-01', 1),
(105, 2, '2024-02-10', 2);



ALTER TABLE OrderDetails
ADD CONSTRAINT FK_OrderDetails_SalesPersonDetails
FOREIGN KEY (SalesId)
REFERENCES SalesPersonDetails(SalesId);



DELETE FROM dbo.OrderDetails;


INSERT INTO dbo.PurchaseDetails (OrderId, ProductId, Quantity)
VALUES
(101, 1, 1),
(101, 2, 2);




---q2 Third Highest Total Sales (Analytical Query)

SELECT TotalSales FROM  (Select OrderDetails.Id ,SUM(PurchaseDetails.Quantity*ProductMaster.Price)AS TotalSales From OrderDetails 
INNER JOIN
PurchaseDetails on OrderDetails.Id=PurchaseDetails.OrderId
Inner Join
ProductMaster On PurchaseDetails.ProductId=ProductMaster.Id 
GROUP BY OrderDetails.Id)AS T
Order by TotalSales DESC OFFSET 2 ROWS FETCH NEXT 1 ROW ONLY;

--q3 GROUP BY & HAVING (Business Rule)

/*Management wants to identify salespersons who generated high revenue.

Task:
Write a query to list SalesPerson names whose total sales amount is greater than ₹60,000.

Use:

    GROUP BY
    HAVING
    */
SELECT [dbo].[SalesPersonDetails].NAME FROM SalesPersonDetails Inner Join OrderDetails On SalesPersonDetails.SalesId=OrderDetails.SalesId 
Inner JOIN PurchaseDetails On PurchaseDetails.OrderId=OrderDetails.Id Inner Join ProductMaster On PurchaseDetails.ProductId=ProductMaster.Id 
Group By SalesPersonDetails.Name Having Sum(PurchaseDetails.Quantity*(ProductMaster.Price))>60000;


--q4
/*The company wants to find customers who spent more than the average customer spending.

Task:
Write a query using a subquery to display:

    CustomerName
    Total amount spent

Only include customers whose total spending is above the average spending of all customers.
*/

Select CustomerMaster.CustomerName,
    SUM(PurchaseDetails.Quantity * (ProductMaster.Price)) AS Total
FROM CustomerMaster
INNER JOIN OrderDetails
    ON CustomerMaster.ID = OrderDetails.CustomerId
INNER JOIN PurchaseDetails
    ON OrderDetails.Id = PurchaseDetails.OrderId
INNER JOIN ProductMaster
    ON PurchaseDetails.ProductId = ProductMaster.Id
GROUP BY CustomerMaster.CustomerName
HAVING 
    SUM(PurchaseDetails.Quantity * ProductMaster.Price) >
    (
        SELECT AVG(CustomerTotal)
        FROM
        (
            SELECT 
                SUM(PurchaseDetails.Quantity * ProductMaster.Price) AS CustomerTotal
            FROM CustomerMaster
            INNER JOIN OrderDetails
                ON CustomerMaster.ID = OrderDetails.CustomerId
            INNER JOIN PurchaseDetails
                ON OrderDetails.Id = PurchaseDetails.OrderId
            INNER JOIN ProductMaster
                ON PurchaseDetails.ProductId = ProductMaster.Id
            GROUP BY CustomerMaster.CustomerName
        ) X
    );


/*
Question 5 – String & Date Functions

Operations team wants formatted and filtered data.

Tasks:

    Display CustomerName in UPPERCASE
    Extract Order Month from OrderDate
    Show only orders placed in January 2026

 */

 Select UPPER(CustomerMaster.CustomerName) as CustomerName, MONTH(OrderDetails.PurchaseDate) AS OrderMonth 
    from CustomerMaster
    Inner Join OrderDetails
    On CustomerMaster.Id=OrderDetails.CustomerId
Where
    YEAR(OrderDetails.PurchaseDate)=2026
    And Month(OrderDetails.PurchaseDate)=1;
