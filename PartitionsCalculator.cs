using System;
using System.Collections.Generic;
using System.Text;

class PartitionsCalculator
{
    public static int NumberOfPartitions(int number)
    {
        if (number < 1)
            return 0;

        int total = 0;

        for (int maxSummand = 1; maxSummand <= number; maxSummand++)
            total += NumberOfPartitions(number, maxSummand);

        return total;
    }

    public static int NumberOfPartitions(int number, int maxSummand)
    {
        if (maxSummand > number)
        {
            return 0;
        }
        else if (maxSummand == 0)
        {
            return 0;
        }
        else if (maxSummand == 1)
        {
            return 1;
        }
        else
        {
            return
                NumberOfPartitions(number - 1, maxSummand - 1) +
                NumberOfPartitions(number - maxSummand, maxSummand);
        }
    }

    public static PartitionSet Calculate(int number)
    {
        PartitionSet result = new PartitionSet(number);

        if (number == 1)
        {
            Partition p = new Partition(new int[] { 1 });
            result.Insert(p);
        }
        else
        {
            PartitionSet setMinusOne = Calculate(number - 1);

            for (int i = 0; i < setMinusOne.Count; i++)
            {
                int[] numbers = setMinusOne[i].Numbers;

                for (int j = 0; j < numbers.Length; j++)
                {
                    numbers[j]++;
                    Partition p = new Partition(numbers);
                    result.Insert(p);
                    numbers[j]--;
                }
            }

            // create missing partition (just consisting of '1's)
            int[] partitionOnes = new int[number];
            for (int k = 0; k < partitionOnes.Length; k++)
                partitionOnes[k] = 1;

            Partition pOnes = new Partition(partitionOnes);
            result.Insert(pOnes);
        }
        return result;
    }
}

