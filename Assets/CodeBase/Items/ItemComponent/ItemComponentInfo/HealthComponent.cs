using ComponentVisitor;
using Interface;

namespace Items.ItemComponent.ItemComponentInfo
{
    public class HealthComponent : IComponent
    {
        public HealthComponent(int value)
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