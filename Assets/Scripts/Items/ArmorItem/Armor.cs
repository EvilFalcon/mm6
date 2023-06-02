using Items.CombinedComponent;

namespace Items.ArmorItem
{
    public class Armor : AbstractItem, IItem
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