using Data.ParcerJson;
using Items.CombinedComponent;

namespace Items
{
    public interface IInitializableItem
    {
        public void AddDefaultComponent(СompositeComponent baseComponents, ItemData itemData, int level);
    }
}