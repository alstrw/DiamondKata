using System;

namespace NewDayDiamondKata
{
    public class Diamond
    {
        public string Create(char middleCharacter)
        {
            if (middleCharacter.ToString() == "A") return "A";
            if (!char.IsLetter(middleCharacter)) throw new ArgumentException("Input was not a letter");
            
            return "";
        }
    }
}