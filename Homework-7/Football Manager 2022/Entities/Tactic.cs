using System;
using System.Collections.Generic;

namespace Football_Manager_2022.Entities
{
    public class Tactic : IEntity

    {
        public ICollection<Coach> Coaches { get; set; }
        public int Id { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
    }

}
