using System;
using System.Collections.Generic;
using MediaMarktHerstelling.Business;
using MySql.Data.MySqlClient;

namespace MediaMarktHerstelling.Persistence
{
    internal class GebruikerMapper
    {
        private readonly string _conString = "";

        internal GebruikerMapper(string connectionString)
        {
            _conString = connectionString;
        }

        internal void AddGebruikerToDb(Gebruiker gebruiker)
        {
            var con = new MySqlConnection(_conString);
            var cmd = new MySqlCommand(
                "INSERT INTO tblbijdragen (id, username, password)" +
                " VALUES (@id, @usernaam, @paswoord)"
                , con);
            cmd.Parameters.AddWithValue("id", gebruiker.Id);
            cmd.Parameters.AddWithValue("username", gebruiker.Gebruikersnaam);
            cmd.Parameters.AddWithValue("password", gebruiker.Paswoord);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal List<Gebruiker> GetGebruikersFromDb()
        {
            var _gebruikers = new List<Gebruiker>();
            var con = new MySqlConnection(_conString);
            var cmd = new MySqlCommand(
                "SELECT * FROM tblgebruiker"
                , con);

            con.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var _gebruiker = new Gebruiker(
                    Convert.ToInt32(dr["id"]),
                    Convert.ToString(dr["username"]),
                    Convert.ToString(dr["password"])
                );
                _gebruikers.Add(_gebruiker);
            }

            con.Close();
            return _gebruikers;
        }
    }
}