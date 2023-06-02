using Items.CombinedComponent;

namespace Items.Bijouterie
{
    public class Bijouterie : AbstractItem, IItem
    {
        public void AddDefaultComponent(СompositeComponent baseComponents, string equipStat, string skillGroup, int level)
        {
            AddDefaultParams(baseComponents, equipStat, skillGroup, level);
        }

        public void AddComponent(СompositeComponent component)
        {
            base.Add(component);
        }
    }
}