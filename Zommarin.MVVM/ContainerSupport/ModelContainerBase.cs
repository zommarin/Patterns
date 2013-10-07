using System;
using Microsoft.Practices.Unity;

namespace Zommarin.MVVM.ContainerSupport
{
    internal class ContainerInstance
    {
        private static readonly Lazy<Container> 
    }
    public abstract class ContainerBase
    {
        
    }

    /// <summary>
    /// Base class for the Models container factory
    /// </summary>
    public abstract class ModelContainerBase : ContainerBase
    {

    }

    public abstract class ViewModelContainerBase : ContainerBase
    {
        
    }

    public abstract class ViewContainerBase : ContainerBase
    {
        
    }
}
