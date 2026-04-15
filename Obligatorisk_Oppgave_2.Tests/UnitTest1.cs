namespace Obligatorisk_Oppgave_2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void LanUt_BokSomErLedig_RedusererAntallOgLeggerTilAktivtLan()
        {
            var bibliotek = new Bibliotek();
            var bok = new Bok(1, "Testbok", "Forfatter", 2020, 1);
            var bruker = new Student("Ola", "ola@uia.no", "ola", "pass", 123);

            var resultat = bibliotek.LånUt(bok, bruker);

            Assert.True(resultat);
            Assert.Equal(0, bok.Antall);
            Assert.Single(bibliotek.AktiveLån);
        }

        [Fact]
        public void Returner_BokSomErLant_OkerAntallOgFlytterTilHistorikk()
        {
            var bibliotek = new Bibliotek();
            var bok = new Bok(1, "Testbok", "Forfatter", 2020, 1);
            var bruker = new Student("Ola", "ola@uia.no", "ola", "pass", 123);

            bibliotek.LånUt(bok, bruker);

            var resultat = bibliotek.Returner(bok, bruker);

            Assert.True(resultat);
            Assert.Equal(1, bok.Antall);
            Assert.Empty(bibliotek.AktiveLån);
            Assert.Single(bibliotek.Historikk);
        }

        [Fact]
        public void LeggTilStudent_SammeStudentToGanger_ReturnererFalseAndreGang()
        {
            var kurs = new Kurs("IS-110", "OOP", 10, 30);
            var student = new Student("Ola", "ola@uia.no", "ola", "pass", 123);

            var første = kurs.LeggTilStudent(student);
            var andre = kurs.LeggTilStudent(student);

            Assert.True(første);
            Assert.False(andre);
            Assert.Single(kurs.Studenter);
        }

        [Fact]
        public void OpprettKurs_DuplikatKurskode_TillatesIkke()
        {
            var liste = new List<Kurs>();
            liste.Add(new Kurs("IS-110", "OOP", 10, 30));

            bool finnes = liste.Any(k => k.KursKode == "IS-110");

            Assert.True(finnes);
        }

    }
}
