using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MediaMarktHerstelling.Persistence
{
    internal class KlantMapper
    {
        private readonly string _connectionString;

        internal KlantMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal List<Klant> GetKlantenFromDB()
        {
            var _klanten = new List<Klant>();
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand("SELECT * FROM tblklant", con);
            con.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var _klant = new Klant
                (
                    dr["Naam"].ToString(),
                    dr["Telefoonnr"].ToString(),
                    Convert.ToInt32(dr["KlantId"])
                );
                _klanten.Add(_klant);
            }

            con.Close();
            return _klanten;
        }

        internal void AddKlantToDB(Klant klant)
        {
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand(
                "INSERT INTO tblklant " +
                "(KlantId, Naam, Telefoonnr) " +
                " VALUES(@id, @naam, @telefoonnr)",
                con);
            cmd.Parameters.AddWithValue("id", klant.Id);
            cmd.Parameters.AddWithValue("naam", klant.Naam);
            cmd.Parameters.AddWithValue("telefoonnr", klant.Telefoonnummer);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException mse)
            {
                throw mse;
            }
            finally
            {
                con.Close();
            }
        }

        internal void UpdateKlantInDB(Klant klant)
        {
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand(
                "UPDATE tblklant " +
                "SET naam = @naam, Telefoonnr = @telefoonnr " +
                "WHERE KlantId = @id",
                con);
            cmd.Parameters.AddWithValue("id", klant.Id);
            cmd.Parameters.AddWithValue("naam", klant.Naam);
            cmd.Parameters.AddWithValue("telefoonnr", klant.Telefoonnummer);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException mse)
            {
                throw mse;
            }
            finally
            {
                con.Close();
            }
        }

        internal void DeleteKlantFromDB(Klant klant)
        {
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand(
                "DELETE FROM tblklant " +
                "WHERE KlantId = @id",
                con);
            cmd.Parameters.AddWithValue("id", klant.Id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException mse)
            {
                throw mse;
            }
            finally
            {
                con.Close();
            }
        }
    }
}