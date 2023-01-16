namespace SRyhma
{
    //abstrakti luokka, joka sisältää sensorien yhteiset ominaisuudet
    internal abstract class SensoriBase
    {
        //C#11 kielen uusi required modifier, eli pakotetaan tämän initialisointi konstruktorissa tai objektin luonnissa
        public required abstract DateTime SensoriTime { get; set; }
        
        //C#11 kielen uusi required modifier, eli pakotetaan tämän initialisointi konstruktorissa tai objektin luonnissa
        public required abstract int Id { get; set; }
    
    }
}