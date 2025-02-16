using System;
using System.Collections.Generic;
using System.Linq;

public class Solutions
{
    public static int MaxArea(int[] height)
    {
        int left = 0, right = height.Length - 1, maxArea = 0;
        while (left < right)
        {
            int area = Math.Min(height[left], height[right]) * (right - left);
            maxArea = Math.Max(maxArea, area);
            if (height[left] < height[right])
                left++;
            else
                right--;
        }
        return maxArea;
    }

    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Interval(int s, int e) { Start = s; End = e; }
    }

    public static List<Interval> MergeIntervals(List<Interval> intervals)
    {
        if (intervals.Count == 0) return intervals;
        intervals.Sort((a, b) => a.Start.CompareTo(b.Start));
        List<Interval> merged = new();
        Interval prev = intervals[0];

        foreach (var curr in intervals.Skip(1))
        {
            if (prev.End >= curr.Start)
                prev.End = Math.Max(prev.End, curr.End);
            else
            {
                merged.Add(prev);
                prev = curr;
            }
        }
        merged.Add(prev);
        return merged;
    }

    public static int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> map = new();
        int maxLength = 0, left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            if (map.ContainsKey(s[right]) && map[s[right]] >= left)
                left = map[s[right]] + 1;

            map[s[right]] = right;
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        return maxLength;
    }

    public static void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);

        foreach (var row in matrix)
            Array.Reverse(row);
    }

    public static bool IsValid(string s)
    {
        Stack<char> stack = new();
        Dictionary<char, char> pairs = new() { { ')', '(' }, { '}', '{' }, { ']', '[' } };

        foreach (char c in s)
        {
            if (pairs.ContainsValue(c)) stack.Push(c);
            else if (stack.Count == 0 || stack.Pop() != pairs[c]) return false;
        }
        return stack.Count == 0;
    }

    public class ListNode
    {
        public int Val;
        public ListNode Next;
        public ListNode(int val = 0, ListNode next = null) { Val = val; Next = next; }
    }

    public static ListNode ReverseList(ListNode head)
    {
        ListNode prev = null, curr = head;
        while (curr != null)
        {
            ListNode nextTemp = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = nextTemp;
        }
        return prev;
    }

    public static int FindMissingNumber(int[] nums)
    {
        int n = nums.Length + 1;
        int expectedSum = n * (n + 1) / 2;
        int actualSum = nums.Sum();
        return expectedSum - actualSum;
    }

    public static List<int> TopKFrequent(int[] nums, int k)
    {
        return nums.GroupBy(n => n)
                   .OrderByDescending(g => g.Count())
                   .Take(k)
                   .Select(g => g.Key)
                   .ToList();
    }

    public static int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target) return mid;
            if (nums[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return left;
    }

    public static bool CanJump(int[] nums)
    {
        int maxReach = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxReach) return false;
            maxReach = Math.Max(maxReach, i + nums[i]);
        }
        return true;
    }

    public static void Main()
    {
        Console.WriteLine({MaxArea(new[] {1, 8, 6, 2, 5, 4, 8, 3, 7})});

        var intervals = new List<Interval>
        {
            new Interval(1, 3),
            new Interval(2, 6),
            new Interval(8, 10),
            new Interval(15, 18)
        };
        var merged = MergeIntervals(intervals);
        Console.WriteLine(string.Join(", ", merged.Select(i => $"[{i.Start},{i.End}]")));

        Console.WriteLine({LengthOfLongestSubstring("abcabcbb")});

        int[][] matrix = { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } };
        Rotate(matrix);
        foreach (var row in matrix) Console.WriteLine(string.Join(" ", row));

        Console.WriteLine({IsValid("()[]{}")});

        Console.WriteLine({FindMissingNumber(new[] {3, 7, 1, 2, 8, 4, 5})});

        Console.WriteLine({string.Join(", ", TopKFrequent(new[] {1, 1, 1, 2, 2, 3}, 2))});

        Console.WriteLine({SearchInsert(new[] {1, 3, 5, 6}, 5)});

        Console.WriteLine({CanJump(new[] {2, 3, 1, 1, 4})});
    }
}
