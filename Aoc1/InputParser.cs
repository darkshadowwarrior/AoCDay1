namespace Aoc1
{
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

        public int GetTotalPowrConsumption(string[] lines, int bitRange)
        {
            var bitArray1 = new int[bitRange];
            var bitArray2 = new int[bitRange];

            for (var i = 0; i < bitRange; i++)
            {
                var result = GetBitValue(lines, i);
                bitArray1[i] = result.Item1;
                bitArray2[i] = result.Item2;
            }

            var gString = bitArray1.Aggregate(string.Empty, (s, i) => s + i.ToString());
            var eString = bitArray2.Aggregate(string.Empty, (s, i) => s + i.ToString());

            var gamma = Convert.ToInt32(gString, 2);
            var epsilon = Convert.ToInt32(eString, 2);

            return (gamma * epsilon);
        }

        public int GetLifeSupportRating(string[] lines, int i)
        {
            var oGR = GetOxygenGeneratorRating(lines, i);
            var cSR = GetCO2ScrubberRating(lines, i);

            return oGR * cSR;
        }

        public int GetOxygenGeneratorRating(string[] lines, int i)
        {
            for (var j = 0; j < i; j++)
            {
                if (lines.Length == 1) break;
                lines = GetFilteredList(lines, j, "OGR");
            }   

            var arrString = lines.ToArray().Aggregate(string.Empty, (s, i) => s + i.ToString());

            return Convert.ToInt32(arrString, 2);
        }

        public int GetCO2ScrubberRating(string[] lines, int i)
        {
            for (var j = 0; j < i; j++)
            {
                if (lines.Length == 1) break;
                lines = GetFilteredList(lines, j, "CO2");
            }

            var arrString = lines.ToArray().Aggregate(string.Empty, (s, i) => s + i.ToString());

            return Convert.ToInt32(arrString, 2);
        }

        private string[] GetFilteredList(string[] lines, int i, string type)
        {
            var oneList = new List<string>();
            var zeroList = new List<string>();
            var oneCount = 0;
            var zeroCount = 0;

            foreach (var line in lines)
            {
                if (line[i] == '1')
                {
                    oneList.Add(line);
                    oneCount++;
                }
                else
                {
                    zeroList.Add(line);
                    zeroCount++;
                }
            }


            switch (type)
            {
                case "CO2":
                    if (oneCount == zeroCount)
                    {
                        return zeroList.ToArray();
                    }
                    return (oneCount > zeroCount) ? zeroList.ToArray() : oneList.ToArray();
                case "OGR":
                    if (oneCount == zeroCount)
                    {
                        return oneList.ToArray();
                    }
                    return (oneCount > zeroCount) ? oneList.ToArray() : zeroList.ToArray();
            }

            return new string[0];
        }

        private static Tuple<int, int> GetBitValue(string[] lines, int i)
        {
            var ones = 0;
            var zeros = 0;
            foreach (var line in lines)
            {
                if (line[i] == '0') zeros += 1;
                if (line[i] == '1') ones += 1;
            }

            var res1 = (zeros > ones) ? 0 : 1;
            var res2 = (zeros > ones) ? 1 : 0;

            return Tuple.Create(res1, res2);
        }

        public List<int> ConvertInputLinesToInts(string[] lines)
        {
            var list = new List<int>();
            foreach (var line in lines)
            {
                list.Add(Int32.Parse(line));
            }

            return list;
        }

        public List<KeyValuePair<string, int>> ConvertInputLinesToDirections(string[] lines)
        {
            var list = new List<KeyValuePair<string, int>>();
            foreach (var line in lines)
            {
                var lineSplit = line.Split(' ');
                list.Add(new KeyValuePair<string, int>(lineSplit[0], Int32.Parse(lineSplit[1])));
            }

            return list;
        }

        public int GetFinalHorizontalPosition(List<KeyValuePair<string, int>> pairs)
        {
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;

            foreach(var pair in pairs)
            {
                switch(pair.Key)
                {
                    case "forward": 
                        horizontalPosition += pair.Value;
                        depth += (aim * pair.Value);
                        break;
                    case "down": 
                        aim += pair.Value;
                        break;
                    case "up": 
                        aim -= pair.Value;
                        break;

                }
            }

            return horizontalPosition * depth;
        }
    }

}


