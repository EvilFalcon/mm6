using System;
using Interface;
using Items.WeaponComponent;
using Items.WeaponComponent.DamageType;
using PlayerScripts.PlayerComponent.Resistrs;

namespace Items.WeaponItem
{
    public class Weapon : AbstractItem
    {
        private readonly Type[] _blackComponentTypes = 
        {
            typeof(Damage<MagicDamage>),
            typeof(BaseResist),
        };

        public Weapon(string equipStat) : base(equipStat)
        {
        }

        public new void AddComponent(IComponent component)
        {
            if (CheckConformity(component) == false)
                base.Add(component);
        }

        private bool CheckConformity(IComponent component)
        {
            Type componentType = component.GetType();

            foreach (var type in _blackComponentTypes)
            {
                if (componentType == type || componentType.IsSubclassOf(type))
                {
                    return true;
                }
            }

            return false;
        }
    }
}