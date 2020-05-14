using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MediaMarktHerstelling.Persistence
{
    internal class HerstellingMapper
    {
        private readonly string _connectionString;

        internal HerstellingMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal List<Herstelling> GetHerstellingenFromDB(int klantid)
        {
            var _herstellingen = new List<Herstelling>();
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand("SELECT * FROM tblherstelling where KlantId = @klantid", con);
            cmd.Parameters.AddWithValue("klantid", klantid);
            con.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DateTime dk = default;
                try
                {
                    dk = Convert.ToDateTime(dr["Datum klaar"]);
                }
                catch
                {
                }


                var _herstelling = new Herstelling
                (
                    Convert.ToDouble(dr["Kostprijs"]),
                    Convert.ToDateTime(dr["Datum binnen"]),
                    dk,
                    Convert.ToInt32(dr["ToestelId"]),
                    Convert.ToInt32(dr["KlantId"])
                );

                if (ToestelRepository.GetItem(Convert.ToInt32(dr["ToestelId"])) != null)
                    _herstelling.ToestelId = ToestelRepository.GetItem(Convert.ToInt32(dr["ToestelId"])).Id;
                _herstellingen.Add(_herstelling);
            }

            con.Close();
            return _herstellingen;
        }

        internal void AddHerstellingToDB(Herstelling herstelling)
        {
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand(
                "INSERT INTO tblherstelling " +
                //"(Datum binnen, Datum klaar, Kostprijs, KlantId, ToestelId) " +
                "VALUES (@datumbinnen, @datumklaar, @kostprijs, @klantId, @toestelId)",
                con);
            cmd.Parameters.AddWithValue("datumbinnen", herstelling.DatumBinnen);
            cmd.Parameters.AddWithValue("datumklaar", herstelling.DatumKlaar);
            cmd.Parameters.AddWithValue("kostprijs", herstelling.Kostprijs);
            cmd.Parameters.AddWithValue("klantId", herstelling.KlantId);
            cmd.Parameters.AddWithValue("toestelId", herstelling.ToestelId);
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

        internal void UpdateHerstellingInDB(Herstelling herstelling)
        {
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand(
                "UPDATE tblherstelling " +
                "SET `Datum binnen` = @datumbinnen, `Datum Klaar` = @datumklaar, Kostprijs = @kostprijs, Toestelid = @toestelid " +
                "WHERE Toestelid = @toestelid",
                con);
            cmd.Parameters.AddWithValue("datumbinnen", herstelling.DatumBinnen);
            if (herstelling.DatumKlaar != null)
            {
                cmd.Parameters.AddWithValue("datumklaar", herstelling.DatumKlaar);
            }
            else
            {
                cmd.Parameters.AddWithValue("datumklaar", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("kostprijs", herstelling.Kostprijs);
            cmd.Parameters.AddWithValue("toestelid", herstelling.ToestelId);

        

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

        internal void DeleteHerstellingFromDB(Herstelling herstelling)
        {
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand(
                "DELETE FROM tblherstelling " +
                "WHERE Toestelid = @toestelid AND KlantId = @klantid",
                con);
            cmd.Parameters.AddWithValue("klantId", herstelling.KlantId);
            cmd.Parameters.AddWithValue("toestelId", herstelling.ToestelId);
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