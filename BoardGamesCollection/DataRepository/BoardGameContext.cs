using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using BoardGamesCollection.Models;

namespace BoardGamesCollection.DataRepository
{
    public class BoardGameContext : DbContext
    {        
        public BoardGameContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<BoardGame> BoardGames { get; set; }
    }
}