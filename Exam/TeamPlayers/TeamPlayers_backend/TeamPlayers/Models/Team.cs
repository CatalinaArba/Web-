namespace TeamPlayers.Models
{
    public class Team
    {

        public int id { get; set; }
        public string name { get; set; }
        public string homeCity { get; set; }
    
        public Team(int id, string name, string homeCity)
        {
            this.id = id;
            this.name = name;
            this.homeCity = homeCity;
        }
    }
}
