using System;

namespace Zommarin.MVVM.ContainerSupport
{
    /// <summary>
    /// Classes marked with this attribute should only have a single instance
    /// when used in an application context.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonInAppAttribute : Attribute
    {
    }
}
