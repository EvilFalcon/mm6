using UnityEngine;

namespace Interface
{
    public interface IDamageable
    {
        Vector3 Position { get; }
        
        void TakeDamage(int attack);
    }
}