using NUnit.Framework;
using System.Linq;

namespace Aoc1
{
    
    public class AoCDay1
    {
        private InputParser _parser;
        
        [SetUp]
        public void Setup()
        {
            _parser = new InputParser();
        }

        [Test]
        public void GivenASetOfNineInputs_ShouldGiveSevenIUncreases()
        {
            var input = new List<int>
            {
                199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263
            };

            var result = _parser.GetTotalIncreaseCount(input);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void GivenASetOfNineInputs_ShouldGiveSevens()
        {


            var result = _parser.ReadLinesFromFile("input.txt");

            Assert.That(result, Is.EqualTo(1653));
        }

        [Test]
        public void Test()
        {
            var input = new List<int>
            {
                195,
                197,
                201,
                204,
                203,
                216,
                213,
                215,
                216,
                185,
                188,
                190,
                205,
                218
            };

            var result = _parser.GetTotalIncreaseCount(input);

            Assert.That(result, Is.EqualTo(7));
        }


    }

    public class InputParser
    {
        public int GetTotalIncreaseCount(List<int> input)
        {
            var count = 0;
            var sum1 = 0;
            var sum2 = 0;

            for(var i = 0; i < input.Count - 2; i++)
            {
                if(i == 0)
                {
                    sum1 = input[i] + input[i+1] + input[i+2];
                } else
                {
                    sum2 = input[i] + input[i + 1] + input[i + 2];
                    if (sum2 > sum1)
                        count++;

                    sum1 = sum2;
                }
            }

            return count;
        }

        public int ReadLinesFromFile(string path)
        {
            var lines = (File.ReadAllLines(path));
            var list = new List<int>();
            foreach(var line in lines)
            {
                list.Add(Int32.Parse(line));
            }

            return GetTotalIncreaseCount(list);
        }
    }

}


