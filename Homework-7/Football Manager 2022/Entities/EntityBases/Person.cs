using System;

namespace Football_Manager_2022.Entities
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Team Team { get; set; }
        public NationalTeam NationalTeam { get; set; }
    }
}
