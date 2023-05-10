using Interface;

namespace Items
{
    public class Weapon : IAttaker
    {
        public Weapon(int damage)
        {
            Damage = damage;
        }

        public int Damage { get; private set; }
        
        public void Attack(IDamageable enemy)
        {
            enemy.TakeDamage(Damage);
        }
    }
}