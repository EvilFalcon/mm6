using Items.WeaponComponent;

namespace ComponentVisitor
{
    public class DefaultDamageVisitor : AbstractVisitor
    {
        public int Damage { get; private set; }

        public override void Visit<Physical>(DefaultDamage<Physical> defaultDamage)
        {
            Damage = defaultDamage.GetDamage();
        }
    }
}