using ComponentVisitor;
using HealthPoint;
using Interface;
using PlayerScripts.PlayerComponent.Equipment;
using PlayerScripts.PlayerComponent.Resistrs;

namespace PlayerScripts
{
    public abstract class Hero : IAttacker, IDamageable, IComponent
    {
        private readonly Health _health;
        private readonly Resists _resists;
        private readonly ParametersComponents.Parameters _parameters;
        private readonly HeroEquipment _equipment;

        protected Hero(Health health, Resists resists, ParametersComponents.Parameters parameters)
        {
            _equipment = new HeroEquipment();
            _health = new Health(this);
            _resists = resists;
            _parameters = parameters;
            _health.Died += OnDied;
        }

        private void OnDisable()
        {
            _health.Died -= OnDied;
        }

        private void OnDied()
        {
            OnDisable();
        }

        public void TakeDamage(int attack)
        {
            _health.TakeDamage(attack);
        }

        public void Attack(IDamageable enemy)
        {
            enemy.TakeDamage(1);
        }

        public void Accept(IComponentVisitor visitor)
        {
            _resists.Accept(visitor);
            _parameters.Accept(visitor);
            _equipment.Accept(visitor);
        }
    }
}