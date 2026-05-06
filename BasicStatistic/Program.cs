using System.Formats.Asn1;
using System.Runtime.InteropServices;

namespace BasicStatistic
{
    internal class Program
    {
        static double ComputeMean(double[] values)  
        {
            double sumOfValues = 0;
            int n = values.Length;
            foreach (double x in values)
            {
                sumOfValues += x;
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
        static double ComputeMedianOdd(double[] values)
        {
            int n = values.Length;
            int medianPosition = (n + 1) / 2;
            int medianIndex = medianPosition - 1;
            double medianOdd = values[medianIndex];

            return (medianOdd);
        }
        static (double,double) ComputeMedianEven(double[] values)
        {
            int n = values.Length;
            int firstMedianPosition = n / 2; ;
            int secondMedianPosition = (n / 2) + 1;
            int firstMedianIndex = firstMedianPosition - 1;
            int secondMedianIndex = secondMedianPosition - 1;

            double firstMedianValue = values[firstMedianIndex];
            double secondMedianValue = values[secondMedianIndex];

            return (firstMedianValue, secondMedianValue);
            
        }
        static double[] ComputeStandardDeviation(double[] values, double mean)
        {
            int n = values.Length;
            double[] deviations = new double[n];

            for (int i = 0; i < n; i++)
            {
                deviations[i] = values[i] - mean;
                deviations[i] = Math.Round(deviations[i], 2);
            }
            return deviations;
        }
        static double ComputeSumOfStandardDeviation(double[] values, double mean, double[] deviations)
        {
            double sumOfDeviations = 0;
            foreach (double x in deviations)
            {
                sumOfDeviations += x;
            }
            sumOfDeviations = Math.Round(sumOfDeviations, 2);
            return sumOfDeviations;
        }
        static double ComputeVariance(double[] values, double[] deviations)
        {
            int n = values.Length;
            double[] squaredDeviations = new double[n];
            for (int i = 0; i < n; i++)
            {
                squaredDeviations[i] = deviations[i] * deviations[i];
            }
            // To compute sum of this squared deviations : 
            double sumOfSquaredDeviations = 0;
            foreach (double element in squaredDeviations)
            {
                sumOfSquaredDeviations += element;
            }
            // To compute Variance : 
            double variance = sumOfSquaredDeviations / (n - 1);

            return variance;
        }
        static double ComputePercentile(double[] values, double p)
        {
            // compute k : 
            int n = values.Length;
            double kPosition = (p / 100) * n; 
            int kIndex;
            // check if k is integer or decimal : 
            if (kPosition % 1 == 0) // check if k is decimal or not | if true means k is an integar
            {
                kIndex = (int)kPosition - 1;
                double percentileAverageValue = (values[kIndex] + values[kIndex + 1]) / 2;
                return percentileAverageValue;
            }
            else // then k is decimal
            {
                kPosition = Math.Ceiling(kPosition);
                kIndex = (int)kPosition - 1;
                double percentileValue = values[kIndex];
                return percentileValue;
            }
        }
        static double ComputeQuartiles(double[] values, int Q)
        {
            switch (Q)
            {
                case 1:
                    double Q1 = ComputePercentile(values, 25);
                    return Q1;
                    break;
                case 2:
                    double Q2 = ComputePercentile(values, 50);
                    return Q2;
                    break;
                case 3:
                    double Q3 = ComputePercentile(values, 75);
                    return Q3;
                    break;
                default:
                    Console.WriteLine("Sorry! You can just enter 1, 2 and 3");
                    return 0;
                    break;
            }
        }
        static double ComputeRange(double[] values)
        {
            int n = values.Length;
            double range = values[n - 1] - values[0];
            return range;
        }
        static double ComputeIQR(double[] values)
        {
            double Q1 = ComputeQuartiles(values, 1);
            double Q3 = ComputeQuartiles(values, 3);
            double IQR = Q3 - Q1;
            return IQR;
        }
        static string IsOutlier(double[] values, double value)  // 3 steps to complete method :
        {
            int n = values.Length;
            // Step 1 : compute IQR :
            double Q1 = ComputeQuartiles(values, 1);
            double Q3 = ComputeQuartiles(values, 3);
            double IQR = Q3 - Q1;
            // Step 2 : Compute Lower Fence and Upper Fence : 
            double lowerFence = Q1 - (1.5 * IQR);
            double upperFence = Q3 + (1.5 * IQR);
            // Step 3 : Check if this value is ine the interval between lower fence and upper fence by If_statement : 
            if (value < lowerFence || value > upperFence)
            {
                return "Outlier";
            }
            else
            {
                return "Not Outlier";
            }    
           
        }
        static void DisplayOutliersStatus(double[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (IsOutlier(values, values[i]) == "Not Outlier")
                {
                    Console.WriteLine($"{values[i]} is Not Outlier");
                }
                else
                {
                    Console.WriteLine($"{values[i]} is Outlier");
                }
            }
        }

        static void Main(string[] args)
        {
            double[] data = {115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110};
            data.Sort();
            int n = data.Length;

            // Compute Mean : mean = 161.28
            double mean = ComputeMean(data);
            Console.WriteLine("Compute Mean : ");
            Console.WriteLine($"Mean = {mean}");
            Console.WriteLine("-----------------------------------------------------------------");

            // Compute Mode : 
            double mode = ComputeMode(data);
            Console.WriteLine("Compute Mode : ");
            Console.WriteLine($"Mode = {mode}");
            Console.WriteLine("-----------------------------------------------------------------");

            // Compute Median : 
            Console.WriteLine("Compute Median : ");
            if (n % 2 == 1 )  // if n is odd
            {
                double median = ComputeMedianOdd(data);
                Console.WriteLine($"Median = {median}");
            }
            else
            {
                var (firstMedian, secondMedian) = ComputeMedianEven(data);
                Console.WriteLine($"First Median = {firstMedian} and Second Median = {secondMedian}");
            }
            Console.WriteLine("-----------------------------------------------------------------");

            // Compute Standard Deviation : 
            Console.WriteLine("Compute Standard Deviation : ");
            double[] deviations = ComputeStandardDeviation(data, mean);
            for (int i = 0; i < deviations.Length; i++)
            {
                Console.WriteLine($"deviation for {data[i]} = {deviations[i]}");
            }
            Console.WriteLine("-----------------------------------------------------------------");

            // Compute Summation Of Standared Deviation : 
            Console.WriteLine("Compute Summation Of Standard Deviation : ");
            double sumOfStandardDeviations = ComputeSumOfStandardDeviation(data, mean, deviations);
            Console.WriteLine($"Summation Of Deviations = {sumOfStandardDeviations}");
            Console.WriteLine("-----------------------------------------------------------------");

            // Compute Variance : 
            Console.WriteLine("Compute Variance : ");
            double variance = ComputeVariance(data, deviations);
            Console.WriteLine($"Variance = {variance}");
            Console.WriteLine("-----------------------------------------------------------------");

            // Compute Percentile : 
            Console.WriteLine("Compute P20 and P50 : ");
            double p20 = ComputePercentile(data, 20);
            double p50 = ComputePercentile(data, 50);
            Console.WriteLine($"P20 = {p20}");
            Console.WriteLine($"P50 = Median = {p50}");
            Console.WriteLine("-----------------------------------------------------------------");

            // Compute Quartiles : 
            Console.WriteLine("Compute Q1, Q2 and Q3 : ");
            double Q1 = ComputeQuartiles(data, 1);
            double Q2 = ComputeQuartiles(data, 2);
            double Q3 = ComputeQuartiles(data, 3);
            Console.WriteLine($"Q1 = P25 = {Q1}");
            Console.WriteLine($"Q2 = P50 = Median = {Q2}");
            Console.WriteLine($"Q3 = P75 = {Q3}");
            Console.WriteLine("-----------------------------------------------------------------");

            // Compute Range : 
            Console.WriteLine("Compute Range : ");
            double range = ComputeRange(data);
            Console.WriteLine($"Range = {range}");
            Console.WriteLine("-----------------------------------------------------------------");

            // Compute IQR : 
            Console.WriteLine("Compute IQR : ");
            double IQR = ComputeIQR(data);
            Console.WriteLine($"IQR = {IQR}");
            Console.WriteLine("-----------------------------------------------------------------");

            // Detected any element is outlier or not : 
            Console.WriteLine("Check if an input I enter is outlier or not  : ");
            Console.WriteLine($"number : 179 is {IsOutlier(data, 179)}");
            Console.WriteLine($"number : 1099 is {IsOutlier(data, 1099)}");
            Console.WriteLine("-----------------------------------------------------------------");

            // Display all elements are outliers or not : 
            Console.WriteLine("Display each input number is an outlier or not : ");
            DisplayOutliersStatus(data);
            Console.WriteLine("-----------------------------------------------------------------");
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
8. Create Method named : "ComputeQuartiles" to compute Q1, Q2, Q3 | and will do switch_statement to check : if parameter was :
1 -> then will compute "First_Quartile Q1", 2 -> then will compute "Second_Quartile Q2", 3 -> then will compute "Third_Quartile Q3"
9. Create Method named : "ComputeRange" to compute range
10. Create Method named : "ComputeIQR" to compute Interquartile Range , and will use method "ComputeQuartiles"
 
 */

