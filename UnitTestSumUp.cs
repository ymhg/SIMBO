using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestProject1;

/*
Given an integer array nums, and it contains two elements that sum up to a specific number target. Design a method (function) to find them.

You can assume that there is always exactly one solution.The order of the result does not matter.

Example:
Input: nums = [1, 4, 7, 23, 9], and target = 13.
Output: {4, 9}, because 4 + 9 = 13.
 */

public class UnitTestSumUp
{
    private Sum _sum;

    [SetUp]
    public void Setup()
    {
        _sum = new Sum();
    }

    [Test]
    public void Test1()
    {
        CollectionAssert.AreEqual(new[] { 4, 9 }, _sum.SumUp(new[] { 1, 4, 7, 23, 9 }, 13));
    }
}

public class Sum
{
    public int[] SumUp(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();
        for (var j = 0; j < nums.Length; j++)
        {
            int r = target - nums[j];
            if (dictionary.ContainsKey(r))
            {
                return new[] { nums[dictionary[r]], nums[j] };
            }

            if (!dictionary.ContainsKey(nums[j]))
            {
                dictionary.Add(nums[j], j);
            }
        }

        return Array.Empty<int>();
    }
}