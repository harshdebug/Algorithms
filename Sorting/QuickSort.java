public class QuickSort
{
    public static void main(String[] args)
    {
        int[] arr = new int[args.length];
        
        for(int k=0; k<args.length; k++)
        {
            arr[k] = Integer.parseInt(args[k]);  
        }
        
        
        QuickSort qs = new QuickSort();
        qs.quickSort(arr, 0, arr.length -1);
        
        for(int i=0; i< arr.length; i++)
        {
            System.out.print(arr[i]+" ");
        }
        
    }
    
    public void quickSort(int[] arr, int left, int right)
    {
        if(left >= right)
        {
            return;
        }
        
        //pivot is the element at arr[right]
        
        int pivFinalIdx = left;
        
        for(int i=left; i<right; i++)
        {
            if(arr[i] < arr[right])
            {
                swap(arr, i, pivFinalIdx++);
            }
        }
        
        swap(arr, pivFinalIdx, right);
        
        quickSort(arr, left, pivFinalIdx -1);
        quickSort(arr, pivFinalIdx + 1, right);
    }
    
    public void swap(int[] arr, int x, int y)
    {
        int temp = arr[x];
        arr[x] = arr[y];
        arr[y] = temp;
    }
}
