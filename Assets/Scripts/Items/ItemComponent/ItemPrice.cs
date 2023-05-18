using ComponentVisitor;
using Interface;

namespace Items.ItemComponent
{
    public class ItemPrice<T> : IComponent where T : IItemPrice
    {
        public ItemPrice(int price, int multiplier)
        {
            Price = price;
            Multiplier = multiplier;
        }

        public int Price { get; private set; }
        public int Multiplier { get; private set; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}