using NUnit.Framework;

namespace Aoc1
{
    public class AoCDay3
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
        public void GivenADiagnosticReport_ThePowerConsumptionWas198()
        {
            var lines = _fileReader.ReadLinesFromFile("day3_testinput_1.txt");

            var result = _parser.GetTotalPowrConsumption(lines, 5);

            Assert.That(result, Is.EqualTo(198));
        }

        [Test]
        public void GivenADiagnosticReport_ThePowerConsumptionWas4174964()
        {
            var lines = _fileReader.ReadLinesFromFile("day3_input.txt");

            var result = _parser.GetTotalPowrConsumption(lines, 12);

            Assert.That(result, Is.EqualTo(4174964));
        }

        [Test]
        public void GivenADiagnosticReport_TheLifeSupportRatingWas230()
        {
            var lines = _fileReader.ReadLinesFromFile("day3_testinput_1.txt");

            var result = _parser.GetLifeSupportRating(lines, 5);

            Assert.That(result, Is.EqualTo(230));
        }

        [Test]
        public void GivenADiagnosticReport_TheLifeSupportRatingWas_DUNNO()
        {
            var lines = _fileReader.ReadLinesFromFile("day3_input.txt");

            var result = _parser.GetLifeSupportRating(lines, 12);

            Assert.That(result, Is.EqualTo(4474944));
        }
    }
}
