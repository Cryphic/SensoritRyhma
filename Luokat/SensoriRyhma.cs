using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Security.Principal;


namespace SRyhma
{
    internal class SensoriRyhma
    {
       //lista Rajapinta tyyppiä, johon tallennetaan kaikki sensori objektit.
        private List<ISensori> _sensorit = new List<ISensori>();

        //Lisää sensori objekti listaan yhdistävänä tekijänä ISensori rajapinta, joten lisääminen on helppoa ilman erillistä Sensori Tyyppi mainintaa.
        public void LisaaSensor(ISensori sensor)
        {
            _sensorit.Add(sensor);
        }        
    
        //palauta sensorien määrä (kaikki)
        public int HaeSensorCount()
        {
            return _sensorit.Count;
        }
     
        //palauta tilasensoreiden määrä (LINQ)
        public int HaeTilaSensorCount()
        {
            return _sensorit.OfType<TilaSensori>().ToList().Count;
        }
        //palauta LampoSensoreiden määrä (LINQ)
        public int HaeLampoSensorCount()
        {
            return _sensorit.OfType<LampoSensori>().ToList().Count;
        }

        
        //ToString ylikirjoitus, jolla saadaan tulostettua kaikki listan sensorit
        public override string ToString()
        {
            string str = "";
            foreach (var item in _sensorit)
            {
                str += item.ToString() + "\n";
            }
            return str;

        }
        //palauta kaikki TilaSensorit
        public string HaeTilaSensorit()
        {
            string str = "";
            foreach (var item in _sensorit)
            {
                if (item is TilaSensori)
                {
                    str += item.ToString() + "\n";
                }
            }
            return str;
        }

        //palauta kaikki LampoSensorit
        public string HaeLampoSensorit()
        {
            string str = "";
            foreach (var item in _sensorit)
            {
                if (item is LampoSensori)
                {
                    str += item.ToString() + "\n";
                }
            }
            return str;
        }





        /*Sensoreiden Serialisointi 
         * käyttäen Newtonsoft.Json kirjastoa, koska 
         * microsoftin omasta puuttui sopiva toimivuus ja ominaisuudet 2 eri objektin (vaikka Interface löytyy) käsittelylle
        */
        public void SerializeSensorit()
        {
            string json = JsonConvert.SerializeObject(_sensorit, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            File.WriteAllText("Sensorit.json", json);
        }


        //Metodi, joka lukee (deserialisoi) json datan ja täyttää listan jsonista haetuilla objekteilla.      
        public void DeserializeSensorit()
        {
            string json = File.ReadAllText("Sensorit.json");
            _sensorit = JsonConvert.DeserializeObject<List<ISensori>>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }




    }
}
