using Data.ParcerJson;
using Items.CombinedComponent;

namespace Items
{
    public interface IInitializableItem
    {
        public void AddDefaultComponent(CompositeComponent baseComponents, ItemData itemData, int level);
    }
}