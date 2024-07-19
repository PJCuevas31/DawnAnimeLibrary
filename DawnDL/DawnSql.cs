using DawnModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DawnDL
{
    public class DawnSql
    {
        string connectionString = "Data Source=DESKTOP-POSRD7G\\SQLEXPRESS01; Initial Catalog=DawnListX; Integrated Security=True;";

        SqlConnection sqlConnection;

        public DawnSql()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Anime> GetAnimes()
        {
            string selectStatement = "SELECT AniName, AniReleaseDate, AniStudio, AniGenre FROM DawnAniListX";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Anime> animes = new List<Anime>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string aniName = reader["AniName"].ToString();
                DateTime aniReleaseDate = Convert.ToDateTime(reader["AniReleaseDate"]);
                string aniStudio = reader["AniStudio"].ToString();
                string aniGenre = reader["AniGenre"].ToString();

                Anime readAnime = new Anime
                {
                    AniName = aniName,
                    AniReleaseDate = aniReleaseDate,
                    AniStudio = aniStudio,
                    AniGenre = aniGenre
                };

                animes.Add(readAnime);
            }

            sqlConnection.Close();

            return animes;
        }

        public int AddAnime(string aniName, DateTime aniReleaseDate, string aniStudio, string aniGenre)
        {
            int success;

            string insertStatement = "INSERT INTO DawnAniListX (AniName, AniReleaseDate, AniStudio, AniGenre) VALUES (@aniName, @aniReleaseDate, @aniStudio, @aniGenre)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@aniName", aniName);
            insertCommand.Parameters.AddWithValue("@aniReleaseDate", aniReleaseDate);
            insertCommand.Parameters.AddWithValue("@aniStudio", aniStudio);
            insertCommand.Parameters.AddWithValue("@aniGenre", aniGenre);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdateAnime(string aniName, DateTime aniReleaseDate, string aniStudio, string aniGenre)
        {
            int success;

            string updateStatement = "UPDATE DawnAniListX SET AniReleaseDate = @aniReleaseDate, AniStudio = @aniStudio, AniGenre = @aniGenre WHERE AniName = @aniName";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@aniName", aniName);
            updateCommand.Parameters.AddWithValue("@aniReleaseDate", aniReleaseDate);
            updateCommand.Parameters.AddWithValue("@aniStudio", aniStudio);
            updateCommand.Parameters.AddWithValue("@aniGenre", aniGenre);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteAnime(string aniName)
        {
            int success;

            string deleteStatement = "DELETE FROM DawnAniListX WHERE AniName = @aniName";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@aniName", aniName);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}