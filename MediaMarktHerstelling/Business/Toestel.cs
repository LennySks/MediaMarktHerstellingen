namespace MediaMarktHerstelling
{
    public class Toestel : Entity
    {
        public Toestel(int id, string omschrijving) : base(id)
        {
            Omschrijving = omschrijving;
        }

        public string Omschrijving { get; set; }
    }
}