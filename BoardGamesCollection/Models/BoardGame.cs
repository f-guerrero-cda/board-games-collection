using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace BoardGamesCollection.Models
{
    public class BoardGame
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Category { get; set; }

        public string Players { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}