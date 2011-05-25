using System;
using System.Collections.Generic;
using CazualGames.Core;

namespace CazualGames.Services
{
    public class ServiceLocator
    {
        private ServiceLocator()
        {
        }

        public static ServiceLocator GetTestLocator()
        {
            return new ServiceLocator();
        }

        private static ServiceLocator _currentInstance;

        public static ServiceLocator Current
        {
            get
            {
        
                if(_currentInstance == null)
                {
                    _currentInstance = new ServiceLocator();
                }

                return _currentInstance;
            }
        }

        private Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public void RegisterService<T>(object instance)
        {
            if(instance == null)
                throw new ArgumentNullException("Cannot register a null object as a service");
 
            if(instance.GetType().GetInterface(typeof(T).Name, true) != typeof(T))
                throw new ArgumentException(string.Format("{0} does not implement {1}", instance.GetType().Name, typeof(T).Name));

            if(_services.ContainsKey(typeof(T)))
            {
                _services.Remove(typeof (T));
            }
        
            _services.Add(typeof(T), instance);
        }

        public T GetService<T>()
        {
            if (_services.ContainsKey(typeof(T)))
            {
                return (T)_services[typeof(T)];
            }

            throw new CazualGamesException(string.Format("{0} service was not found", typeof(T).Name));
        }
    }
}