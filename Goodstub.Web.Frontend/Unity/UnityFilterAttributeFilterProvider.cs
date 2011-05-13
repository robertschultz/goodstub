using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Goodstub.Web.Frontend.Unity
{
    /// <summary>
    /// Wires up the dependency injection using a <see cref="IUnityContainer"/> to map properties for MVC attributes.
    /// </summary>
    public class UnityFilterAttributeFilterProvider : FilterAttributeFilterProvider
    {
        /// <summary>
        /// Instance of a IUnityContainer to inject dependencies.
        /// </summary>
        private IUnityContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityFilterAttributeFilterProvider"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public UnityFilterAttributeFilterProvider(IUnityContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Gets a collection of controller attributes.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="actionDescriptor">The action descriptor.</param>
        /// <returns>
        /// A collection of controller attributes.
        /// </returns>
        protected override IEnumerable<FilterAttribute> GetControllerAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var attributes = base.GetControllerAttributes(controllerContext, actionDescriptor);
            foreach (var attribute in attributes)
            {
                if (null != attribute && !(attribute is IController))
                {
                    container.BuildUp(attribute.GetType(), attribute);
                }
            }

            return attributes;
        }

        /// <summary>
        /// Gets a collection of custom action attributes.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="actionDescriptor">The action descriptor.</param>
        /// <returns>
        /// A collection of custom action attributes.
        /// </returns>
        protected override IEnumerable<FilterAttribute> GetActionAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var attributes = base.GetActionAttributes(controllerContext, actionDescriptor);
            foreach (var attribute in attributes)
            {
                if (null != attribute && !(attribute is IController))
                {
                    container.BuildUp(attribute.GetType(), attribute);
                }
            }

            return attributes;
        }
    }
}