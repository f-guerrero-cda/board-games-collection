using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoardGamesCollection.DataRepository;
using BoardGamesCollection.Models;
using BoardGamesCollection.Controllers;
using System.Data.Entity;
using System.Web.Http.Hosting;
using System.Web.Http;


using System.Transactions;namespace BoardGamesCollection.Tests
{
    [TestClass]
    public class BoardGameRepositoryTest
    {
        [TestMethod]
        public void InsertShouldReturnInsertId()
        {               
            //BoardGamesController boardGames = new BoardGamesController();
            System.Data.Entity.Database.SetInitializer(new BoardGameDatabaseInitializer());
            BoardGameContext context = new BoardGameContext();
            //context.Database.Initialize(true);
            IBoardGameRepository _boardGame = new BoardGameRepository(context);

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

            //var request = new IHttpActionResult();

            //request = boardGames.PostBoardGame(boardGame);

            //IHttpActionResult

            //int id = _boardGame.InsertBoardGame(boardGame);
            //int id = boardGames.PostBoardGame(boardGame);
            //Assert.AreNotEqual(0, id);
            
        }

        //[TestMethod]
        //public void AddressController_TestGoodRec()
        //{
        //    //use the mock address repository so we don't update the database
        //    //var repository = new MockAddressRepository();
        //    var controller = new BoardGamesController() //inject the mock address repository
        //    {
        //        Request = new System.Net.Http.HttpRequestMessage()
        //        {
        //            Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
        //        }
        //    };

        //    BoardGame boardGame = new BoardGame()
        //    {
        //        Id = 0,
        //        Name = "Unit Test 01",
        //        Year = 2015,
        //        Category = "Testing Category",
        //        Description = "Description test.",
        //        Players = "1-10",
        //        Image = ""
        //    };

        //    //var a = new Address { AddressLabel = "Tiki", City = "Manteca", Country = "US", State = "CA", Street = "123 Main", Zip = "95336" };
        //    var response = controller.PostBoardGame(boardGame);
        //    var resObject = response.Equals(IHttpActionResult);
        //    Assert.IsTrue(resObject.Status == "Created");
        //}

        //[TestMethod]
        //public void GetShouldReturnReponse()
        //{
        //    var HttpResponseMessage
        //}
    }
}
