using System;
using System.Collections.Generic;
using System.Text;
using Thearding;
using Xunit;

namespace UnitTestThearding
{
    /*
     FUNC menu
VAR menu
SET menu Wybierz$srodzaj$stestu:$n1-Arytmetyka$n2-Pobieranie$si$swyświelanie$stekstu$nEND-Wyjście
PRINT $clear
PRINT menu
VAR opcja
GET opcja
IF opcja == 1 operacje
IF opcja == 2 input
IF opcja == END exit 
MOVE menu

FUNC exit
EXIT 
     */

    public class Cpu_If_TestSuite
    {
        [Fact]
        public void Schould_create_cpu_if_class()
        {
            //Arrange
            string[] words = { "FUNC", "menu", "VAR", "opcja", "SET", "opcja", "1", "IF", "opcja", "==", "1", "exit", "MOVE", "menu", "FUNC", "exit", "EXIT" };
            List<Varible> varibles = new List<Varible>();
            Varible varible = new Varible();
            varible.name = "opcja";
            varible.value = "1";
            varibles.Add(varible);

            List<Funkcja> funkcjas = new List<Funkcja>();
            Funkcja funkcja = new Funkcja();
            funkcja.name = "exit";
            funkcja.jump_to = 15;
            funkcjas.Add(funkcja);


            //Act
            var result = new Cpu_If(varibles, funkcjas, words, 7);

            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void Schould_check_compare(string[] words)
        {
            //Arrange
            //string[] words = { "FUNC", "menu", "VAR", "opcja", "SET", "opcja", "1", "IF", "opcja", "==", "1", "exit", "MOVE", "menu", "FUNC", "exit", "EXIT" };
            List<Varible> varibles = new List<Varible>();
            Varible varible = new Varible();
            varible.name = "opcja";
            varible.value = "1";
            varibles.Add(varible);

            List<Funkcja> funkcjas = new List<Funkcja>();
            Funkcja funkcja = new Funkcja();
            funkcja.name = "exit";
            funkcja.jump_to = 15;
            funkcjas.Add(funkcja);

            Cpu_If cpu_If = new Cpu_If(varibles, funkcjas, words, 7);

            //Act
            var result = cpu_If.Check();

            //Assert
            Assert.Equal(Import_Result.OK, result);
        }

        [Fact]
        public void Schould_get_new_function_varible()
        {
            //Arrange
            string[] words = { "FUNC", "menu", "VAR", "opcja", "SET", "opcja", "1", "IF", "opcja", "==", "1", "exit", "MOVE", "menu", "FUNC", "exit", "EXIT" };
            List<Varible> varibles = new List<Varible>();
            Varible varible = new Varible();
            varible.name = "opcja";
            varible.value = "1";
            varibles.Add(varible);

            List<Funkcja> funkcjas = new List<Funkcja>();
            Funkcja funkcja = new Funkcja();
            funkcja.name = "exit";
            funkcja.jump_to = 15;
            funkcjas.Add(funkcja);

            Cpu_If cpu_If = new Cpu_If(varibles, funkcjas, words, 7);

            //Act
            var result = cpu_If.Check();
            var fun = cpu_If.getNewFunction();

            //Assert
            Assert.Equal(Import_Result.OK, result);
            Assert.NotNull(fun);
            Assert.Equal("exit", fun.name);
        }

        [Fact]
        public void Schould_get_new_position()
        {
            //Arrange
            string[] words = { "FUNC", "menu", "VAR", "opcja", "SET", "opcja", "1", "IF", "opcja", "==", "1", "exit", "MOVE", "menu", "FUNC", "exit", "EXIT" };
            List<Varible> varibles = new List<Varible>();
            Varible varible = new Varible();
            varible.name = "opcja";
            varible.value = "1";
            varibles.Add(varible);

            List<Funkcja> funkcjas = new List<Funkcja>();
            Funkcja funkcja = new Funkcja();
            funkcja.name = "exit";
            funkcja.jump_to = 15;
            funkcjas.Add(funkcja);

            int pos = 7;
            Cpu_If cpu_If = new Cpu_If(varibles, funkcjas, words, pos);

            //Act
            var result = cpu_If.Check();
            var new_poz = cpu_If.getPosition();

            //Assert
            Assert.Equal(Import_Result.OK, result);
            Assert.NotEqual(pos, new_poz);
            Assert.Equal(15, new_poz);
        }

        public static IEnumerable<object[]> CompareData =>
        new List<object[]>
        {
            new object[] { new string[] { "FUNC", "menu", "VAR", "opcja", "SET", "opcja", "1", "IF", "opcja", "==", "1", "exit", "MOVE", "menu", "FUNC", "exit", "EXIT" } },
            new object[] { new string[] { "FUNC", "menu", "VAR", "opcja", "SET", "opcja", "1", "IF", "opcja", "<=", "1", "exit", "MOVE", "menu", "FUNC", "exit", "EXIT" } },
            new object[] { new string[] { "FUNC", "menu", "VAR", "opcja", "SET", "opcja", "2", "IF", "opcja", ">", "1", "exit", "MOVE", "menu", "FUNC", "exit", "EXIT" } },
            new object[] { new string[] { "FUNC", "menu", "VAR", "opcja", "SET", "opcja", "2", "IF", "opcja", ">=", "1", "exit", "MOVE", "menu", "FUNC", "exit", "EXIT" } },
            new object[] { new string[] { "FUNC", "menu", "VAR", "opcja", "SET", "opcja", "1", "IF", "opcja", "<", "2", "exit", "MOVE", "menu", "FUNC", "exit", "EXIT" } },
            new object[] { new string[] { "FUNC", "menu", "VAR", "opcja", "SET", "opcja", "1", "IF", "opcja", "!=", "2", "exit", "MOVE", "menu", "FUNC", "exit", "EXIT" } }
        };
    }
}
