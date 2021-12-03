using System;
using System.Collections.Generic;

namespace Football_Manager_2022.Entities
{
    public class Positions : IEntity
    {
        public string Name { get; set; }
        public ICollection<Footballer> Footballers { get; set; }
        public int Id { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
    }
}
