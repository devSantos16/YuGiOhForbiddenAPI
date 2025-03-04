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


        public void Update(string name, string password, int cost, string description, int attack, int defense, int level, string attribute, string monsterType)
        {
            base.Update(name, password, cost, description);

            this.Attack = attack;
            this.Defense = defense;
            this.Level = level;
            this.Attribute = attribute;
            this.MonsterType = monsterType;
        }
    }

}
