using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MediaMarktHerstelling.Persistence
{
    internal class ToestelMapper
    {
        private readonly string _connectionString;

        internal ToestelMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal List<Toestel> GetToestelFromDB()
        {
            var _toestellen = new List<Toestel>();
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand("SELECT * FROM tbltoestel", con);
            con.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var _toestel = new Toestel
                (
                    Convert.ToInt32(dr["ToestelId"]),
                    Convert.ToString(dr["Omschrijving"])
                );
                _toestellen.Add(_toestel);
            }

            con.Close();
            return _toestellen;
        }

        internal void AddToestelToDB(Toestel toestel)
        {
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand(
                "INSERT INTO tbltoestel " +
                "(ToestelId, Omschrijving) " +
                " VALUES(@toestelid, @omschrijving)",
                con);
            cmd.Parameters.AddWithValue("ToestelId", toestel.Id);
            cmd.Parameters.AddWithValue("omschrijving", toestel.Omschrijving);
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

        internal void UpdateToestelInDB(Toestel toestel)
        {
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand(
                "UPDATE tbltoestel SET Omschrijving = @omschrijving" +
                " WHERE Toestelid = @toestelid"
                , con);
            cmd.Parameters.AddWithValue("toestelid", toestel.Id);
            cmd.Parameters.AddWithValue("omschrijving", toestel.Omschrijving);
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

        internal void DeleteToestelInDB(Toestel toestel)
        {
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand("DELETE FROM tbltoestel " +
                                       "WHERE ToestelId = @id"
                , con);
            cmd.Parameters.AddWithValue("id", toestel.Id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException mse)
            {
                throw mse;
            }

            con.Close();
        }
    }
}