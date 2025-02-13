-- Q1: Find all employees whose name starts with the letter "J."
SELECT * FROM Employees WHERE Name LIKE 'J%';

-- Q2: Retrieve all employees who are older than 30 years.
SELECT * FROM Employees WHERE Age > 30;

-- Q3: Find the employees who work in the HR department and earn more than $55,000.
SELECT * FROM Employees WHERE Department = 'HR' AND Salary > 55000;

-- Q4: Find all products in the Products table where the product name contains "head."
SELECT * FROM Products WHERE ProductName LIKE '%head%';

-- Q5: List the products whose price is between $50 and $100.
SELECT * FROM Products WHERE Price BETWEEN 50 AND 100;

-- Q6: Find all employees whose name ends with the letter "n."
SELECT * FROM Employees WHERE Name LIKE '%n';


-- Q1: Find products where the price is between $50 and $200, and the discount is greater than 10%.
SELECT * FROM Products WHERE Price BETWEEN 50 AND 200 AND Discount > 10;

-- Q2: Retrieve the total quantity of all products in the Products table.
SELECT SUM(Quantity) AS TotalQuantity FROM Products;

-- Q3: Find employees whose age is between 25 and 35.
SELECT * FROM Employees WHERE Age BETWEEN 25 AND 35;

-- Q4: Retrieve all products where the product name contains the letter "o" but does not end with "s."
SELECT * FROM Products WHERE ProductName LIKE '%o%' AND ProductName NOT LIKE '%s';


-- Q1: Retrieve the highest salary among employees who have been hired after 2020, and display the employee name and salary.
SELECT Name, Salary FROM Employees WHERE HireDate > '2020-01-01' ORDER BY Salary DESC LIMIT 1;

-- Q2: Calculate the total discounted price for each product after applying the discount, and retrieve products where the discounted price is greater than $100.
SELECT ProductName, (Price - (Price * Discount / 100)) AS DiscountedPrice 
FROM Products 
WHERE (Price - (Price * Discount / 100)) > 100;
