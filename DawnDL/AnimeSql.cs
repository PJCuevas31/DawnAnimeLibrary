using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace DawnDL
{
    public class SqlDbData
    {
        string connectionString = "Server=localhost; Database=ANIMESQL; Uid=root; Pwd=;";

        MySqlConnection mySqlConnection;

        public SqlDbData()
        {
            mySqlConnection = new MySqlConnection(connectionString);
        }

        public List<Anime> GetAnimes()
        {
            string selectStatement = "SELECT ani_name, ani_releasedate, ani_studio, ani_genre FROM ANIMEDATA";

            MySqlCommand selectCommand = new MySqlCommand(selectStatement, mySqlConnection);

            mySqlConnection.Open();
            List<Anime> animes = new List<Anime>();

            MySqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string aniName = reader["ani_name"].ToString();
                DateTime aniReleaseDate = Convert.ToDateTime(reader["ani_releasedate"]);
                string aniStudio = reader["ani_studio"].ToString();
                string aniGenre = reader["ani_genre"].ToString();

                Anime anime = new Anime();
                anime.AniName = aniName;
                anime.AniReleaseDate = aniReleaseDate;
                anime.AniStudio = aniStudio;
                anime.AniGenre = aniGenre;

                animes.Add(anime);
            }

            mySqlConnection.Close();

            return animes;
        }

        public int AddAnime(string aniName, DateTime aniReleaseDate, string aniStudio, string aniGenre)
        {
            int success;

            string insertStatement = "INSERT INTO ANIMEDATA (ani_name, ani_releasedate, ani_studio, ani_genre) VALUES (@ani_name, @ani_releasedate, @ani_studio, @ani_genre)";

            MySqlCommand insertCommand = new MySqlCommand(insertStatement, mySqlConnection);

            insertCommand.Parameters.AddWithValue("@ani_name", aniName);
            insertCommand.Parameters.AddWithValue("@ani_releasedate", aniReleaseDate);
            insertCommand.Parameters.AddWithValue("@ani_studio", aniStudio);
            insertCommand.Parameters.AddWithValue("@ani_genre", aniGenre);
            mySqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            mySqlConnection.Close();

            return success;
        }

        public int UpdateAnime(string aniName, DateTime aniReleaseDate, string aniStudio, string aniGenre)
        {
            int success;

            string updateStatement = "UPDATE ANIMEDATA SET ani_releasedate = @ani_releasedate, ani_studio = @ani_studio, ani_genre = @ani_genre WHERE ani_name = @ani_name";
            MySqlCommand updateCommand = new MySqlCommand(updateStatement, mySqlConnection);
            mySqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@ani_releasedate", aniReleaseDate);
            updateCommand.Parameters.AddWithValue("@ani_studio", aniStudio);
            updateCommand.Parameters.AddWithValue("@ani_genre", aniGenre);
            updateCommand.Parameters.AddWithValue("@ani_name", aniName);

            success = updateCommand.ExecuteNonQuery();

            mySqlConnection.Close();

            return success;
        }

        public int DeleteAnime(string aniName)
        {
            int success;

            string deleteStatement = "DELETE FROM ANIMEDATA WHERE ani_name = @ani_name";
            MySqlCommand deleteCommand = new MySqlCommand(deleteStatement, mySqlConnection);
            mySqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@ani_name", aniName);

            success = deleteCommand.ExecuteNonQuery();

            mySqlConnection.Close();

            return success;
        }
    }

    public class Anime
    {
        public string AniName { get; set; }
        public DateTime AniReleaseDate { get; set; }
        public string AniStudio { get; set; }
        public string AniGenre { get; set; }
    }
}
