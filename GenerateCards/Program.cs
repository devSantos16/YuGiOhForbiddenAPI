using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using YuGiOhForbiddenAPI.Persistence;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using YuGiOhForbiddenAPI.Entities;
using System.Threading;
using System.Reflection;

namespace GenerateCards;

internal class CardCollection
{
    public List<Dictionary<string, object>> Cards { get; set; }

}

internal class Program
{
    static void Main(string[] args)
    {

        var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string yamlPath = $"{projectDirectory}\\Cards\\cards.yaml";

        string yamlContent = File.ReadAllText(yamlPath);

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        var cardCollection = deserializer.Deserialize<CardCollection>(yamlContent);
        DbContextOptions<YuGiOhDbContext> options = YuGiOhDbContext.GetDbContextOptions();

        using (var context = new YuGiOhDbContext(options))
        {
            foreach (var card in cardCollection.Cards)
            {
                var name = card["Name"].ToString();
                var description = card["Description"].ToString();
                var password = card["Password"].ToString();
                var type = card["Type"].ToString();
                var cost = Convert.ToInt32(card["Cost"].ToString());

                switch (type)
                {
                    case "Monster":
                        var monster = new Monster();
                        
                        var attack = Convert.ToInt32(card["Attack"].ToString());
                        var defense = Convert.ToInt32(card["Defense"].ToString());
                        var level = Convert.ToInt32(card["Level"].ToString());
                        var attribute = card["Attribute"].ToString();
                        var monsterType = card["MonsterType"].ToString();

                        monster.Update(name, password, cost, description, attack, defense, level, attribute, monsterType);
                        context.Monster.Add(monster);
                        break;

                    case "Equip":
                        var equip = new Equip();
                        
                        equip.Update(name, password, cost, description);
                        context.Equip.Add(equip);
                        break;

                    case "Trap":
                        var trap = new Trap();
                        
                        trap.Update(name, password, cost, description);
                        context.Trap.Add(trap);
                        break;

                    case "Magic":
                        var magic = new Magic();
                        
                        magic.Update(name, password, cost, description);
                        context.Magic.Add(magic);
                        break;

                    case "Field":
                        var field = new Field();
                        
                        field.Update(name, password, cost, description);
                        context.Field.Add(field);
                        break;

                    case "Ritual":
                        var ritual = new Ritual();
                        
                        ritual.Update(name, password, cost, description);
                        context.Ritual.Add(ritual);
                        break;

                    default:
                        throw new ArgumentException($"Unknown card type: {card["Type"].ToString()}");
                }

                context.SaveChanges();
            }
        }

    }

    
}
