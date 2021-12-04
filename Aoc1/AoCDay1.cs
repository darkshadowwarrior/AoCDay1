using NUnit.Framework;

namespace Aoc1
{

    public class AoCDay1
    {
        private InputParser _parser;
        private FileReader _fileReader;
        
        [SetUp]
        public void Setup()
        {
            _parser = new InputParser();
            _fileReader = new FileReader();
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
            var lines = _fileReader.ReadLinesFromFile("input.txt");
            var input = _parser.ConvertInputLinesToInts(lines);
            var result = _parser.GetTotalIncreaseCount(input);

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

}


