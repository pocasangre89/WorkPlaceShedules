namespace WorkPlaceShedules.Application.Model.WorkPlaces
{
    public class WorkPlacesRequestModel
    {
        public string WorkPlaceCode { get; set; } = string.Empty;
        public string WorkPlaceName { get; set; } = string.Empty;
        public int WorkPlaceNumber { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
