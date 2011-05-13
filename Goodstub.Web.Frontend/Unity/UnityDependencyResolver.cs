using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Goodstub.Web.Frontend.Unity
{
   /// <summary>
	/// Instance of a <see cref="IDependencyResolver"/> used to resolve Unity based dependencies.
	/// </summary>
	public class UnityDependencyResolver : IDependencyResolver
	{
		/// <summary>
		/// Private instance of the container used for dependency mapping.
		/// </summary>
		private IUnityContainer container;

		/// <summary>
		/// Initializes a new instance of the <see cref="UnityDependencyResolver"/> class.
		/// </summary>
		/// <param name="container">The container.</param>
		public UnityDependencyResolver(IUnityContainer container)
		{
			this.container = container;
			this.container.RegisterInstance<IFilterProvider>("attributes", new UnityFilterAttributeFilterProvider(container));
		}

		/// <summary>
		/// Resolves singly registered services that support arbitrary object creation.
		/// </summary>
		/// <param name="serviceType">The type of the requested service or object.</param>
		/// <returns>
		/// The requested service or object.
		/// </returns>
		public object GetService(Type serviceType)
		{
			object returnVal = null;

			try
			{
				if (!serviceType.IsAbstract && !serviceType.IsInterface)
				{
					if (!container.IsRegistered(serviceType))
					{
						returnVal = container.Resolve(serviceType);
					}
				}
			}
			catch (Exception ex)
			{
				//Shared.ExceptionManagement.MFNExceptionManager.PublishCriticalException("UnityDependencyResolver", ex);
				throw;
			}

			return returnVal;
		}

		/// <summary>
		/// Resolves multiply registered services.
		/// </summary>
		/// <param name="serviceType">The type of the requested services.</param>
		/// <returns>
		/// The requested services.
		/// </returns>
		public IEnumerable<object> GetServices(Type serviceType)
		{
			IEnumerable<object> returnVal = new List<object>();

			try
			{
				if (!container.IsRegistered(serviceType))
				{
					returnVal = container.ResolveAll(serviceType);
				}
			}
			catch (Exception ex)
			{
				//Shared.ExceptionManagement.MFNExceptionManager.PublishCriticalException("UnityDependencyResolver", ex);
				throw;
			}

			return returnVal;
		}
	}
}