using Football_Manager_2022.ServiceAbstracts;
namespace Football_Manager_2022.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
      
        public UnitOfWork(ITeamService teamService,IFootballerService footballerService,ICoachService coachService,ITacticService tacticService,IPositionService positionService,INationalTeamService nationalTeamService,IManagerService managerService,IManagementPositionService managementPositionService )
        {
            this.TeamService = teamService;
            this.FootballerService = footballerService;
            this.CoachService= coachService;
            this.TacticService = tacticService;
            this.PositionService = positionService;
            this.ManagementPositionService = managementPositionService;
            this.ManagerService = managerService;
            this.NationalTeamService = nationalTeamService;
            
        }
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
