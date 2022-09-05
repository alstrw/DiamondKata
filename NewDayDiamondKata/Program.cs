// See https://aka.ms/new-console-template for more information

using System;
using NewDayDiamondKata;

if (Environment.GetCommandLineArgs().Length < 2) throw new ArgumentException("Please enter a letter"); 

var letter = Environment.GetCommandLineArgs()[1].ToUpperInvariant();
var diamond = new Diamond(Convert.ToChar(letter));

Console.WriteLine($"Printing diamond with {letter} as the middle: {Environment.NewLine}");
Console.WriteLine(diamond.Render());
Console.ReadKey();

