using YuGiOhForbiddenAPI.Model;

namespace YuGiOhForbiddenAPI.Entities
{
    public class Monster : Card
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Level { get; set; }
        public string Attribute { get; set; }
        public string MonsterType { get; set; }
    }
}
