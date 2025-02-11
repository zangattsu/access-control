namespace CinSaude.Domain.Entities
{
    public class ApplicationMenu
    {
        public int ApplicationMenuId { get; set; }
        public string Route { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public bool RequiresAuthenication { get; set; } = true;
    }
}