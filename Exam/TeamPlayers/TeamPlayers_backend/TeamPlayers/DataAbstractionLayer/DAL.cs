using MySql.Data.MySqlClient;
using System.Diagnostics;
using TeamPlayers.Models;

namespace TeamPlayers.DataAbstractionLayer
{
    public class DAL
    {
        private static String myConnectionString = "server=localhost;uid=root;pwd=;database=team_players;";


        public DAL()
        {
            String statement = "create table if not exists Player (id int primary key, name varchar(100),position varchar(100))"; //TODO: Create Master table
            executeStatement(statement);
            statement = "create table if not exists Team (id int primary key,name varchar(100),homeCity varchar(100))"; //TODO: Create Slave table
            executeStatement(statement);
            statement = "create table if not exists Category (id int primary key, idPlayer1 int references Player(id),idPlayer2 int references Player(id),idTeam int references Team(id))"; //TODO: Create Master table
            executeStatement(statement);
            
        }


        public static void executeStatement(String statement)
        {
            MySqlConnection connection;
            try
            {
                connection = new MySqlConnection
                {
                    ConnectionString = myConnectionString
                };
                connection.Open();

                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = statement
                };
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
            }
        }

        private static Player playerFromDataReader(MySqlDataReader dataReader)
        {
            return new Player(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("position")); //TODO: Complete constructor call
        }

        private static Team teamFromDataReader(MySqlDataReader dataReader)
        {
            return new Team(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("homeCity")); //TODO: Complete constructor call
        }

        private static TeamMembers teamMemeberFromDataReader(MySqlDataReader dataReader)
        {
            return new TeamMembers(dataReader.GetInt32("id"), dataReader.GetInt32("idPlayer1"),dataReader.GetInt32("idPlayer2"),dataReader.GetInt32("idTeam")); //TODO: Complete constructor call
        }


        public static List<Player> getPlayerFromStatement(String statement)
        {
            List<Player> result = new List<Player>();
            MySqlConnection connection;
            try
            {
                connection = new MySqlConnection
                {
                    ConnectionString = myConnectionString
                };
                connection.Open();

                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = statement
                };
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Player player = playerFromDataReader(dataReader);
                    result.Add(player);
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
            }
            return result;
        }

        public static List<Team> getTeamFromStatement(String statement)
        {
            List<Team> result = new List<Team>();
            MySqlConnection connection;
            try
            {
                connection = new MySqlConnection
                {
                    ConnectionString = myConnectionString
                };
                connection.Open();

                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = statement
                };
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Team Team = teamFromDataReader(dataReader);
                    result.Add(Team);
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
            }
            return result;
        }

        public static List<TeamMembers> getTeamMembersFromStatement(String statement)
        {
            List<TeamMembers> result = new List<TeamMembers>();
            MySqlConnection connection;
            try
            {
                connection = new MySqlConnection
                {
                    ConnectionString = myConnectionString
                };
                connection.Open();

                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = statement
                };
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    TeamMembers TeamMembers = teamMemeberFromDataReader(dataReader);
                    result.Add(TeamMembers);
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Debug.Write(ex.Message);
            }
            return result;
        }
    }
}
