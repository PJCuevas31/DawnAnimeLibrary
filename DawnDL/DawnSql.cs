using Microsoft.Data.SqlClient; 
using System;
using System.Collections.Generic;
using DawnModel;

namespace DawnDL
{
    public class DawnSql
    {
        string _connectionString = "Data Source=DESKTOP-N5OCNK2\\SQLEXPRESS;Initial Catalog=DawnListX;Integrated Security=True;";

        public List<Anime> GetAnimes()
        {
            List<Anime> animes = new List<Anime>();

            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                string query = "SELECT AniName, AniReleaseDate, AniStudio, AniGenre FROM Animes";
                SqlCommand command = new SqlCommand(query, connection); 

                connection.Open();
                SqlDataReader reader = command.ExecuteReader(); 

                while (reader.Read())
                {
                    Anime anime = new Anime
                    {
                        AniName = reader["AniName"].ToString(),
                        AniReleaseDate = Convert.ToDateTime(reader["AniReleaseDate"]),
                        AniStudio = reader["AniStudio"].ToString(),
                        AniGenre = reader["AniGenre"].ToString()
                    };
                    animes.Add(anime);
                }
                connection.Close();
            }

            return animes;
        }

        public int AddAnime(string aniName, DateTime aniReleaseDate, string aniStudio, string aniGenre)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                string query = "INSERT INTO DawnAniListX (AniName, AniReleaseDate, AniStudio, AniGenre) VALUES (@AniName, @AniReleaseDate, @AniStudio, @AniGenre)";
                SqlCommand command = new SqlCommand(query, connection); 

                command.Parameters.AddWithValue("@AniName", aniName);
                command.Parameters.AddWithValue("@AniReleaseDate", aniReleaseDate);
                command.Parameters.AddWithValue("@AniStudio", aniStudio);
                command.Parameters.AddWithValue("@AniGenre", aniGenre);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;
            }
        }

        public int UpdateAnime(string aniName, DateTime aniReleaseDate, string aniStudio, string aniGenre)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                string query = "UPDATE DawnAniListX  SET AniReleaseDate = @AniReleaseDate, AniStudio = @AniStudio, AniGenre = @AniGenre WHERE AniName = @AniName";
                SqlCommand command = new SqlCommand(query, connection); 

                command.Parameters.AddWithValue("@AniName", aniName);
                command.Parameters.AddWithValue("@AniReleaseDate", aniReleaseDate);
                command.Parameters.AddWithValue("@AniStudio", aniStudio);
                command.Parameters.AddWithValue("@AniGenre", aniGenre);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;
            }
        }

        public int DeleteAnime(string aniName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                string query = "DELETE FROM DawnAniListX  WHERE AniName = @AniName";
                SqlCommand command = new SqlCommand(query, connection); 

                command.Parameters.AddWithValue("@AniName", aniName);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;
            }
        }
    }
}
