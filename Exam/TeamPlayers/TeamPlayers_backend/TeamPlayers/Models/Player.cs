namespace TeamPlayers.Models
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }

        public Player(int id, string name, string position)
        {
            this.id = id;   
            this.name = name;
            this.position = position;
        }
    }
}
