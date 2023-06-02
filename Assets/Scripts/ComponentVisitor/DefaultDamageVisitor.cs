using Items.WeaponItem.WeaponComponent;

namespace ComponentVisitor
{
    public class DefaultDamageVisitor : AbstractVisitor
    {
        public int Damage { get; private set; }

        public override void Visit<T>(DefaultDamage<T> defaultDamage)
        {
            Damage = defaultDamage.GetDamage();
        }
    }
}