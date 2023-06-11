using ComponentVisitor;
using Interface;

namespace Items.ItemComponent
{
    public class ItemDescription : IComponent 
    {
        public ItemDescription(string description, int order)
        {
            Description = description;
            Order = order;
        }

        public string Description { get; }
        public int Order { get; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}