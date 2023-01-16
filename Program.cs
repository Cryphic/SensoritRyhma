


namespace SRyhma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //uusi objekti SensoriRyhma luokasta
            SensoriRyhma ryhma = new SensoriRyhma();
            
            //Konsolin menu looppi
            do
            {                         
                //navigaatio printit
                Console.WriteLine("1. Lue Tiedosto (Sensorit.JSON)");
                Console.WriteLine("2. Ylikirjoita Tiedostoon (Sensorit.JSON) ");
                Console.WriteLine("3. Lisää uusi LämpöSensori SensoriRyhmään");
                Console.WriteLine("4. Lisää uusi TilaSensori SensoriRyhmään");
                Console.WriteLine("5. Näytä SensoriRyhmän LämpöSensorit");
                Console.WriteLine("6. Näytä SensoriRyhmän TilaSensorit");
                Console.WriteLine("7. Näytä SensoriRyhmän Kaikki Sensorit");
                Console.WriteLine("8. Poistu");
                Console.WriteLine("Valitse: ");
                string input = Console.ReadLine();
                int option = int.Parse(input);

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        ryhma.DeserializeSensorit();                       
                        break;
                    case 2:
                        Console.Clear();
                        ryhma.SerializeSensorit();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Syötä 5 mittaustulosta 'uusimmasta vanhimpaan' (1 nro per linja):");
                        LampoSensori s1 = new LampoSensori //asetetaan objektin initialisoinnissa 'required' arvot (Id ja dateTime)
                        {
                            Id = ryhma.HaeLampoSensorCount()+1,
                            SensoriTime = DateTime.Now,
                            LampoTila = new int[] {
                                int.Parse(Console.ReadLine()),
                                int.Parse(Console.ReadLine()),
                                int.Parse(Console.ReadLine()),
                                int.Parse(Console.ReadLine()),
                                int.Parse(Console.ReadLine())
                                }
                        };
                        ryhma.LisaaSensor(s1);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Syötä Sensorin muutoksen ajankohta: PVM KLO");
                        TilaSensori s2 = new TilaSensori //asetetaan objektin initialisoinnissa 'required' arvot
                        {
                            Id = ryhma.HaeTilaSensorCount() + 1,                          
                            SensoriTime = DateTime.Parse(Console.ReadLine()),                 
                        };
                        Console.WriteLine("Syötä Sensorin tila: true/false");
                        s2.Tila = bool.Parse(Console.ReadLine());
                        ryhma.LisaaSensor(s2);

                        break;                 
                    case 5:
                        Console.Clear();
                        Console.WriteLine("LämpöSensorit määrä: " + ryhma.HaeLampoSensorCount());
                        Console.WriteLine(ryhma.HaeLampoSensorit());
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("TilaSensorit määrä: " + ryhma.HaeTilaSensorCount());
                        Console.WriteLine(ryhma.HaeTilaSensorit());
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Sensoreiden määrä: " + ryhma.HaeSensorCount());
                        Console.WriteLine(ryhma.ToString());
                        break;
                    case 8:
                        return;
                       
                    default:
                        break;
                }
            } while (true);
        }
    }
}










