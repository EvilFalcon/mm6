using ComponentVisitor;
using Interface;

namespace Items.ItemComponent
{
    public class ItemDescription : IComponent 
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