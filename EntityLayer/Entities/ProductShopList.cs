using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class ProductShopList
    {
        public int ProductId { get; set; }
        public int ShopListId { get; set; }
        public Product Product { get; set; }
        public ShopList ShopList { get; set; }
        public string? Note { get; set; }
        public bool IsBought { get; set; } = false;
    }
}
