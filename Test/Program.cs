namespace Test
{
    internal class Program
    {
        static double ComputeMean(double[] values)
        {
            double sumOfValues = 0;
            int n = values.Length;
            for (int i = 0; i < n; i++)
            {
                sumOfValues += values[i];
            }
            double mean = sumOfValues / n;
            return mean;
        }
        static double ComputeMode(double[] values)
        {
            int n = values.Length;
            double mode = values[0];
            int maxCount = 1;
            int currentCount = 1;

            for (int i = 1; i < n; i++)
            {
                if (values[i] == values[i - 1])
                {

                    currentCount++;
                }
                else
                {

                    currentCount = 1;
                }


                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    mode = values[i];
                }
            }
            return mode;
        }
        static (double, double) ComputeMedian(double[] values)
        {
            int n = values.Length;
            int medianPosition;
            int medianIndex;
            double medianOdd;
            if (n % 2 == 1)  // if n is odd
            {
                medianPosition = (n + 1) / 2;
                medianIndex = medianPosition - 1;
                medianOdd = values[medianIndex];

                return (medianOdd, 0);
            }

            int firstMedianPosition;
            int secondMedianPosition;
            int firstMedianIndex;
            int secondMedianIndex;
            double firstMedianValue;
            double secondMedianValue;
            if (n % 2 == 0) // if n is even
            {
                firstMedianPosition = n / 2;
                secondMedianPosition = (n / 2) + 1;
                firstMedianIndex = firstMedianPosition - 1;
                secondMedianIndex = secondMedianPosition - 1;

                firstMedianValue = values[firstMedianIndex];
                secondMedianValue = values[secondMedianIndex];

                return (firstMedianValue, secondMedianValue);
            }
            return (0, 0);
        }


        static void Main(string[] args)
        {
            double[] data = { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };
            data.Sort();

            // Compute Mean : 
            double mean = ComputeMean(data);
            Console.WriteLine($"Mean of values = {mean}");

            // Compute Mode : 
            double mode = ComputeMode(data);
            Console.WriteLine($"Mode = {mode}");

            // Compute Median : 
            var (firstMedian, secondMedian) = ComputeMedian(data);
            Console.WriteLine($"first median = {firstMedian} and second median = {secondMedian}");

        }
    }
}

/*
Steps & Layout: 
1. Create Method named : "ComputeMean" to compute the mean
2. Create Method named : "ComputeMode" to compute the mode
3. Create Method named : "ComputeMedian" to compute the median
4. Create Method named : "ComputeStandardDeviation" to compute the Deviation
5. Create Method named : "ComputeSumOfDeviation" to compute the summation of Deviation 
6. Create Method named : "ComputeVariance" to compute the Variance , and will use method "ComputeStandardDeviation" in it
7. Create Method named : "ComputePercentile" to compute P20 , P50 and any P(n)
8. Create Method named : "ComputeQuartiles" to compute Q1, Q2, Q3 | and will do if_conditon to check : if parameter was :
1 -> then will compute "First_Quartile Q1", 2 -> then will compute "Second_Quartile Q2", 3 -> then will compute "Third_Quartile Q3"
9. Create Method named : "ComputeRange" to compute range
10. Create Method named : "ComputeIQR" to compute Interquartile Range , and will use method "ComputeQuartiles"
 
 */


