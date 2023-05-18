using System;
using System.Collections.Generic;
using Interface;
using PlayerScripts.PlayerComponent.PlayerParameters;

namespace ComponentVisitor
{
    public class ParameterVisitor : AbstractVisitor
    {
        private Dictionary<Type, IComponent> _components;

        private Type _typeParameter;

        public override void Visit<T>(Parameter<T> component)
        {
            Type type = typeof(T);

            if (_components.ContainsKey(type) == false)
                _components[type] = new Parameter<T>(0);

            Parameter<T> currentDamage = (Parameter<T>)_components[type];
            _components[type] = new Parameter<T>(currentDamage.Value + component.Value);
        }

        public Parameter<T> GetParameter<T>() where T : IParameterType
        {
            _typeParameter = typeof(T);

            if (_components.ContainsKey(_typeParameter) == false)
                return new Parameter<T>(0);

            return (Parameter<T>)_components[_typeParameter];
        }

        public Type ApplyToAll()
        {
            if (_typeParameter is null)
                throw new Exception("ApplyToAll-->_typePorameter==null");

            return _typeParameter;
        }
    }
}