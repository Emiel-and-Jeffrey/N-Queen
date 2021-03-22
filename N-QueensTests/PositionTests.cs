using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class PositionTests
    {
        [TestMethod()]
        public void PositionTest_ConstructorRowAndColumn()
        {
            Position position = new Position(1, 2);
            Assert.AreEqual(position.Column, 1);
            Assert.AreEqual(position.Row, 2);
        }

        [TestMethod()]
        public void PositionTest_ConstructorDirection_DownLeft()
        {
            Position position = new Position(1, 2);
            Position differentPosition = new Position(position, Direction.DownLeft);
            Assert.AreEqual(differentPosition.Column, 1 - 1);
            Assert.AreEqual(differentPosition.Row, 2 - 1);
        }

        [TestMethod()]
        public void PositionTest_ConstructorDirection_UpLeft()
        {
            Position position = new Position(1, 2);
            Position differentPosition = new Position(position, Direction.UpLeft);
            Assert.AreEqual(differentPosition.Column, 1 - 1);
            Assert.AreEqual(differentPosition.Row, 2 + 1);
        }

        [TestMethod()]
        public void PositionTest_ConstructorDirection_UpRight()
        {
            Position position = new Position(1, 2);
            Position differentPosition = new Position(position, Direction.UpRight);
            Assert.AreEqual(differentPosition.Column, 1 + 1);
            Assert.AreEqual(differentPosition.Row, 2 + 1);
        }

        [TestMethod()]
        public void PositionTest_ConstructorDirection_DownRight()
        {
            Position position = new Position(1, 2);
            Position differentPosition = new Position(position, Direction.DownRight);
            Assert.AreEqual(differentPosition.Column, 1 + 1);
            Assert.AreEqual(differentPosition.Row, 2 - 1);
        }

        [TestMethod()]
        public void PositionTest_Equals()
        {
            Position position = new Position(1, 2);
            Position position2 = new Position(1, 2);
            Assert.AreEqual(position, position2);
        }

        [TestMethod()]
        public void PositionTest_Equals_NotEqualValues()
        {
            Position position = new Position(1, 2);
            Position position2 = new Position(2, 2);
            Assert.AreNotEqual(position, position2);
        }

        [TestMethod()]
        public void PositionTest_HashCode()
        {
            Position position = new Position(1, 2);
            Assert.AreEqual(position.GetHashCode(), HashCode.Combine(position.Column, position.Row));
        }
    }
}