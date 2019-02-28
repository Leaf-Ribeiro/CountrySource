using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Infrastructure
{
    public class IoCWorker
    {
        private static SimpleInjector.Container _container;

        public static SimpleInjector.Container Container
        {
            get
            {
                try
                {
                    if (_container == null)
                    {
                        lock (typeof(IoCWorker))
                        {
                            if (_container == null)
                            {
                                _container = new SicongerpPlatformContainer();
                            }
                        }
                    }
                    return _container;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static TService Resolve<TService>() where TService : class
        {
            try
            {
                return Container.GetInstance<TService>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object Resolve(Type type)
        {
            try
            {
                return Container.GetInstance(type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RegisterType(Type type)
        {
            try
            {
                Container.Register(type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RegisterType<F, T>(Lifestyle lifetime)
            where F : class
            where T : class, F
        {
            try
            {
                Container.Register<F, T>(lifetime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RegisterType<F, T>()
            where F : class
            where T : class, F
        {
            try
            {
                Container.Register<F, T>(Lifestyle.Transient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RegisterType<T>() where T : class
        {
            try
            {
                Container.Register<T>(Lifestyle.Transient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RegisterType<T>(Lifestyle lifetime) where T : class
        {
            try
            {
                Container.Register<T>(lifetime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Release(object instance)
        {
            //Container.R
        }
    }
}
