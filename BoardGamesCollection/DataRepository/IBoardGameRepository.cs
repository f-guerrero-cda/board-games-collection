using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoardGamesCollection.Models;
using System.Linq.Expressions;

namespace BoardGamesCollection.DataRepository
{
    public interface IBoardGameRepository : IDisposable
    {        
        IEnumerable<BoardGame> GetBoardGames();
        BoardGame GetBoardGameByID(int boardGameId);
        BoardGame SearchBoardGame(string searchText);        
        int InsertBoardGame(BoardGame boardGame);
        void DeleteBoardGame(int boardGameID);
        void UpdateBoardGame(BoardGame boardGame);
        bool BoardGameExists(int id);
        void Save();
    }
}