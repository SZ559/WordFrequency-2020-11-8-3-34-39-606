using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            string[] splitStringArray = Regex.Split(inputStr, @"\s+");

            Dictionary<string, Input> inputMap = GetInputMap(splitStringArray);
            var inputList = inputMap.Values.ToList();

            inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            List<string> strList = new List<string>();

            foreach (Input w in inputList)
            {
                string s = w.Value + " " + w.WordCount;
                strList.Add(s);
            }

            return string.Join("\n", strList.ToArray());
        }

        private Dictionary<string, Input> GetInputMap(string[] splitStringArray)
        {
            Dictionary<string, Input> map = new Dictionary<string, Input>();
            foreach (var splitString in splitStringArray)
            {
                if (map.ContainsKey(splitString))
                {
                    var updatedWordCount = map[splitString].WordCount + 1;
                    map[splitString] = new Input(splitString, updatedWordCount);
                }
                else
                {
                    var input = new Input(splitString, 1);
                    map.Add(input.Value, input);
                }
            }

            return map;
        }
    }
}
