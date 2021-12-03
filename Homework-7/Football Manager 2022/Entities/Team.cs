using System;
using System.Collections.Generic;
namespace Football_Manager_2022.Entities
{
    public class Team:IEntity
    {
        public string Name { get; set; }
        public ICollection<Coach> Coaches { get; set; }
        public ICollection<Manager> Managers { get; set; }
        public ICollection<Footballer> Footballers { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
    }
}
