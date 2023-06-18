using Items.ItemComponent.ItemComponentInfo;

namespace ComponentVisitor
{
    public class HealthVisitor : AbstractVisitor
    {
        private int _value;
        
        public int Health => _value;
        
        public override void Visit(HealthComponent component)
        {
            _value += component.Value;
        }
    }
}