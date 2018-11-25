import java.util.HashMap;
public class TwoSum
{

    /*  Given an array of integers, return indices of the two numbers such that they add up to a specific target.  You may assume that each input would have exactly one solution, and you may not use the same element twice.
    */

    public static void main(String[] args)
    {
       int[] arr = {7,12,11,2,15};
       int target = 9;
       TwoSum solver = new TwoSum();
        
       int[] result = solver.twoSum(arr, target);
       System.out.println("Solution: "+result[0]+ " "+result[1]);
    }
    
    public int[] twoSum(int[] nums, int target) {
        HashMap<Integer,Integer> map = new HashMap<Integer,Integer>();
        for(int i=0; i<nums.length; i++)
        {
            int compl = target - nums[i];
            if(map.containsKey(compl))
            {                
                return new int[] {map.get(compl), i};
            }
            else
            {
                map.put(nums[i],i);
            }
        }
        
        return new int[]{-1,-1};
     }
    
}
