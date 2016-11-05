using System;
using System.Text;

class Partition : IComparable, ICloneable
{
    private int[] numbers;

    // c'tor
    public Partition()
    {
        this.numbers = new int[1];
        this.numbers[0] = 0;
    }

    public Partition(int[] numbers)
    {
        this.numbers = (int[])numbers.Clone();
        Array.Sort(this.numbers);
        Array.Reverse(this.numbers);
    }

    // properties
    public int Number
    {
        get
        {
            int number = this.numbers[0];
            for (int i = 1; i < this.numbers.Length; i++)
                number += this.numbers[i];
            return number;
        }
    }

    public int Length
    {
        get
        {
            return this.numbers.Length;
        }
    }

    public int[] Numbers
    {
        get
        {
            return (int[]) this.numbers.Clone();
        }
    }

    // overrides
    public override String ToString()
    {
        if (this.numbers.Length == 0)
            return "";

        StringBuilder tmp = new StringBuilder();
        tmp.AppendFormat("{0} = {1}", this.Number, this.numbers[0]);
        for (int i = 1; i < this.numbers.Length; i++)
            tmp.AppendFormat(" + {0}", this.numbers[i]);
        return tmp.ToString();
    }

    public override bool Equals(Object o)
    {
        if (!(o is Partition))
            throw new ArgumentException("Wrong parameter type");

        Partition p = (Partition) o;

        // partitions of different numbers can't be equal
        if (this.Number != p.Number)
            return false;

        // partitions with a different number of summands can't be equal
        if (this.Length != p.Length)
            return false;

        // compare summands
        for (int i = 0; i < this.numbers.Length; i++)
            if (this.numbers[i] != p.numbers[i])
                return false;

        return true;
    }

    public override int GetHashCode()
    {
        return this.numbers.GetHashCode();
    }

    // implementation of interface 'IComparable'
    public int CompareTo(Object o)
    {
        if (!(o is Partition))
            throw new ArgumentException("Wrong parameter type");

        Partition p = (Partition)o;

        if (this.Number != p.Number)
            throw new ArgumentException("Number of partitions doesn't match");

        if (this.Equals(p))
            return 0;

        int min = (this.numbers.Length > p.numbers.Length) ?
            p.numbers.Length : this.numbers.Length;

        for (int i = 0; i < min; i++)
        {
            if (this.numbers[i] > p.numbers[i])
                return 1;
            if (this.numbers[i] < p.numbers[i])
                return -1;
        }

        return 0;
    }

    public static bool operator ==(Partition p1, Partition p2)
    {
        return p1.Equals(p2);
    }

    public static bool operator !=(Partition p1, Partition p2)
    {
        return !(p1 == p2);
    }

    public static bool operator <(Partition p1, Partition p2)
    {
        return p1.CompareTo(p2) < 0;
    }

    public static bool operator <=(Partition p1, Partition p2)
    {
        return p1.CompareTo(p2) <= 0;
    }

    public static bool operator >(Partition p1, Partition p2)
    {
        return !(p1 <= p2);
    }

    public static bool operator >=(Partition p1, Partition p2)
    {
        return !(p1 < p2);
    }

    // implementation of interface 'ICloneable'
    public Object Clone()
    {
        return new Partition(this.numbers);
    }
}