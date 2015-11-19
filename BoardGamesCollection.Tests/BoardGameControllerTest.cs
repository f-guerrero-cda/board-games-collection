using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoardGamesCollection.Models;
using BoardGamesCollection.Controllers;

namespace BoardGamesCollection.Tests
{
    [TestClass]
    public class BoardGameControllerTest
    {
        [TestMethod]
        public void GetShouldReturnBoardGames()
        {
            BoardGamesController boardGames = new BoardGamesController();

            BoardGame boardGame = new BoardGame()
            {
                Id = 0,
                Name = "Unit Test 01",
                Year = 2015,
                Category = "Testing Category",
                Description = "Description test.",
                Players = "1-10",
                Image = ""
            };

            boardGames.PostBoardGame(boardGame);
        }
    }
}
