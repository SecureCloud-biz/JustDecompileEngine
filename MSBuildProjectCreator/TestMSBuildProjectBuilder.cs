﻿using System;
using Telerik.JustDecompiler.External;
using Telerik.JustDecompiler.Languages;
using JustDecompile.EngineInfrastructure;
using Mono.Cecil.AssemblyResolver;
using Telerik.JustDecompiler.External.Interfaces;

namespace JustDecompile.Tools.MSBuildProjectBuilder
{
	public class TestMSBuildProjectBuilder : MSBuildProjectBuilder
	{
		public TestMSBuildProjectBuilder(string assemblyPath, string targetPath, ILanguage language, VisualStudioVersion visualStudioVersion = VisualStudioVersion.VS2010, ProjectGenerationSettings projectGenerationSettings = null, IProjectGenerationNotifier projectNotifier = null)
			: base(assemblyPath, targetPath, language, new TestsFrameworkVersionResolver(), new DecompilationPreferences() { RenameInvalidMembers = true, WriteDocumentation = true, WriteFullNames = false }, null, NoCacheAssemblyInfoService.Instance, TargetPlatformResolver.Instance, visualStudioVersion, projectGenerationSettings, projectNotifier)
		{
			this.exceptionFormater = TestCaseExceptionFormatter.Instance;
			this.currentAssemblyResolver.ClearCache();
		}

		class TestsFrameworkVersionResolver : IFrameworkResolver
        {
            public FrameworkVersion GetDefaultFallbackFramework4Version()
            {
                return FrameworkVersion.v4_0;
            }
        }
	}
}
