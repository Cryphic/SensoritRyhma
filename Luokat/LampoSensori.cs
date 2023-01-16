

namespace SRyhma
{
    //Inherit Sensori ja Implement ISensori
    internal class LampoSensori : Sensori, ISensori
    {
        private int[] _lampotila = new int[5];
        public int[] LampoTila
        {
            get => _lampotila;
            //asetetaanjos luvut ei ole alle -50 tai yli +50 muuten heitä exception
            set => _lampotila = value.All(x => x >= -50 && x <= 50) ? value :
                throw new ArgumentOutOfRangeException(nameof(value), "Lämpötila on liian suuri tai pieni");

        }
        //ISensori rajapinnan metodi toteutus: AsetaID
        public void AsetaId(int id)
        {
            Id = id;
        }
        //ISensori rajapinnan metodi toteutus: AsetaTime
        public void AsetaTime(DateTime date)
        {
            SensoriTime = date; 
        }

        public void AsetaLampotila(int[] lampotila)
        {
            LampoTila = lampotila;
        }

        //Haetaan arraystä min max average ja palautetaan string jono
        public string LampoTilaMinMaxAvg()
        {
            int min = LampoTila.Min();
            int max = LampoTila.Max();
            int avg = (int)LampoTila.Average();
            return $"Min: {min} Max: {max} Avg: {avg}";
        }


       
        
        public LampoSensori() : base()
        {                     
            _lampotila = new int[] { -999, -999, -999, -999, -999 };           
        }

        public override string ToString()
        {
            //Palautetaan array numerot, ID, aika ja min max avg
            return $"LämpöSensori Uusin -> Vanha: {string.Join(", ", LampoTila)} ID: {Id} Mitattu: {SensoriTime} {LampoTilaMinMaxAvg()}";


        }

    }
}
