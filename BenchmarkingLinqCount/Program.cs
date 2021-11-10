using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using System.Linq;

namespace BenchmarkingLinqCount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<SampleBenchmarkClass>();
            Console.ReadLine();
        }
    }

    [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class SampleBenchmarkClass
    {
        SampleData sampleData = new SampleData();

        [Benchmark]
        public int LinqWhere()
        {
            return sampleData.Data.Where(x => x.SampleProp % 2 == 0).Count();
        }

        [Benchmark]
        public int LinqCount()
        {
            return sampleData.Data.Count(x => x.SampleProp % 2 == 0);
        }

        [Benchmark]
        public int ForLoop()
        {
            var count = 0;
            for (int i = 0; i < sampleData.Data.Count; i++)
            {
                if (sampleData.Data[i].SampleProp % 2 == 0)
                {
                    count++;
                }
            }
            return count++;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var count = 0;
            foreach (var item in sampleData.Data)
            {
                if (item.SampleProp % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
