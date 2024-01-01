using System;
using Thearding;
using Xunit;

namespace UnitTestThearding
{
    public class VaribleTestSuite
    {
        [Fact]
        public void Schould_create_varible_class()
        {
            //Arrange

            //Act
            var result = new Varible();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Schould_create_varible_class_using_varible()
        {
            //Arrange
            Varible varible = new Varible();

            //Act
            var result = new Varible(varible);

            //Assert
            Assert.NotNull(result);
        }
    }
}
