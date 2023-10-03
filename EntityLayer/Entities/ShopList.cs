using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class ShopList
    {
        public int ShopListId { get; set; }
        public string ShopListName { get; set; }
        public bool State { get; set; } = true;
        public List<ProductShopList> Products { get; set; }
    }

}
