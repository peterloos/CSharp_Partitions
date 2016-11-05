using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class PartitionSet : IEnumerable, IEnumerator
{
    private int number;
    private List<Partition> partitions;
    private int index;

    public PartitionSet(int number)
    {
        this.number = number;
        this.partitions = new List<Partition>();
        this.index = -1;
    }

    // number
    public int Number
    {
        get
        {
            return this.number;
        }
    }

    // number of partitions
    public int Count
    {
        get
        {
            return this.partitions.Count;
        }
    }

    // indexer
    public Partition this[int i]
    {
        get
        {
            return (Partition) this.partitions[i].Clone();
        }
    }

    // public interface
    public void Insert(Partition p)
    {
        if (! this.partitions.Contains(p))
            this.partitions.Add(p);
    }

    public bool Contains(Partition p)
    {
        return this.partitions.Contains (p);
    }

    public void SortDescending()
    {
        this.partitions.Sort();
        this.partitions.Reverse();
    }

    public void SortAscending()
    {
        this.partitions.Sort();
    }

    // overrides
    public override String ToString()
    {
        StringBuilder sb = new StringBuilder();
        String format = (this.partitions.Count < 10) ?
            "{0}: {1}" : "{0,2}: {1}";
        for (int i = 0; i < this.partitions.Count; i++)
        {
            sb.AppendFormat(format, i + 1, this.partitions[i]);
            sb.AppendLine();
        }
        return sb.ToString();
    }

    // implementation of interface 'IEnumerable'
    public IEnumerator GetEnumerator()
    {
        this.SortAscending();
        return this;
    }
    
    // implementation of interface 'IEnumerator'
    public Object Current
    {
        get
        {
            return this.partitions[this.index];
        }
    }

    public bool MoveNext()
    {
        this.index++;
        if (this.index < this.partitions.Count)
        {
            return true;
        }
        else
        {
            this.index = -1;
            return false;
        }
    }

    public void Reset()
    {
        this.index = -1;
    }
}