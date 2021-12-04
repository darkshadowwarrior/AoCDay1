using NUnit.Framework;

namespace Aoc1
{
    public class AoCDay2
    {
        private FileReader _fileReader;
        private InputParser _parser;

        [SetUp]
        public void Setup()
        {
            _fileReader = new FileReader();
            _parser = new InputParser();
        }

        [Test]
        public void GivenASetOfInstructions_TheResultShouldBe150()
        {
            var lines = _fileReader.ReadLinesFromFile("day2_testinput_1.txt");

            var input = _parser.ConvertInputLinesToDirections(lines);

            var result = _parser.GetFinalHorizontalPosition(input);

            Assert.That(result, Is.EqualTo(900));
        }

        [Test]
        public void GivenASetOfInstructions_TheResultShouldBe1056()
        {
            var lines = _fileReader.ReadLinesFromFile("day2_testinput_2.txt");

            var input = _parser.ConvertInputLinesToDirections(lines);

            var result = _parser.GetFinalHorizontalPosition(input);

            Assert.That(result, Is.EqualTo(14344));
        }

        [Test]
        public void GivenASetOfInstructions_TheResultShouldBe_DUNNO()
        {
            var lines = _fileReader.ReadLinesFromFile("day2_input.txt");

            var input = _parser.ConvertInputLinesToDirections(lines);

            var result = _parser.GetFinalHorizontalPosition(input);

            Assert.That(result, Is.EqualTo(1845455714));
        }
    }
}
