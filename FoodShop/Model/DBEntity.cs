using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Model
{
    public class DBEntity
    {
        public string Id { get; set; }
        public string FoodName { get; set; }
        public string FoodDesc { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
