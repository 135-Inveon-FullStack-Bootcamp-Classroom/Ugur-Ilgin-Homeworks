using System;

namespace Football_Manager_2022.Entities
{
    public class Manager : Person, IEntity

    {
        public ManagementPosition ManagementPosition { get; set; }
        public int Id { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
    }
}
