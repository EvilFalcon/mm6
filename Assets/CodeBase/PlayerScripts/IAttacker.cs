using Interface;

namespace PlayerScripts
{
    public interface IAttacker
    {
        public void Attack(IDamageable enemy);
    }
}