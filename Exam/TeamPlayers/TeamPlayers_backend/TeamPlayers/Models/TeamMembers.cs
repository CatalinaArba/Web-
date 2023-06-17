namespace TeamPlayers.Models
{
    public class TeamMembers
    {
        public int id { get; set; }
        public int idPlayer1 { get; set; }
        public int idPlayer2 { get; set; }
     
        public int idTeam { get; set;}

        public TeamMembers(int id, int idPlayer1, int idPlayer2, int idTeam)
        {
            this.id = id;
            this.idPlayer1 = idPlayer1;
            this.idPlayer2 = idPlayer2;
            this.idTeam = idTeam;

        }
    }
}
