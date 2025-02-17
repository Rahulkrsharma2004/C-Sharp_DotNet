## Section 1: Basic Questions

1. **What are the different types of loops in C#?**  
   **Ans =>** C# provides four types of loops: `for`, `while`, `do-while`, and `foreach` loops.

2. **Explain the syntax and working of the for loop in C#.**  
   **Ans =>** The `for` loop in C# consists of an initialization, a condition, and an increment/decrement. Example:
   for (int i = 0; i < 5; i++) {
       Console.WriteLine(i);
   }


3. **How does a while loop work?**  
   **Ans =>** A `while` loop executes a block of code as long as the specified condition is `true`.
   int i = 0;
   while (i < 5) {
       Console.WriteLine(i);
       i++;
   }

4. **What is the difference between a while loop and a do-while loop?**  
   **Ans =>** A `while` loop checks the condition before executing the block, whereas a `do-while` loop executes the block at least once before checking the condition.

5. **What happens if the loop condition in a while loop is initially false?**  
   **Ans =>** The loop body does not execute even once.

6. **How do you use a foreach loop in C#?**  
   **Ans =>** A `foreach` loop iterates through collections like arrays and lists.
   int[] numbers = {1, 2, 3};
   foreach (int num in numbers) {
       Console.WriteLine(num);
   }


7. **Can we modify elements inside a foreach loop? Why or why not?**  
   **Ans =>** No, because `foreach` provides read-only access to elements.



## Section 2: Intermediate Questions

8. **What is an infinite loop? Provide examples using for, while, and do-while.**  
   **Ans =>** An infinite loop is a loop that never ends. Examples:
   for (;;) {}
   while (true) {}
   do {} while (true);


9. **How does the break statement work inside loops?**  
   **Ans =>** The `break` statement terminates the loop immediately.

10. **What is the role of the continue statement in loops?**  
   **Ans =>** The `continue` statement skips the current iteration and moves to the next.

11. **How can you exit multiple nested loops at once?**  
   **Ans =>** Using labeled `break` statements.

12. **What is the difference between break and return inside a loop?**  
   **Ans =>** `break` exits the loop, while `return` exits the method.

13. **How do you iterate through an array using loops?**  
   **Ans =>** Using `for` or `foreach` loop.

14. **Write a C# program to find the largest and smallest number in an array using loops.**  
   **Ans =>**
   int[] arr = {3, 1, 7, 5};
   int min = arr.Min();
   int max = arr.Max();




## Section 3: Advanced Questions

15. **Can a for loop run indefinitely? If yes, how?**  
   **Ans =>** Yes, by omitting condition: `for(;;) {}`

16. **How do you implement a loop using recursion instead of traditional looping constructs?**  
   **Ans =>**
   void RecursiveLoop(int n) {
       if (n <= 0) return;
       Console.WriteLine(n);
       RecursiveLoop(n-1);
   }


17. **What is the impact of using goto inside loops? Is it recommended? Explain with an example.**  
   **Ans =>** `goto` can lead to unstructured code and is generally not recommended.

18. **How does a foreach loop work internally in C#?**  
   **Ans =>** It uses `IEnumerator` internally.

19. **Can a foreach loop be replaced with a for loop? If yes, in what cases?**  
   **Ans =>** Yes, when iterating over index-based collections.

20. **How do you optimize performance in loops when working with large datasets?**  
   **Ans =>** Avoid redundant calculations, use parallel processing.

21. **What are the best practices for writing efficient loops in C#?**  
   **Ans =>** Minimize iterations, use efficient data structures.

22. **How does the Parallel.ForEach loop differ from a normal foreach loop? Provide an example.**  
   **Ans =>** `Parallel.ForEach` executes iterations in parallel.


  


