namespace WorkPlaceShedules.Application.Model.WorkGroups
{
    public class WorkGroupsRequestModel
    {
        public int GroupId { get; set; }
        public string GroupDescription { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
