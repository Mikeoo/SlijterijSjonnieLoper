using SlijterijSjonnieLoper.Core;
using System.Collections.Generic;
using System.Linq;

namespace SlijterijSjonnieLoper.Data
{
    public interface IWhiskeyData
    {
        IEnumerable<Whiskey> GetWhiskeysByName(string name);
        Whiskey GetById(int id);
        Whiskey Update(Whiskey updatedWhiskey);
        Whiskey Add(Whiskey newWhiskey);
        int Commit();
    }

    public class InMemoryWhiskeyData : IWhiskeyData
    {
        readonly List<Whiskey> whiskeys;
        public InMemoryWhiskeyData()
        {
            whiskeys = new List<Whiskey>()
            {
                new Whiskey{ Id = 1, Name = "Blue Label", Price = 159.996m, Brand = WhiskeyBrand.JohnnieWalker, Type = WhiskeyType.Scotch},
                new Whiskey{ Id = 2, Name = "Double Oak", Price = 28.49m, Brand = WhiskeyBrand.JimBeam, Type = WhiskeyType.Bourbon},
                new Whiskey{ Id = 3, Name = "12 Y", Price = 159.32m, Brand = WhiskeyBrand.Yamazaki, Type = WhiskeyType.Japanese},
                new Whiskey{ Id = 4, Name = "100% RYE", Price = 200.60m, Brand = WhiskeyBrand.CanadianClub, Type = WhiskeyType.Canadian},
                new Whiskey{ Id = 5, Name = "Black Barrel", Price = 33.99m, Brand = WhiskeyBrand.Jameson, Type = WhiskeyType.Irish},

            };
        }

        public Whiskey GetById(int id)
        {
            return whiskeys.SingleOrDefault(w => w.Id == id);
        }

        public Whiskey Add(Whiskey newWhiskey)
        {
            whiskeys.Add(newWhiskey);
            //test
            newWhiskey.Id = whiskeys.Max(w => w.Id) + 1;
            return newWhiskey;
        }
        public IEnumerable<Whiskey> GetWhiskeysByName(string name = null)
        {
            return from w in whiskeys
                   where string.IsNullOrEmpty(name) || w.Name.StartsWith(name)
                   orderby w.Name
                   select w;
        }
        public int Commit()
        {
            return 0;
        }
        public Whiskey Update(Whiskey updatedWhiskey)
        {
            var whiskey = whiskeys.SingleOrDefault(w => w.Id == updatedWhiskey.Id);
            if (whiskey != null)
            {
                whiskey.Name = updatedWhiskey.Name;
                whiskey.Price = updatedWhiskey.Price;
                whiskey.Brand = updatedWhiskey.Brand;
                whiskey.Type = updatedWhiskey.Type;

            }
            return whiskey;
        }
    }
}