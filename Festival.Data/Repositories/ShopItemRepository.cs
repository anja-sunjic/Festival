using System;
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
            if (item == null) throw new Exception($"Can't find shop item with Id: {ID}");

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
            var shopItem = _context.ShopItem.Find(ID);
            if (shopItem == null) throw new Exception($"Can't find shop item with Id: {ID}");

            return shopItem;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
