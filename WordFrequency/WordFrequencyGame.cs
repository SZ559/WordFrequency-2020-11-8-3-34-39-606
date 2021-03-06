﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            var spacesRegex = @"\s+";
            string[] splitStringArray = Regex.Split(inputStr, spacesRegex);

            Dictionary<string, Input> inputMap = GetInputMap(splitStringArray);
            var inputList = inputMap.Values.ToList();

            inputList.Sort((input1, input2) => input2.WordCount - input1.WordCount);

            List<string> renderedInputList = RenderInputList(inputList);

            return string.Join("\n", renderedInputList.ToArray());
        }

        private List<string> RenderInputList(List<Input> inputList)
        {
            return inputList.Select(input => input.ToString()).ToList();
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
