using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using NUnit.Framework;

namespace NewDayDiamondKata.UnitTests
{
    public class DiamondShould
    {
        private Diamond _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Diamond('A');
        }

        [Test]
        public void ReturnA_WhenCreatingDiamond_GivenInputCharacterIsA()
        {
            var result = _sut.Render();

            result.Should().Be("A");
        }

        [TestCase('1')]
        [TestCase('%')]
        [TestCase('.')]
        [TestCase(' ')]
        [TestCase(null)]
        public void ThrowArgumentException_WhenCreatingDiamond_GivenInputCharIsNotALetter(char input)
        {
            var sut = new Diamond(input);
            Action act = () => sut.Render();

            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void PrintEqualDiamond_WhenCreatingDiamond_GivenLetterD()
        {
            var sut = new Diamond('D');

            var expectedOutcome = "   A\n" +
                                       "  B B\n" +
                                       " C   C\n" +
                                       "D     D\n" +
                                       " C   C\n" +
                                       "  B B\n" +
                                       "   A";

            var diamond = sut.Render();

            diamond.Should().Be(expectedOutcome);
        }

        [TestCaseSource(nameof(GetExpectedLinesTestData))]
        public void RenderDiamondWithCorrectAmountOfLines_WhenCreatingDiamond(char middleLetter, int expectedLines)
        {
            var sut = new Diamond(middleLetter);

            var diamond = sut.Render();

            diamond.Split("\n").Length.Should().Be(expectedLines);
        }

        private static IEnumerable<object[]> GetExpectedLinesTestData()
        {
            yield return new object[] {'A', 1};
            yield return new object[] {'B', 3};
            yield return new object[] {'C', 5};
            yield return new object[] {'D', 7};
            yield return new object[] {'E', 9};
            yield return new object[] {'F', 11};
            yield return new object[] {'G', 13};
            yield return new object[] {'H', 15};
            yield return new object[] {'I', 17};
            yield return new object[] {'J', 19};
            yield return new object[] {'K', 21};
            yield return new object[] {'L', 23};
            yield return new object[] {'M', 25};
            yield return new object[] {'N', 27};
            yield return new object[] {'O', 29};
            yield return new object[] {'P', 31};
            yield return new object[] {'Q', 33};
            yield return new object[] {'R', 35};
            yield return new object[] {'S', 37};
            yield return new object[] {'T', 39};
            yield return new object[] {'U', 41};
            yield return new object[] {'V', 43};
            yield return new object[] {'W', 45};
            yield return new object[] {'X', 47};
            yield return new object[] {'Y', 49};
            yield return new object[] {'Z', 51};
        }
    }
}