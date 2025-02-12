-- Easy Question

-- Q1: Calculate the total score for each student
SELECT StudentID, (MathScore + ScienceScore) AS TotalScore 
FROM StudentScores;

-- Q2: Calculate the number of classes each student actually attended
SELECT StudentID, (TotalClasses - DaysAbsent) AS ClassesAttended 
FROM StudentScores;

-- Q3: Find the total study hours for each student (2 study hours per class)
SELECT StudentID, (TotalClasses - DaysAbsent) * 2 AS TotalStudyHours 
FROM StudentScores;

-- Q4: Calculate the average score for each student
SELECT StudentID, (MathScore + ScienceScore) / 2 AS AverageScore 
FROM StudentScores;

-- Q5: Retrieve the total score of each student where the combined score is greater than 160
SELECT StudentID, (MathScore + ScienceScore) AS TotalScore 
FROM StudentScores 
WHERE (MathScore + ScienceScore) > 160;

-- Q6: Find students who attended more than 25 classes
SELECT StudentID, (TotalClasses - DaysAbsent) AS ClassesAttended 
FROM StudentScores 
WHERE (TotalClasses - DaysAbsent) > 25;

-- Medium Question

-- Q1: Calculate the discounted price for each product and find products where the discounted price is greater than 15
SELECT ProductID, ProductName, 
       Price - (Price * Discount / 100) AS DiscountedPrice 
FROM Products 
WHERE (Price - (Price * Discount / 100)) > 15;

-- Q2: Find products with total inventory value (Price × Quantity) greater than 600
SELECT ProductID, ProductName, (Price * Quantity) AS InventoryValue 
FROM Products 
WHERE (Price * Quantity) > 600;

-- Q3: Retrieve products where the price after discount is less than 10
SELECT ProductID, ProductName, 
       Price - (Price * Discount / 100) AS DiscountedPrice 
FROM Products 
WHERE (Price - (Price * Discount / 100)) < 10;

-- Q4: Find products where the price after discount is between 5 and 15
SELECT ProductID, ProductName, 
       Price - (Price * Discount / 100) AS DiscountedPrice 
FROM Products 
WHERE (Price - (Price * Discount / 100)) BETWEEN 5 AND 15;


-- Hard Question

-- Q1: Find the student(s) who attended the maximum number of classes, and also calculate their total score
SELECT StudentID, (MathScore + ScienceScore) AS TotalScore, 
       (TotalClasses - DaysAbsent) AS ClassesAttended 
FROM StudentScores 
WHERE (TotalClasses - DaysAbsent) = 
      (SELECT MAX(TotalClasses - DaysAbsent) FROM StudentScores);

-- Q2: Find products where the price after discount is greater than 10 but less than 20, 
-- and the total inventory value (Price × Quantity) exceeds 600
SELECT ProductID, ProductName, 
       Price - (Price * Discount / 100) AS DiscountedPrice, 
       (Price * Quantity) AS InventoryValue 
FROM Products 
WHERE (Price - (Price * Discount / 100)) > 10 
      AND (Price - (Price * Discount / 100)) < 20 
      AND (Price * Quantity) > 600;

