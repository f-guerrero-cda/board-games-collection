using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoardGamesCollection.Models;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace BoardGamesCollection.DataRepository
{
    public class BoardGameRepository : IBoardGameRepository, IDisposable
    {
        private BoardGameContext context;
                
        public BoardGameRepository(BoardGameContext context)
        {
            this.context = context;
        }

        public IEnumerable<BoardGame> GetBoardGames()
        {
            return context.BoardGames.ToList();
        }

        public BoardGame GetBoardGameByID(int boardGameId)
        {
            return context.BoardGames.Find(boardGameId);
        }

        public BoardGame SearchBoardGame(string searchText)
        {
            throw new NotImplementedException();
        }

        public int InsertBoardGame(BoardGame boardGame)
        {
            BoardGame newBoardGame = context.BoardGames.Add(boardGame);
            return newBoardGame.Id;
        }

        public void DeleteBoardGame(int boardGameID)
        {
            BoardGame boardGame = context.BoardGames.Find(boardGameID);
            context.BoardGames.Remove(boardGame);
        }

        public void UpdateBoardGame(BoardGame boardGame)
        {
            context.Entry(boardGame).State = System.Data.Entity.EntityState.Modified;
        }

        public bool BoardGameExists(int id)
        {
            return context.BoardGames.Count(e => e.Id == id) > 0;
        }

        public void Save()
        {
            context.SaveChanges();

            XmlSerializer serializer = new XmlSerializer(typeof(List<BoardGame>));
            using (var writer = XmlWriter.Create(System.Web.Hosting.HostingEnvironment.MapPath(System.Configuration.ConfigurationManager.AppSettings["xmlRepositoryUri"].ToString())))
            {              
                serializer.Serialize(writer, context.BoardGames.ToList());
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}