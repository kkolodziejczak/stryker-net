﻿using Buildalyzer;
using Microsoft.CodeAnalysis;
using Mono.Cecil;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stryker.Core.Initialisation
{
    public static class EmbeddedResourcesGenerator
    {
        public static IEnumerable<ResourceDescription> GetManifestResources(AnalyzerResult analyzerResult)
        {
            var originalDllFile = Path.Combine(Path.GetDirectoryName(analyzerResult.ProjectFilePath), analyzerResult.Items["IntermediateAssembly"][0].ItemSpec);
            ModuleDefinition module = ModuleDefinition.ReadModule(originalDllFile);
            var resourceDescriptions = new List<ResourceDescription>();

            foreach (EmbeddedResource moduleResource in module.Resources.Where(r => r.ResourceType == ResourceType.Embedded))
            {
                resourceDescriptions.Add(
                    new ResourceDescription(
                        moduleResource.Name,
                        () => moduleResource.GetResourceStream(),
                        moduleResource.IsPublic));
            }

            return resourceDescriptions;
        }
    }
}