using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 1,2,2,1 };
            int[] nums2 = { 2,2 };
            Intersection(nums1, nums2);
            Console.WriteLine("");
            Console.ReadLine();

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 1,3,5,6 };
            Console.WriteLine("target number:");
            //int target = int.Parse(Console.ReadLine());
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Index Position of target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 2,2,3,4 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Array doesn't have any lucky number");
            else
                Console.WriteLine("Lucky number in the array is {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun integer in the array {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "lima" });
            cities.Add(new List<string>() { "lima", "sao paulo" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] array = {-2,1,-3,4,-1,2,1,-5,4 };
            int Ms = MaximumSum(array);
            Console.WriteLine("contigous sub array with largest sum is {0}", Ms);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minimum cost to reach the top floor {0}", minCost);
            Console.WriteLine();
        }

        //Question 1
        

        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                //intersection of two arrays
                int[] intersection = nums1.Intersect(nums2).ToArray();
                //for handling  no common numbers
                if (intersection.Length == 0)
                    Console.WriteLine("No matches");
                else
                {
                    Console.Write(intersection[0]);
                    for (int i = 1; i < intersection.Length; i++)
                        Console.Write(", {0}", intersection[i]);
                    Console.Read();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception in Intersection \n");
                throw;
            }
        }

        //Question 2:
        

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int begin = 0;
                int stop  = nums.Length - 1;
                while (begin <= stop)
                {
                    int middle = (begin + stop) / 2;
                    //comparing 
                    if (nums[middle] == target)
                        return middle;

                    else if (nums[middle] < target)
                        //increse begin value
                        begin = middle + 1;

                    else
                        ////decrease stop value
                        stop = middle - 1;
                }

                //returns the insert position
                return stop + 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception occured \n");
                return -1;
                throw;

            }
        }


        //Question 3
        

        private static int LuckyNumber(int[] nums)
        {
            try
            {
                Dictionary<int, int> frequency = new Dictionary<int, int>();
                //checking the constraints
                if (nums.Length >= 1 && nums.Length <= 500)
                {
                    foreach (int x in nums)
                    {
                        //checking the constraints
                        if (x <= 500)
                        {
                            if (frequency.ContainsKey(x))
                                frequency[x]++;
                            else
                                frequency.Add(x, 1);
                        }
                        else
                            //throwing exception 
                            throw new Exception();
                    }

                    int luckyNum = -1;

                    foreach (var n in frequency.Keys)
                    {
                        // checking if number is equal to  frequency
                        //and if the value is greater than previously stored value
                        if (n == frequency[n] && n > luckyNum)
                            luckyNum = n;
                    }

                    return luckyNum;
                }
                else
                    //throwing exception
                    throw new Exception();

            }
            catch (Exception)
            {
                Console.WriteLine("Exception occurred \n");
                return -1;
                throw;
            }
        }

        //Question 4:
       
        private static int GenerateNums(int n)
        {
            try
            {
                //checking constraints
                if (n >= 0 && n <= 100)
                {
                    int[] nums = new int[n + 1];
                    nums[0] = 0;
                    nums[1] = 1;
                    int nlen = n / 2;
                    for (int i = 1; i <= nlen; i++)
                    {
                        if ((2 * i) < n + 1)
                            nums[2 * i] = nums[i];
                        if (((2 * i) + 1) < n + 1)
                            nums[(2 * i) + 1] = nums[i] + nums[i + 1];
                    }
                    int maxnum = nums.Max();
                    return maxnum;
                }
                else
                    throw new Exception();

            }
            catch (Exception)
            {
                Console.WriteLine("Constraints violated: Exception occurred in GenerateNums funtion\n");
                return -1;
                throw;
            }

        }

        //Question 5
        
        public static string DestCity(List<List<string>> paths)
        {
            try
            {
                List<string> list = new List<string>();
                foreach (var element in paths)
                {
                    list.Add(element[1]);
                }
                foreach (var path in paths)
                {
                    if (list.Contains(path[0]))
                    {
                        list.Remove(path[0]);
                    }
                }
                return (list.Last());
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 6:
        
        private static void targetSum(int[] nums, int target)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;
                if (nums.Length >= 2 && nums.Length <= 3 * 104)
                {
                    while (left < right)
                    {
                        if (nums[left] >= -1000 && nums[left] <= 1000 && nums[right] >= -1000 && nums[right] <= 1000)
                        {
                            if ((nums[left] + nums[right]) < target)
                                left++;
                            else if ((nums[left] + nums[right]) > target)
                                right--;
                            else if ((nums[left] + nums[right]) == target)
                                break;
                        }
                        else
                            throw new Exception();
                    }
                    Console.WriteLine("{0},{1}", left + 1, right + 1);
                    Console.ReadLine();
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Constraint violated:Exception occurred in targetSum function\n");
                //throw;
            }
        }

        //Question 7
        
        private static void HighFive(int[,] items)
        {
            try
            {
                List<int[]> list = new List<int[]>();
                List<int[,]> result = new List<int[,]>();
                for (int i = 0; i < items.GetLength(0); i++)
                {
                    //adding the elements to list
                    list.Add(new int[] { items[i, 0], items[i, 1] });
                }
                //sorting the elements
                list.Sort((p, q) => { return (p[0] < q[0]) ? -1 : ((p[0] == q[0]) ? ((p[1] <= q[1]) ? 1 : -1) : 1); });
                int a = list[0][0];
                int count = 1;
                int sum = list[0][1];
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i][0] == a && count < 5)
                    {
                        sum += list[i][1];
                        count += 1;
                    }
                    else if (list[i][0] != a)
                    {

                        result.Add(new int[,] { { a, sum / 5 } });
                        Console.Write("[[" + a + "," + sum / 5 + "]" + ",");
                        a = list[i][0];
                        count = 1;
                        sum = list[i][1];
                    }
                }
                result.Add(new int[,] { { a, sum / 5 } });
                Console.Write("[" + a + "," + sum / 5 + "]]");
                Console.Write("\n");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 8
        

        private static void RotateArray(int[] arr, int n)
        {
            try
            {
                var loopindex = 0;
                var currentindex = 0;
                var current = arr[currentindex];
                //checking constraints
                if (arr.Length >= 1 && arr.Length <= 105 && n >= 0 && n <= 105)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        //checking constraints
                        if (arr[i] >= -231 && arr[i] <= 230)
                        {
                            currentindex = (currentindex + n) % arr.Length;

                            // replacing current index with next index using temp variable
                            var temp = arr[currentindex];
                            arr[currentindex] = current;
                            current = temp;

                            if (currentindex == loopindex)
                            {
                                currentindex = (++loopindex) % arr.Length;
                                current = arr[currentindex];
                            }
                        }
                        else
                            throw new Exception();
                    }
                    Console.WriteLine(String.Join(",", arr));

                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Constraints violated:Exception occurred in RotateArray function\n");
                //throw;
            }
        }

        //Question 9
        

        private static int MaximumSum(int[] arr)
        {
            try
            {
                //checking constraints
                if (arr.Length >= 1 && arr.Length <= 30000)
                {
                    var max1 = arr[0];
                    var max2 = arr[0];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] >= -100000 && arr[i] <= 100000)
                        {
                            max2 = Math.Max(arr[i], max2 + arr[i]);
                            max1 = Math.Max(max1, max2);
                        }
                        else
                            throw new Exception();
                    }
                    return max1;
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Constraint Violated:Exception occurred in MaximumSum function\n");
                return 0;
                throw;
            }
        }

        //Question 10
        

      

        private static int MinCostToClimb(int[] costs)
        {
            try
            {
                int n = costs.Length;
                if (n == 0)
                    return 0;
                else if (n == 1)
                    return costs[0];
                else if (n <= 1000)
                {
                    for (int i = 2; i < n; i++)
                    {
                        //handling constraints
                        if (costs[i] >= 0 && costs[i] <= 999)
                            //calculating the minimum cost
                            costs[i] = Math.Min(costs[i - 1], costs[i - 2]) + costs[i];
                        else
                            throw new Exception();
                    }
                    return Math.Min(costs[n - 2], costs[n - 1]);
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Constraints violated:Exception occurred in MinCostToClimb function\n");
                return 0;
                throw;
            }
        }
    }
}
