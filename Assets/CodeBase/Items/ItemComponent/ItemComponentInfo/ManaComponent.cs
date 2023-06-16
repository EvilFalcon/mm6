using ComponentVisitor;
using Interface;

namespace Items.ItemComponent.ItemComponentInfo
{
    public class ManaComponent : IComponent
    {
        public ManaComponent(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}