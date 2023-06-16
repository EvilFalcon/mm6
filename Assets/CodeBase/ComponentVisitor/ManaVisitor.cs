using Items.ItemComponent.ItemComponentInfo;

namespace ComponentVisitor
{
    public class ManaVisitor : AbstractVisitor
    {
        public int ManaPoint { get; private set; }

        public override void Visit(ManaComponent component)
        {
            ManaPoint += component.Value;
        }
    }
}