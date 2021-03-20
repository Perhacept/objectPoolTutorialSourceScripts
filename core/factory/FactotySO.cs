using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactotySO<T> : ScriptableObject, IFactory<T>
{
    public abstract T Create();
}
