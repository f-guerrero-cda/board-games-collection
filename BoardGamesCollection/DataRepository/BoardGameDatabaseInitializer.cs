using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BoardGamesCollection.Models;
using System.Xml.Linq;
using System.IO;
using System.Configuration;

namespace BoardGamesCollection.DataRepository 
{
    public class BoardGameDatabaseInitializer : DropCreateDatabaseIfModelChanges<BoardGameContext>
    {
        protected override void Seed(BoardGameContext context)
        {
            base.Seed(context);

            var boardGames = new List<BoardGame>();

            //Loads the XML file into an XDoc
            XDocument boardGameDbXdoc = XDocument.Load(System.Web.Hosting.HostingEnvironment.MapPath(System.Configuration.ConfigurationManager.AppSettings["xmlRepositoryUri"].ToString()));            

            BoardGame objGame = new BoardGame();

            //Loads the XML doc into a list and into the Entity model
            List<BoardGame> lstBoardGame
                = (from _BoardGame in boardGameDbXdoc.Element("ArrayOfBoardGame").Elements("BoardGame")
                   select new BoardGame
                   {
                       Name = _BoardGame.Element("Name").Value,
                       Year = Int32.Parse(_BoardGame.Element("Year").Value),
                       Category = _BoardGame.Element("Category").Value,
                       Players = _BoardGame.Element("Players").Value,
                       Description = _BoardGame.Element("Description").Value,
                       Image = _BoardGame.Element("Image").Value
                   }).ToList();

            boardGames = lstBoardGame;

            boardGames.ForEach(a => context.BoardGames.Add(a));

            context.SaveChanges();
        }
    }
}