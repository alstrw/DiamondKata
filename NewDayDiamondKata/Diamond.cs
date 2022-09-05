using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewDayDiamondKata
{
    public class Diamond
    {
        private const char FirstCharacter = 'A';
        private const char Space = ' ';
        private const char NewLine = '\n';

        private readonly char _middleCharacter;

        public Diamond(char middleCharacter)
        {
            _middleCharacter = middleCharacter;
        }

        public string Render() => BuildDiamond(_middleCharacter);

        private static string BuildDiamond(char middleCharacter)
        {
            if (middleCharacter.ToString() == "A") return "A";
            if (!char.IsLetter(middleCharacter)) throw new ArgumentException("Input was not a letter");

            var leftSpacing = middleCharacter - FirstCharacter;
            var diamondLength = leftSpacing + 1;

            var lines = new List<string>();
            var middleSpacing = 1;
            
            foreach (var character in Enumerable.Range(FirstCharacter, middleCharacter + 1 - FirstCharacter))
            {
                lines.Add(CreateLine(leftSpacing, character, middleSpacing));
                middleSpacing = UpdateMiddleSpacing(ref leftSpacing, ref diamondLength); 
            }

            return RenderFullDiamond(lines);
        }

        private static string RenderFullDiamond(List<string> lines)
        {
            var half = string.Join(NewLine, lines);
            lines.Reverse();
            lines.RemoveAt(0);
            return half + NewLine + string.Join(NewLine, string.Join( NewLine, lines));
        }
        
        private static string CreateLine(int leftSpacing, int character, int middleSpacing)
        {
            var letter = Convert.ToChar(character);

            var builder = new StringBuilder();
            builder.Append(Space, leftSpacing);
            builder.Append(letter);

            if (letter == FirstCharacter) return builder.ToString();
            
            builder.Append(Space, middleSpacing);
            builder.Append(letter);

            return builder.ToString();
        }
        
        private static int UpdateMiddleSpacing(ref int leftSpacing, ref int diamondLength) => ++diamondLength - --leftSpacing - 2;
    }
}