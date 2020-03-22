﻿using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    /// <summary>
    /// Represents the model configuration for all entities.
    /// </summary>
    public class AllODataModelConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.EntitySet<ChangeDocumentsSet>("ChangeDocumentsSet")
                .EntityType
                .Select().Expand().Filter().OrderBy().Count().Page();
        }
    }
}
