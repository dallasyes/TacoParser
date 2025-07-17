using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.035985,-84.683302,Taco Bell Acworth...", -84.683302)]
        [InlineData("34.087508,-84.575512,Taco Bell Acworth...", -84.575512)]
        
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var parser = new TacoParser();

            //Act
            var actual = parser.Parse(line);
            var actuallongitude = actual.Location.Longitude;

            //Assert
            Assert.Equal(expected, actuallongitude);
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.035985,-84.683302,Taco Bell Acworth...", 34.035985)]
        [InlineData("34.087508,-84.575512,Taco Bell Acworth...", 34.087508)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var parser = new TacoParser();
            var actual = parser.Parse(line).Location.Latitude;
            Assert.Equal(expected, actual);
        }

    }
}
