using System;

namespace MediaMarktHerstelling
{
    public class Herstelling
    {
        public Herstelling(double kostprijs, DateTime datumbinnen, DateTime datumklaar, int toestelid, int klantId)
        {
            Kostprijs = kostprijs;
            DatumBinnen = datumbinnen;
            DatumKlaar = datumklaar;
            isHersteld = false;
            ToestelId = toestelid;
            KlantId = klantId;
        }

        public double Kostprijs { get; set; }
        public DateTime DatumBinnen { get; set; }
        public DateTime DatumKlaar { get; set; }
        public bool isHersteld { get; set; }
        public int ToestelId { get; set; }
        public int KlantId { get; set; }

        public Klant Klant => KlantRepository.GetItem(KlantId);


        public Toestel Toestel => ToestelRepository.GetItem(ToestelId);
    }
}