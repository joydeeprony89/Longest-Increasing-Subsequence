using System;

namespace Longest_Increasing_Subsequence
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] nums = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }; //  1, 2, 4,3
      Solution s = new Solution();
      var result = s.LengthOfLIS(nums);
      Console.WriteLine(result);
    }
  }

  public class Solution
  {
    public int LengthOfLIS(int[] nums)
    {
      // this will be updating with the max dp value as answer
      int result = 1;
      // create the DP array
      int[] dp = new int[nums.Length];
      // initialize with 1 as for each position at least one possiblity we have
      for (int i = 0; i < nums.Length; i++)
      {
        dp[i] = 1;
      }

      // will start from the end
      for (int i = nums.Length - 1; i >= 0; i--)
      {
        // for each index will start from next index and go till the end to compare if any increasing value and also get the cached max seq
        for (int j = i + 1; j < nums.Length; j++)
        {
          // next no has to be greater than current no
          if (nums[i] < nums[j])
          {
            // update the current DP 
            dp[i] = Math.Max(dp[i], 1 + dp[j]);
            // update the answer
            result = Math.Max(result, dp[i]);
          }
        }
      }

      return result;
    }
  }
}
