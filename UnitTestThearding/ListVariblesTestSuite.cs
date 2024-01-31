using System;
using System.Collections.Generic;
using System.Text;
using Thearding;
using Xunit;

namespace UnitTestThearding
{
    public class ListVariblesTestSuite
    {
        [Fact]
        public void Schould_create_ListVaribles_class()
        {
            //Arrange
            //Act
            var result = new ListVaribles("Test");

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Schould_add_Varible_to_ListVaribles_class()
        {
            //Arrange
            ListVaribles listVaribles = new ListVaribles("Test");
            Varible varible = new Varible();
            varible.name = "Name";
            varible.value = "Value";

            //Act
            listVaribles.OprtationVarible("ADD", varible);
            var result = listVaribles as Varible;

            //Assert
            Assert.NotEqual("0", result.value);
        }

        [Fact]
        public void Schould_get_size_elements_ListVaribles_class()
        {
            //Arrange
            ListVaribles listVaribles = new ListVaribles("Test");
            Varible varible = new Varible();
            varible.name = "Name";
            varible.value = "Value";

            //Act
            listVaribles.OprtationVarible("ADD", varible);
            var result = listVaribles as Varible;

            //Assert
            Assert.Equal("1", result.value);
        }

        [Fact]
        public void Schould_remove_element_from_ListVaribles_class()
        {
            //Arrange
            ListVaribles listVaribles = new ListVaribles("Test");
            Varible varible = new Varible();
            varible.name = "Name";
            varible.value = "Value";
            listVaribles.OprtationVarible("ADD", varible);
            listVaribles.OprtationVarible("ADD", varible);

            //Act
            listVaribles.OprtationInt("REMOVE", 0);

            //Assert
            Assert.Equal("1", listVaribles.value);
        }

        [Fact]
        public void Schould_remove_varible_from_ListVaribles_class()
        {
            //Arrange
            ListVaribles listVaribles = new ListVaribles("Test");
            Varible varible = new Varible();
            varible.name = "Name";
            varible.value = "Value";
            listVaribles.OprtationVarible("ADD", varible);
            listVaribles.OprtationVarible("ADD", varible);

            //Act
            listVaribles.OprtationVarible("CLEAR", varible);

            //Assert
            Assert.Equal("1", listVaribles.value);
        }

        [Fact]
        public void Schould_clear_ListVaribles_class()
        {
            //Arrange
            ListVaribles listVaribles = new ListVaribles("Test");
            Varible varible = new Varible();
            varible.name = "Name";
            varible.value = "Value";
            listVaribles.OprtationVarible("ADD", varible);
            listVaribles.OprtationVarible("ADD", varible);

            //Act
            Varible var = new Varible();
            var.name = "ALL";
            listVaribles.OprtationVarible("CLEAR", var);

            //Assert
            Assert.Equal("0", listVaribles.value);
        }

        [Fact]
        public void Schould_get_element_from_ListVaribles_class()
        {
            //Arrange
            ListVaribles listVaribles = new ListVaribles("Test");
            Varible varible = new Varible();
            varible.name = "Name";
            varible.value = "Value";
            listVaribles.OprtationVarible("ADD", varible);

            //Act

            var result = listVaribles.OprtationInt("GET", 1);

            //Assert
            Assert.Equal("1", listVaribles.value);
            Assert.Equal(varible.name, result.name);
            Assert.Equal(varible.value, result.value);
        }
    }
}