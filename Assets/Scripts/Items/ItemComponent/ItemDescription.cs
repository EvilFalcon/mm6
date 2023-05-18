using ComponentVisitor;
using Interface;

namespace Items.ItemComponent
{
    public class ItemDescription<T> : IComponent where T : IItemDescription
    {
        public ItemDescription(string description)
        {
            Description = description;
        }

        public string Description { get; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}