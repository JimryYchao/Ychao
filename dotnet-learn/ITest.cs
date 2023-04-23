using System;
using System.Threading;

public abstract class ITest<T> where T : new()
{
    public readonly static T Instance = new T();

    /// <summary>
    /// ref Object
    /// </summary>
    protected abstract Type ref_Class { get; }
    public abstract void Test();
}
