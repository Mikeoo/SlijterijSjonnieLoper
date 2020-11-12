using SlijterijSjonnieLoper.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlijterijSjonnieLoper.Data
{
    public interface IWhiskeyData
    {
        IEnumerable<Whiskey> GetWhiskeysByName(string name);
        Whiskey GetById(int id);
        Whiskey Update(Whiskey updatedWhiskey);
        Whiskey Add(Whiskey newWhiskey);
        Whiskey Delete(int whiskeyId);
        int Commit();
    }

    public class InMemoryWhiskeyData : IWhiskeyData
    {
        readonly List<Whiskey> whiskeys;
        public InMemoryWhiskeyData()
        {
            whiskeys = new List<Whiskey>()
            {
                new Whiskey{ Id = 1, Name = "Blue Label", Price = 159.996m, Brand = WhiskeyBrand.JohnnieWalker, Type = WhiskeyType.Scotch, Area=WhiskeyArea.Highlands, Percentage=16, IsDeleted=false, AreaOptional="", WhiskeyLabel=""},
                new Whiskey{ Id = 2, Name = "Double Oak", Price = 28.49m, Brand = WhiskeyBrand.JimBeam, Type = WhiskeyType.Bourbon, Area=WhiskeyArea.Highlands, Percentage=16, IsDeleted=false, AreaOptional="", WhiskeyLabel=""},
                new Whiskey{ Id = 3, Name = "12 Y", Price = 159.32m, Brand = WhiskeyBrand.Yamazaki, Type = WhiskeyType.Japanese, Area=WhiskeyArea.Highlands, Percentage=16, IsDeleted=false, AreaOptional="", WhiskeyLabel=""},
                new Whiskey{ Id = 4, Name = "100% RYE", Price = 200.60m, Brand = WhiskeyBrand.CanadianClub, Type = WhiskeyType.Canadian, Area=WhiskeyArea.Highlands, Percentage=16, IsDeleted=false, AreaOptional="", WhiskeyLabel=""},
                new Whiskey{ Id = 5, Name = "Black Barrel", Price = 33.99m, Brand = WhiskeyBrand.Jameson, Type = WhiskeyType.Irish, Area=WhiskeyArea.Highlands, Percentage=16, IsDeleted=false, AreaOptional="", WhiskeyLabel=""},

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
                whiskey.Area = updatedWhiskey.Area;
                whiskey.Percentage = updatedWhiskey.Percentage;
                //whiskey.IsDeleted = updatedWhiskey.IsDeleted;
                //whiskey.AreaOptional = updatedWhiskey.AreaOptional;
                //whiskey.WhiskeyLabel = updatedWhiskey.WhiskeyLabel;

            }
            return whiskey;
        }
        public Whiskey Delete(int whiskeyId)
        {
            var whiskey = GetById(whiskeyId);
            if (whiskey != null)
                {
                whiskey.IsDeleted = true;
            }
            return whiskey;
        }
    }
}