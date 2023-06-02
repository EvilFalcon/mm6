using Items.CombinedComponent;

namespace Items.WeaponItem
{
    public class Weapon : AbstractItem, IItem
    {
        public void AddDefaultComponent(СompositeComponent baseComponents, string equipStat, string skillGroup, int level)
        {
            AddDefaultParams(baseComponents, equipStat, skillGroup, level);
        }

        public void AddComponent(СompositeComponent component)
        {
            Add(component);
        }
    }
}