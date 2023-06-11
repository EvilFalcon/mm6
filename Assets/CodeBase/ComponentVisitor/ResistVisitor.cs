using System;
using System.Collections.Generic;
using Interface;
using PlayerScripts.PlayerComponent.Resistrs;

namespace ComponentVisitor
{
    public class ResistVisitor : AbstractVisitor
    {
        private Dictionary<Type, IComponent> _components;

        private Type _typeParameter;

        public override void Visit<T>(Resist<T> component)
        {
            Type type = typeof(T);

            if (_components.ContainsKey(type) == false)
                _components[type] = new Resist<T>(0);

            Resist<T> currentDamage = (Resist<T>)_components[type];
            _components[type] = new Resist<T>(currentDamage.Value + component.Value);
        }

        public Resist<T> GetParameter<T>() where T : IResistType
        {
            _typeParameter = typeof(T);

            if (_components.ContainsKey(_typeParameter) == false)
                return new Resist<T>(0);

            return (Resist<T>)_components[_typeParameter];
        }

        public Type ApplyToAll()
        {
            if (_typeParameter is null)
                throw new Exception("ApplyToAll-->_typeResistr==null");

            return _typeParameter;
        }
    }
}