using Items.CombinedComponent;

namespace Items
{
    public interface IUpgradeItem
    {
        public int Level { get; }
        public string EquipStat { get; }
        public string TypeBonus { get; }
        public int BonusId { get; }

        public void AddComponent(CompositeComponent component, string typeBonus, int bonusId);
    }
}