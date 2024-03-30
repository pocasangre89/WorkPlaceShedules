namespace WorkPlaceShedules.Application.Model.Users
{
    public class UsersRequestModel
    {
        public int UserId { get; set; }
        public string UserCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int RoleId { get; set; }
        public int GroupId { get; set; }
    }
}
