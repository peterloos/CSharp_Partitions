using System;
using System.Collections;

class Program
{
    public static void Main()
    {
        Test01a();
        Test01b();
        Test01c();
        Test02a();
        Test02b();
        Test02c();
        Test03a();
        Test03b();
        Test03c();
        Test03d();
        Test04();
        Test05();
        Test06a();
        Test06b();
        Test07();
        Test10a();
        Test10b();
        Test11();
    }

    public static void Test00()
    {
        Partition p = new Partition();
        Console.WriteLine(p);
        Console.WriteLine(p.Number);
    }

    public static void Test01a()
    {
        int[] numbers = { 2 };
        Partition p1 = new Partition(numbers);
        Console.WriteLine(p1);
        numbers = new int[] { 1, 1 };
        Partition p2 = new Partition(numbers);
        Console.WriteLine(p2);
    }

    public static void Test01b()
    {
        int[] numbers = { 1, 2, 3 };
        Partition p1 = new Partition(numbers);
        Console.WriteLine(p1);
        numbers = new int[] { 3, 2, 1 };
        Partition p2 = new Partition(numbers);
        Console.WriteLine(p2);
        Console.WriteLine(p1.Equals(p2));
    }

    public static void Test01c()
    {
        int[] numbers = { 2, 4, 6 };
        for (int i = 0; i < numbers.Length; i++)
            Console.Write("{0} ", numbers[i]);
        Console.WriteLine();
        Partition p = new Partition(numbers);
        int[] numbers1 = p.Numbers;
        for (int i = 0; i < numbers1.Length; i++)
            Console.Write("{0} ", numbers1[i]);
    }

    public static void Test02a()
    {
        PartitionSet ps = new PartitionSet(3);

        // add partitions of number 3 manually
        Partition p;
        p = new Partition(new int[] { 3 });
        ps.Insert(p);
        p = new Partition(new int[] { 1, 2 });
        ps.Insert(p);
        p = new Partition(new int[] { 1, 1, 1 });
        ps.Insert(p);
        Console.WriteLine(ps);
    }

    public static void Test02b()
    {
        PartitionSet ps = new PartitionSet(3);

        // add partitions of number 3 manually
        // (note order of 'Insert' calls)
        Partition p;
        p = new Partition(new int[] { 1, 1, 1 });
        ps.Insert(p);
        p = new Partition(new int[] { 2, 1 });
        ps.Insert(p);
        p = new Partition(new int[] { 3 });
        ps.Insert(p);
        ps.SortDescending();    // sorting partitions
        Console.WriteLine(ps);
    }

    public static void Test02c()
    {
        PartitionSet ps = new PartitionSet(3);

        // add partitions of number 3 manually
        Partition p;
        p = new Partition(new int[] { 3 });
        ps.Insert(p);
        p = new Partition(new int[] { 1, 2 });
        ps.Insert(p);
        p = new Partition(new int[] { 1, 1, 1 });
        ps.Insert(p);
        Console.WriteLine(ps);

        Partition p1 = new Partition(new int[] { 1, 2 });
        Console.WriteLine(ps.Contains (p1));
    }

    // comparing partitions
    public static void Test03a()
    {
        Partition p1 = new Partition (new int[] { 3, 1, 1, 1, 1 });
        Partition p2 = new Partition (new int[] { 2, 2, 2, 1});
        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p1.CompareTo(p2));
        Console.WriteLine(p2.CompareTo(p1));
    }

    public static void Test03b()
    {
        Partition p1 = new Partition(new int[] { 1, 2, 3, 1, 1 });
        Partition p2 = new Partition(new int[] { 1, 2, 3, 2 });
        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p1.CompareTo(p2));
        Console.WriteLine(p2.CompareTo(p1));
    }

    public static void Test03c()
    {
        PartitionSet set = PartitionsCalculator.Calculate(7);
        set.SortDescending();
        Console.WriteLine(set);
    }

    public static void Test03d()
    {
        Partition p1 = new Partition(new int[] { 3, 1, 1, 1, 1 });
        Partition p2 = new Partition(new int[] { 2, 2, 2, 1 });
        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p1 < p2);
        Console.WriteLine(p1 <= p2);
        Console.WriteLine(p1 > p2);
        Console.WriteLine(p1 >= p2);
    }

    // verbose output for calculating partitions of 4
    public static void Test04()
    {
        PartitionSet set = PartitionsCalculator.Calculate(10);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Partitions of {0}:", set.Number);
        Console.WriteLine("{0}", set);
    }

    public static void Test05()
    {
        PartitionSet ps = new PartitionSet(2);

        // add partitions of number 2 manually
        Partition p;
        p = new Partition(new int[] { 2 });
        ps.Insert(p);
        p = new Partition(new int[] { 1, 1 });
        ps.Insert(p);
        Console.WriteLine("Partitions of {0}:", ps.Number);
        for (int i = 0; i < ps.Count; i++)
        {
            p = ps[i];
            Console.WriteLine(p);
        }
    }

    public static void Test06a()
    {
        PartitionSet set = PartitionsCalculator.Calculate(6);
        Console.WriteLine("Partitions of {0}:", set.Number);
        Console.WriteLine("{0}", set);
    }

    public static void Test06b()
    {
        PartitionSet set = PartitionsCalculator.Calculate(6);
        set.SortAscending();
        Console.WriteLine("Partitions of {0}:", set.Number);
        Console.WriteLine("{0}", set);
    }

    public static void Test07()
    {
        PartitionSet set = PartitionsCalculator.Calculate(5);
        if (set is IEnumerable)
        {
            IEnumerator ienum = set.GetEnumerator();

            Console.WriteLine("Partitions of {0}:", set.Number);
            while (ienum.MoveNext())
            {
                Partition p = (Partition)ienum.Current;
                Console.WriteLine(p);
            }
        }
    }

    public static void Test10a()
    {
        PartitionSet set = PartitionsCalculator.Calculate(7);
        Console.WriteLine("Partitions of {0}:", set.Number);
        Console.WriteLine("{0}", set);

        int n;
        n = PartitionsCalculator.NumberOfPartitions(7, 1);
        Console.WriteLine("b(7,1) = {0}", n);
        n = PartitionsCalculator.NumberOfPartitions(7, 2);
        Console.WriteLine("b(7,2) = {0}", n);
        n = PartitionsCalculator.NumberOfPartitions(7, 3);
        Console.WriteLine("b(7,3) = {0}", n);
        n = PartitionsCalculator.NumberOfPartitions(7, 4);
        Console.WriteLine("b(7,4) = {0}", n);
        n = PartitionsCalculator.NumberOfPartitions(7, 5);
        Console.WriteLine("b(7,5) = {0}", n);
        n = PartitionsCalculator.NumberOfPartitions(7, 6);
        Console.WriteLine("b(7,6) = {0}", n);
        n = PartitionsCalculator.NumberOfPartitions(7, 7);
        Console.WriteLine("b(7,7) = {0}", n);
    }

    public static void Test10b()
    {
        PartitionSet set = PartitionsCalculator.Calculate(5);
        Console.WriteLine("Partitions of {0}:", set.Number);
        Console.WriteLine("{0}", set);

        int n;
        n = PartitionsCalculator.NumberOfPartitions(5, 1);
        Console.WriteLine("b(5,1) = {0}", n);
        n = PartitionsCalculator.NumberOfPartitions(5, 2);
        Console.WriteLine("b(5,2) = {0}", n);
        n = PartitionsCalculator.NumberOfPartitions(5, 3);
        Console.WriteLine("b(5,3) = {0}", n);
        n = PartitionsCalculator.NumberOfPartitions(5, 4);
        Console.WriteLine("b(5,4) = {0}", n);
        n = PartitionsCalculator.NumberOfPartitions(5, 5);
        Console.WriteLine("b(5,5) = {0}", n);
        Console.WriteLine();
    }

    public static void Test11()
    {
        const int number = 5;

        PartitionSet set = PartitionsCalculator.Calculate(number);
        Console.WriteLine("Partitions of {0}:", set.Number);
        Console.WriteLine("{0}", set);

        int numPartitions = PartitionsCalculator.NumberOfPartitions(number);
        Console.WriteLine("b({0}) = {1}", number, numPartitions);
    }
}

