using System;
using System.Collections.Generic;

namespace GameAPI.Models
{
    public partial class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
