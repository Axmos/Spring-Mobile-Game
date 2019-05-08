using System;
using UnityEngine;
/// <summary>
/// FloatReference Class.
/// </summary>
[Serializable]
public class FloatReference : Reference<float, FloatVariable> {
    public FloatReference(float Value) : base(Value) { }
    public FloatReference() { }
}

/// <summary>
/// FloatVariable Class.
/// </summary>
[CreateAssetMenu(menuName = "Variables/Float Variable", order = 1)]
public class FloatVariable : Variable<float> { }