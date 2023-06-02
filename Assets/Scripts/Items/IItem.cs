using Items.CombinedComponent;

namespace Items
{
    public interface IItem
    {
        public void AddDefaultComponent(СompositeComponent baseComponents, string equipStat, string skillGroup, int level);
        public void AddComponent(СompositeComponent component);
    }
}