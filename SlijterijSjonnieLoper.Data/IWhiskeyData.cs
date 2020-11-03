using SlijterijSjonnieLoper.Core;
using System.Collections.Generic;
using System.Linq;

namespace SlijterijSjonnieLoper.Data
{
    public interface IWhiskeyData
    {
        IEnumerable<Whiskey> GetWhiskeysByName(string name);
    }

    public class InMemoryWhiskeyData : IWhiskeyData
    {
        readonly List<Whiskey> whiskeys;
        public InMemoryWhiskeyData()
        {
            whiskeys = new List<Whiskey>()
            {
                new Whiskey{ Id = 1, Name = "Blue Label", Price = 159.99m, Brand = WhiskeyBrand.JohnnieWalker, Type = WhiskeyType.Scotch},
                new Whiskey{ Id = 2, Name = "Double Oak", Price = 28.49m, Brand = WhiskeyBrand.JimBeam, Type = WhiskeyType.Bourbon},
                new Whiskey{ Id = 3, Name = "12 Y", Price = 159.32m, Brand = WhiskeyBrand.Yamazaki, Type = WhiskeyType.Japanese},
                new Whiskey{ Id = 4, Name = "100% RYE", Price = 200.60m, Brand = WhiskeyBrand.CanadianClub, Type = WhiskeyType.Canadian},
                new Whiskey{ Id = 5, Name = "Black Barrel", Price = 33.99m, Brand = WhiskeyBrand.Jameson, Type = WhiskeyType.Irish},

            };
        }
        public IEnumerable<Whiskey> GetWhiskeysByName(string name = null)
        {
            return from w in whiskeys
                   where string.IsNullOrEmpty(name) || w.Name.StartsWith(name)
                   orderby w.Name
                   select w;
        }
    }
}