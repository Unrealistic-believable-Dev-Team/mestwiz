
namespace mestwiz.config.api.entities.Auth
{
    public class UserMenu
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public List<UserMenu> SubMenus { get; set; }
    }
}
