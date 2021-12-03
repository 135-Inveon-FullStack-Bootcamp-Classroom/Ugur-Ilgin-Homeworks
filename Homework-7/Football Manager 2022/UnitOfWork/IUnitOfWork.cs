using Football_Manager_2022.ServiceAbstracts;
using Football_Manager_2022.ServiceImplementetions;
namespace Football_Manager_2022.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ITeamService TeamService { get; set; }
        public IFootballerService FootballerService { get; set; }
        public ICoachService CoachService { get; set; }
        public ITacticService TacticService { get; set; }
        public IPositionService PositionService { get; set; }
        public INationalTeamService NationalTeamService { get; set; }
        public IManagerService ManagerService { get; set; }
        public IManagementPositionService ManagementPositionService { get; set; }


    }
}
