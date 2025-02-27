
-- Retrieve all customers who have placed an order
SELECT DISTINCT c.* FROM customers c
INNER JOIN orders o ON c.customer_id = o.customer_id;

-- List orders along with the customer names
SELECT o.*, c.name FROM orders o
INNER JOIN customers c ON o.customer_id = c.customer_id;

-- Find customers who haven’t placed any orders
SELECT * FROM customers c
LEFT JOIN orders o ON c.customer_id = o.customer_id
WHERE o.order_id IS NULL;

-- Retrieve all employees and their department names
SELECT e.*, d.dept_name FROM employees e
LEFT JOIN departments d ON e.department_id = d.department_id;

-- Find departments that have no employees
SELECT * FROM departments d
LEFT JOIN employees e ON d.department_id = e.department_id
WHERE e.emp_id IS NULL;

-- Retrieve the average grade per course
SELECT e.course_id, c.title, AVG(e.grade) AS avg_grade FROM enrollments e
JOIN courses c ON e.course_id = c.course_id
GROUP BY e.course_id, c.title;

-- List students who are not enrolled in any courses
SELECT * FROM students s
LEFT JOIN enrollments e ON s.student_id = e.student_id
WHERE e.course_id IS NULL;

-- Find students who scored above the course average grade
SELECT s.student_id, s.name, e.course_id, e.grade FROM enrollments e
JOIN students s ON e.student_id = s.student_id
WHERE e.grade > (SELECT AVG(grade) FROM enrollments WHERE course_id = e.course_id);

-- Medium Level

-- Retrieve all employees with their department name and manager details
SELECT e.*, d.dept_name, m.manager_name, m.bonus FROM employees e
LEFT JOIN departments d ON e.department_id = d.department_id
LEFT JOIN managers m ON d.manager_id = m.manager_id;

-- Find departments that do not have a manager assigned
SELECT * FROM departments d
WHERE d.manager_id IS NULL;

-- Retrieve employees who earn more than their department’s average salary
SELECT e.* FROM employees e
JOIN (
    SELECT department_id, AVG(salary) AS avg_salary
    FROM employees GROUP BY department_id
) dept_avg ON e.department_id = dept_avg.department_id
WHERE e.salary > dept_avg.avg_salary;

-- Retrieve all products that have never been sold
SELECT * FROM products p
LEFT JOIN order_items oi ON p.product_id = oi.product_id
WHERE oi.product_id IS NULL;

-- Find the top 3 best-selling products based on total quantity sold
SELECT p.product_name, SUM(oi.quantity) AS total_sold FROM order_items oi
JOIN products p ON oi.product_id = p.product_id
GROUP BY p.product_name
ORDER BY total_sold DESC
LIMIT 3;

-- Get the total revenue per product category
SELECT p.category, SUM(oi.quantity * oi.price) AS total_revenue FROM order_items oi
JOIN products p ON oi.product_id = p.product_id
GROUP BY p.category;

-- Advanced Filtering with JOINS

-- Retrieve all employees and the projects they are working on
SELECT e.*, p.project_name FROM employees e
LEFT JOIN employee_projects ep ON e.emp_id = ep.emp_id
LEFT JOIN projects p ON ep.project_id = p.project_id;

-- Find employees who are not assigned to any project
SELECT * FROM employees e
LEFT JOIN employee_projects ep ON e.emp_id = ep.emp_id
WHERE ep.project_id IS NULL;

-- List projects that have no employees assigned
SELECT * FROM projects p
LEFT JOIN employee_projects ep ON p.project_id = ep.project_id
WHERE ep.emp_id IS NULL;

-- Customer Order Behavior Analysis

-- Find customers who have placed more than 5 orders
SELECT c.customer_id, c.name, COUNT(o.order_id) AS order_count FROM customers c
JOIN orders o ON c.customer_id = o.customer_id
GROUP BY c.customer_id, c.name
HAVING order_count > 5;

-- Retrieve the total amount spent per customer
SELECT c.customer_id, c.name, SUM(o.total_amount) AS total_spent FROM customers c
JOIN orders o ON c.customer_id = o.customer_id
GROUP BY c.customer_id, c.name;

-- Get customers who haven’t placed any orders in the last 6 months
SELECT * FROM customers c
LEFT JOIN orders o ON c.customer_id = o.customer_id
WHERE o.order_date < NOW() - INTERVAL 6 MONTH OR o.order_id IS NULL;


-- Retrieve all employees with their department names and managers
SELECT e.*, d.dept_name, m.manager_name FROM employees e
LEFT JOIN departments d ON e.department_id = d.department_id
LEFT JOIN managers m ON d.manager_id = m.manager_id;

-- Find employees who earn more than their department’s average salary
SELECT e.* FROM employees e
JOIN (
    SELECT department_id, AVG(salary) AS avg_salary FROM employees
    GROUP BY department_id
) dept_avg ON e.department_id = dept_avg.department_id
WHERE e.salary > dept_avg.avg_salary;

-- Calculate the total salary expense per manager, including bonus amounts
SELECT m.manager_id, m.manager_name, SUM(e.salary) + m.bonus AS total_expense FROM employees e
JOIN departments d ON e.department_id = d.department_id
JOIN managers m ON d.manager_id = m.manager_id
GROUP BY m.manager_id, m.manager_name, m.bonus;

-- Complex Many-to-Many Relationship: Student-Course Enrollments

-- Retrieve all students along with their enrolled courses
SELECT s.*, c.title FROM students s
LEFT JOIN enrollments e ON s.student_id = e.student_id
LEFT JOIN courses c ON e.course_id = c.course_id;

-- Find students who are enrolled in more than 3 courses
SELECT s.student_id, s.name, COUNT(e.course_id) AS course_count FROM students s
JOIN enrollments e ON s.student_id = e.student_id
GROUP BY s.student_id, s.name
HAVING course_count > 3;

-- Get the highest and lowest grades for each course
SELECT course_id, MAX(grade) AS highest_grade, MIN(grade) AS lowest_grade FROM enrollments
GROUP BY course_id;

