
class Program
{
    static void Main()
    {
        int[] arr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        Console.WriteLine(MaxSubarraySum(arr));

        int[] arr1 = { 1, 3, 4, 5, 7 };
        int[] arr2 = { 2, 3, 5, 6 };
        Console.WriteLine(string.Join(", ", Intersection(arr1, arr2)));
        Console.WriteLine(string.Join(", ", Union(arr1, arr2)));

        int[,] matrixA = { { 1, 0, 0 }, { -1, 0, 3 } };
        int[,] matrixB = { { 7, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } };
        int[,] result = SparseMatrixMultiply(matrixA, matrixB);
        PrintMatrix(result);

        int[] nums = { 3, 4, -1, 1 };
        Console.WriteLine(FirstMissingPositive(nums));

        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        RotateMatrix(matrix);
        PrintMatrix(matrix);
    }

    static int MaxSubarraySum(int[] arr)
    {
        int maxSum = int.MinValue, currentSum = 0;
        foreach (int num in arr)
        {
            currentSum = Math.Max(num, currentSum + num);
            maxSum = Math.Max(maxSum, currentSum);
        }
        return maxSum;
    }

    static List<int> Intersection(int[] arr1, int[] arr2)
    {
        HashSet<int> set1 = new HashSet<int>(arr1);
        List<int> result = new List<int>();
        foreach (int num in arr2)
            if (set1.Contains(num)) result.Add(num);
        return result;
    }

    static List<int> Union(int[] arr1, int[] arr2)
    {
        HashSet<int> set = new HashSet<int>(arr1);
        foreach (int num in arr2) set.Add(num);
        return new List<int>(set);
    }

    static int[,] SparseMatrixMultiply(int[,] A, int[,] B)
    {
        int rowA = A.GetLength(0), colA = A.GetLength(1), colB = B.GetLength(1);
        int[,] result = new int[rowA, colB];
        for (int i = 0; i < rowA; i++)
            for (int k = 0; k < colA; k++)
                if (A[i, k] != 0)
                    for (int j = 0; j < colB; j++)
                        result[i, j] += A[i, k] * B[k, j];
        return result;
    }

    static int FirstMissingPositive(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                (nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);
        for (int i = 0; i < n; i++)
            if (nums[i] != i + 1) return i + 1;
        return n + 1;
    }

    static void RotateMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
                (matrix[i, j], matrix[j, i]) = (matrix[j, i], matrix[i, j]);
        for (int i = 0; i < n; i++)
            for (int j = 0, k = n - 1; j < k; j++, k--)
                (matrix[i, j], matrix[i, k]) = (matrix[i, k], matrix[i, j]);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
}
