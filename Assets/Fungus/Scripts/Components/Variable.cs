// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using System;

namespace Fungus
{
    /// <summary>
    /// Attribute class for variables.
    /// </summary>
    public class VariableInfoAttribute : Attribute
    {
        public VariableInfoAttribute(string category, string variableType, int order = 0)
        {
            this.Category = category;
            this.VariableType = variableType;
            this.Order = order;
        }
        
        public string Category { get; set; }
        public string VariableType { get; set; }
        public int Order { get; set; }
    }

    /// <summary>
    /// Attribute class for variable properties.
    /// </summary>
    public class VariablePropertyAttribute : PropertyAttribute 
    {
        public VariablePropertyAttribute (params System.Type[] variableTypes) 
        {
            this.VariableTypes = variableTypes;
        }

        public VariablePropertyAttribute (string defaultText, params System.Type[] variableTypes) 
        {
            this.defaultText = defaultText;
            this.VariableTypes = variableTypes;
        }

        public String defaultText = "<None>";

        public Type[] VariableTypes { get; set; }
    }

    /// <summary>
    /// Abstract base class for variables.
    /// </summary>
    [RequireComponent(typeof(Flowchart))]
    public abstract class Variable : MonoBehaviour, IVariable
    {
        [SerializeField] protected VariableScope scope;

        [SerializeField] protected string key = "";

        #region IVariable implementation

        public virtual VariableScope Scope { get { return scope; } }

        public virtual string Key { get { return key; } set { key = value; } }

        public abstract void OnReset();

        #endregion
    }

    /// <summary>
    /// Generic concrete base class for variables.
    /// </summary>
    public abstract class VariableBase<T> : Variable
    {
        [SerializeField] protected T value;
        public virtual T Value { get { return this.value; } set { this.value = value; } }
        
        protected T startValue;

        public override void OnReset()
        {
            Value = startValue;
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }
        
        protected virtual void Start()
        {
            // Remember the initial value so we can reset later on
            startValue = Value;
        }
    }
}
