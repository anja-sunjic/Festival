using Festival.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Data.Repositories
{
    public class ShopItemRepository : IShopItemRepository
    {
        private readonly FestivalContext _context;

        public ShopItemRepository(FestivalContext context)
        {
            _context = context;
        }
        public bool Add(ShopItem item)
        {
            _context.ShopItem.Add(item);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int ID)
        {
            ShopItem item = _context.ShopItem.Find(ID);
            _context.Remove(item);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<ShopItem> GetAll()
        {
            return _context.ShopItem.ToList();
        }

        public ShopItem GetByID(int ID)
        {
            return _context.ShopItem.Find(ID);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
