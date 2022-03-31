using System;
using System.Collections.Generic;
using System.Linq;
using BowlingBall.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Should_be_zero_if_no_values_provided()
        {
            // Arrange
            IGame game = new Game();
            Roll(game, 0, 0, 0, 0, 0, 0);

            // Act
            int actualScore = game.GetScore();

            //Assert
            Assert.AreEqual(0, actualScore);
        }

        [TestMethod]
        public void Score_should_be_exact_test1()
        {
            // Arrange
            IGame game = new Game();
            Roll(game, 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10);

            // Act
            int actualScore = game.GetScore();

            //Assert
            Assert.AreEqual(187, actualScore);
        }

        [TestMethod]
        public void Score_should_be_exact_test2()
        {
            // Arrange
            IGame game = new Game();
            Roll(game, 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6);

            // Act
            int actualScore = game.GetScore();

            //Assert
            Assert.AreEqual(133, actualScore);
        }

        [TestMethod]
        public void Score_should_be_exact_test3()
        {
            // Arrange
            IGame game = new Game();
            Roll(game, 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 8);

            // Act
            int actualScore = game.GetScore();

            //Assert
            Assert.AreEqual(185, actualScore);
        }

        [TestMethod]
        public void Score_should_be_exact_test4()
        {
            // Arrange
            IGame game = new Game();
            Roll(game, 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6, 10, 10, 10, 10, 10);

            // Act
            int actualScore = game.GetScore();

            //Assert
            Assert.AreEqual(133, actualScore);
        }

        [TestMethod]
        public void Score_should_be_exact_test5()
        {
            // Arrange
            IGame game = new Game();
            Roll(game, 6, 4, 7, 3, 9, 1, 5, 2, 7, 3, 10, 10, 9, 0, 5, 4, 6, 4, 10);

            // Act
            int actualScore = game.GetScore();

            //Assert
            Assert.AreEqual(164, actualScore);
        }

        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            // Arrange
            IGame game = new Game();
            RollNTimes(game, 0, 20);

            // Act
            int actualScore = game.GetScore();

            //Assert
            Assert.AreEqual(0, actualScore);
        }

        #region Helper Methods
        private void RollNTimes(IGame game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        private void Roll(IGame game, params int[] pins)
        {
            foreach (var pin in pins)
            {
                game.Roll(pin);
            }
        }
        #endregion
    }
}
