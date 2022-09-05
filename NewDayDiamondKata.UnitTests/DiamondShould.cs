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
    }
}