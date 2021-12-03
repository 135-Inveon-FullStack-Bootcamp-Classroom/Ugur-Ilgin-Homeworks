using System;
using System.Collections.Generic;

namespace Football_Manager_2022.Entities
{
    public class Coach : Person, IEntity
    {
        public ICollection<Tactic> Tactics { get; set; }
        public int Id { get ; set ; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
    }
}
