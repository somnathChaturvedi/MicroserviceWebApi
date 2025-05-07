using System.Collections.Generic;

namespace CartMicroservice.Model
{
    public class Carts
    {
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
