using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.Calculations;

namespace Sudoku.UnitTests {
    [TestClass]
    public class SudokuTests {
        [TestMethod]
        public void IsValidSudoku() {
            //Arrange
            SudokuCalculations calculations = new SudokuCalculations();
            //Act
            bool isValid = calculations.IsValid("4;2,1,3,2,3,2,1,4,1,4,2,3,2,3,4,1");

            //Assert
            Assert.AreEqual(false, isValid);
        }
    }
}
