using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Glimpse.Core.Extensibility
{
    public class AlternateImplementationGenerationHook<T> : IProxyGenerationHook where T:class
    {
        private IEnumerable<MethodInfo> methodSet;
        private IEnumerable<IAlternateImplementation<T>> methodImplementations;
        internal IEnumerable<IAlternateImplementation<T>> MethodImplementations
        {
            get { return methodImplementations; }
            set
            {
                methodImplementations = value;
                methodSet = value.Select(m => m.MethodToImplement);
            }
        }

        internal ILogger Logger { get; set; }

        public AlternateImplementationGenerationHook(IEnumerable<IAlternateImplementation<T>> methodImplementations, ILogger logger)
        {
            if (methodImplementations == null) throw new ArgumentNullException("methodImplementations");
            if (logger == null) throw new ArgumentNullException("logger");
            
            MethodImplementations = methodImplementations;
            Logger = logger;
        }

        

        public override bool Equals(object obj)
        {
            var input = obj as AlternateImplementationGenerationHook<T>;

            if (input == null) return false;

            var result = 
                methodSet.SequenceEqual(input.MethodImplementations.Select(m=>m.MethodToImplement));

            return result;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;

                foreach (var implementation in MethodImplementations)
                {
                    hash = hash * 23 + implementation.GetType().GetHashCode();
                }

                return hash;
            }
        }

        public void MethodsInspected()
        {
            Logger.Debug(Resources.AlternateImplementationGenerationHookMethodsInspected, typeof(T));
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
            Logger.Debug(Resources.AlternateImplementationGenerationHookNonProxyableMemberNotification, memberInfo.Name, type);
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return MethodImplementations.Any(i => i.MethodToImplement == methodInfo);
        }
    }
}