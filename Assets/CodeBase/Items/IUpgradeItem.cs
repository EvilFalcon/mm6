using Items.CombinedComponent;

namespace Items
{
    public interface IUpgradeItem
    {
        public void AddComponent(СompositeComponent component);
        public int Level { get; }
        public string EquipStat { get; }
    }
}