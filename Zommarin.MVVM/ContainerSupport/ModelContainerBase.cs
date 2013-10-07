using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace Zommarin.MVVM.ContainerSupport
{
    public class ContainerWrapper : IDisposable
    {
        private static readonly Lazy<ContainerWrapper> _instance = new Lazy<ContainerWrapper>(() => new ContainerWrapper());
        public static ContainerWrapper Wrapper { get { return _instance.Value; } }

        private ContainerWrapper()
        {
        }

        private readonly object _lock = new object();

        private UnityContainer _container;

        private bool _isDisposed;

        private readonly IList<string> _namespaceList = new List<string>();

        private UnityContainer GetUnityContainer()
        {
            lock (_lock)
            {
                if (_isDisposed)
                {
                    throw new InvalidOperationException("Object has already been disposed");
                }
                if (_container == null)
                {
                    _container = new UnityContainer();
                }
                return _container;
            }
        }

        public void AddNamespace(string ns)
        {
            _namespaceList.Add(ns);
        }

        public void Configure()
        {
            
        }

        internal T Resolve<T>()
        {
            return GetUnityContainer().Resolve<T>();
        }

        public void Dispose()
        {
            lock (_lock)
            {
                if (_container != null && !_isDisposed)
                {
                    _container.Dispose();
                    _container = null;
                }
                _isDisposed = true;
            }
        }
    }

    public abstract class ContainerBase
    {
        protected ContainerBase()
        {
            ContainerWrapper = ContainerWrapper.Wrapper;
        }

        protected ContainerWrapper ContainerWrapper { get; private set; }

        protected T Resolve<T>()
        {
            return ContainerWrapper.Resolve<T>();
        }
    }

    /// <summary>
    /// Base class for the container helper for the Model of a MVVM application
    /// </summary>
    public abstract class ModelContainerBase : ContainerBase
    {

    }

    /// <summary>
    /// Base class for the container helper for the ViewModel of a MVVM application
    /// </summary>
    public abstract class ViewModelContainerBase : ContainerBase
    {
        
    }

    /// <summary>
    /// Base class for the container helper for the View of a MVVM application
    /// </summary>
    public abstract class ViewContainerBase : ContainerBase
    {
        
    }
}
