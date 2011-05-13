// <copyright file="PexAssemblyInfo.cs" company="Microsoft">Copyright © Microsoft 2011</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Moles;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;
using Microsoft.Pex.Linq;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("Goodstub.Web.Frontend")]
[assembly: PexInstrumentAssembly("Goodstub.Data")]
[assembly: PexInstrumentAssembly("System.ServiceModel")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("Microsoft.Practices.Unity.Configuration")]
[assembly: PexInstrumentAssembly("System.Configuration")]
[assembly: PexInstrumentAssembly("Microsoft.CSharp")]
[assembly: PexInstrumentAssembly("System.Web")]
[assembly: PexInstrumentAssembly("System.ComponentModel.DataAnnotations")]
[assembly: PexInstrumentAssembly("System.Web.Mvc")]
[assembly: PexInstrumentAssembly("Goodstub.Service.Contract")]
[assembly: PexInstrumentAssembly("System.Web.ApplicationServices")]
[assembly: PexInstrumentAssembly("Microsoft.Practices.Unity")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Goodstub.Data")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.ServiceModel")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Practices.Unity.Configuration")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Configuration")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.CSharp")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.ComponentModel.DataAnnotations")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web.Mvc")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Goodstub.Service.Contract")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web.ApplicationServices")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Practices.Unity")]

// Microsoft.Pex.Framework.Moles
[assembly: PexAssumeContractEnsuresFailureAtBehavedSurface]
[assembly: PexChooseAsBehavedCurrentBehavior]

// Microsoft.Pex.Linq
[assembly: PexLinqPackage]

