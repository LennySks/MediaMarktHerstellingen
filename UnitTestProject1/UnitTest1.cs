using System;
using MediaMarktHerstelling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MaakHerstellingTest()
        {
            var c = new Controller();
            var klant = c.NieuweKlant("test", "test");
            var toestel = c.NieuweToestel("test a retard");
            var h = c.NieuweHerstelling(50.0, DateTime.Now, DateTime.Today.AddDays(2), toestel.Id, klant.Id);

            //c.DeleteToestel(toestel.Id);
            //c.DeleteKlant(klant.Id);
        }

        [TestMethod]
        public void UpdateHerstelling()
        {
        }
    }
}