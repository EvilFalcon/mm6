using UnityEngine;

namespace Items.Spawners
{
    public class SpawnerItemData : MonoBehaviour
    {
        [SerializeField] private int _level;
        [SerializeField] private string _skillGroup;
        [SerializeField] private string _equipStat;

        public int Level => _level;
        public string SkillGroup => _skillGroup;
        public string EquipStat => _equipStat;
    }
}