

namespace SRyhma
{
    internal class Sensori : SensoriBase
    {
        private int _id;

        //C#11 kielen required modifier, eli pakotetaan tämän initialisointi konstruktorissa tai objektin luonnissa
        public required override int Id
        {
            get => _id;
            set => _id = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "Id on negatiivinen");
        }
        //C#11 kielen required modifier, eli pakotetaan tämän initialisointi konstruktorissa tai objektin luonnissa
        public required override DateTime SensoriTime { get; set; }

        
        public Sensori()
        {
            Id = 0;
            SensoriTime = DateTime.MinValue;
        }
    }
}

