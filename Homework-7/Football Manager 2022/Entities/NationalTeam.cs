using System;

namespace Football_Manager_2022.Entities
{
    public class NationalTeam : Team, IEntity
    {

        public int Id { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
    }
}
