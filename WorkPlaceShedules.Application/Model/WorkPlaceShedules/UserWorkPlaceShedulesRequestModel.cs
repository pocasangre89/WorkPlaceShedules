namespace WorkPlaceShedules.Application.Model.WorkPlaceShedules
{
    public class UserWorkPlaceShedulesRequestModel
    {
        public int UserWorkPlaceScheduleId { get; set; }
        public int UserId { get; set; }
        public DateTime Schedule { get; set; }
        public bool IsAdminRequest { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Creator { get; set; } = string.Empty;
        public string Modifier { get; set; } = string.Empty;
    }
}
