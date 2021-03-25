using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class NQueenSolverTests
    {
        [TestMethod()]
        public void GetNQueenSolutionTest_SizeBelow1()
        {
            Assert.AreEqual(NQueenSolver.GetNQueenSolution(0).Count, new List<Position>().Count);
        }

        [TestMethod()]
        public void GetNQueenSolutionTest_Size4()
        {
            Position[] positions =
            {
                new Position(3, 4),
                new Position(1, 3),
                new Position(4, 2),
                new Position(2, 1)
            };
            List<Position> values = NQueenSolver.GetNQueenSolution(4);
            foreach (var position in positions)
            {
                Assert.IsTrue(values.Contains(position));
            }
        }

        [TestMethod()]
        public void GetNQueenSolutionTest_Size1()
        {
            List<Position> values = NQueenSolver.GetNQueenSolution(1);
            Assert.IsTrue(values.Contains(new Position(1, 1)));
        }

        [TestMethod()]
        public void GetNQueenSolutionTest_ImpossibleSizes()
        {
            Assert.IsFalse(NQueenSolver.GetNQueenSolution(2).Any());
            Assert.IsFalse(NQueenSolver.GetNQueenSolution(3).Any());
        }
    }
}
