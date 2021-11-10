using System;
using Bogus;
using System.Collections.Generic;

namespace BenchmarkingLinqCount
{
    public class SampleData
    {
        public SampleData()
        {
            Randomizer.Seed = new Random(0);
            var faker = new Faker<SampleClass>();

            Data = faker
                .RuleFor(x => x.SampleProp, faker => faker.Random.Number())
                .Generate(1000);
        }

        public List<SampleClass> Data { get; private set; }
    }

}
