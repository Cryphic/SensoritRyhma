using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRyhma
{
    //Inherit Sensori ja Implement ISensori
    internal class TilaSensori : Sensori, ISensori
    {
        private bool _tila = false;

        public bool Tila
        {
            get => _tila;
            set => _tila = value;
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

        public TilaSensori() : base()
        {
            Tila = false;
        }

        public override string ToString()
        {
            return $"Tila: {Tila} ID: {Id} Muutoksen ajankohta: {SensoriTime}";
        }
    }
}
