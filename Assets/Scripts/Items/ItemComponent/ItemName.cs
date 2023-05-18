using ComponentVisitor;
using Interface;

namespace Items.ItemComponent
{
    public class ItemName : IComponent
    {
        public ItemName(string type, int order)
        {
            Type = type;
            Order = order;
        }

        public string Type { get; }
        public int Order { get; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}