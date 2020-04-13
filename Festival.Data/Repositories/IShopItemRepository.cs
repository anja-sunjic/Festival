using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface IShopItemRepository
    {
        List<ShopItem> GetAll();
        ShopItem GetByID(int ID);
        bool Add(ShopItem item);
        bool Delete(int iD);
        void Save();
    }
}
