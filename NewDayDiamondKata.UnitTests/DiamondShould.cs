using System;
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
            _sut = new Diamond();
        }

        [Test]
        public void ReturnAWhenInputCharacterIsA()
        {
            var result = _sut.Create('A');

            result.Should().Be("A");
        }

        [TestCase('1')]
        [TestCase('%')]
        [TestCase('.')]
        [TestCase(' ')]
        [TestCase(null)]
        public void RejectNonLetterChars(char input)
        {
            Action act = () => _sut.Create(input);

            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void PrintEqualDiamond_WhenCreatingDiamond_GivenLetterD()
        {
            var expectedOutcome = "   A\n" +
                                       "  B B\n" +
                                       " C   C\n" +
                                       "D     D\n" +
                                       " C   C\n" +
                                       "  B B\n" +
                                       "   A";

            var diamond = _sut.Create('D');

            diamond.Should().Be(expectedOutcome);
        }
    }
}