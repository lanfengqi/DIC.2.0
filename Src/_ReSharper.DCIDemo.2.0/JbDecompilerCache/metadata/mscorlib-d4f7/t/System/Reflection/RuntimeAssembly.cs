// Type: System.Reflection.RuntimeAssembly
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Globalization;
using System.IO;
using System.Reflection.Cache;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Threading;

namespace System.Reflection
{
    [ForceTokenStabilization]
    [Serializable]
    internal class RuntimeAssembly : Assembly, ICustomQueryInterface
    {
        internal RuntimeAssembly();
        internal object SyncRoot { get; }

        public override string CodeBase { [SecuritySafeCritical]
        get; }

        public override string FullName { [SecuritySafeCritical]
        get; }

        public override MethodInfo EntryPoint { [SecuritySafeCritical]
        get; }

        public override Evidence Evidence { [SecuritySafeCritical, SecurityPermission(SecurityAction.Demand, ControlEvidence = true)]
        get; }

        internal Evidence EvidenceNoDemand { [SecurityCritical]
        get; }

        public override PermissionSet PermissionSet { [SecurityCritical]
        get; }

        public override SecurityRuleSet SecurityRuleSet { [SecuritySafeCritical]
        get; }

        public override Module ManifestModule { get; }

        [ComVisible(false)]
        public override bool ReflectionOnly { [SecuritySafeCritical]
        get; }

        public override string Location { [SecuritySafeCritical]
        get; }

        [ComVisible(false)]
        public override string ImageRuntimeVersion { [SecuritySafeCritical]
        get; }

        public override bool GlobalAssemblyCache { [SecuritySafeCritical]
        get; }

        public override long HostContext { [SecuritySafeCritical]
        get; }

        internal bool IsStrongNameVerified { [SecurityCritical]
        get; }

        public override bool IsDynamic { [SecuritySafeCritical]
        get; }

        internal InternalCache Cache { get; }

        #region ICustomQueryInterface Members

        [SecurityCritical]
        CustomQueryInterfaceResult ICustomQueryInterface.GetInterface([In] ref Guid iid, out IntPtr ppv);

        #endregion

        [SecurityCritical]
        internal string GetCodeBase(bool copiedName);

        internal RuntimeAssembly GetNativeHandle();

        [SecuritySafeCritical]
        public override AssemblyName GetName(bool copiedName);

        [SecuritySafeCritical]
        public override Type GetType(string name, bool throwOnError, bool ignoreCase);

        [SecurityCritical]
        [SuppressUnmanagedCodeSecurity]
        [DllImport("QCall", CharSet = CharSet.Unicode)]
        internal static void GetForwardedTypes(RuntimeAssembly assembly, ObjectHandleOnStack retTypes);

        [SecuritySafeCritical]
        public override Type[] GetExportedTypes();

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override Stream GetManifestResourceStream(Type type, string name);

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override Stream GetManifestResourceStream(string name);

        [SecurityCritical]
        public override void GetObjectData(SerializationInfo info, StreamingContext context);

        public override object[] GetCustomAttributes(bool inherit);
        public override object[] GetCustomAttributes(Type attributeType, bool inherit);
        public override bool IsDefined(Type attributeType, bool inherit);
        public override IList<CustomAttributeData> GetCustomAttributesData();

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static RuntimeAssembly InternalLoadFrom(string assemblyFile, Evidence securityEvidence, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm, bool forIntrospection, bool suppressSecurityChecks, ref StackCrawlMark stackMark);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static RuntimeAssembly InternalLoad(string assemblyString, Evidence assemblySecurity, ref StackCrawlMark stackMark, bool forIntrospection);

        [SecurityCritical]
        internal static RuntimeAssembly InternalLoadAssemblyName(AssemblyName assemblyRef, Evidence assemblySecurity, ref StackCrawlMark stackMark, bool forIntrospection, bool suppressSecurityChecks);

        [SecurityCritical]
        internal static RuntimeAssembly LoadWithPartialNameInternal(string partialName, Evidence securityEvidence, ref StackCrawlMark stackMark);

        [SecurityCritical]
        internal static RuntimeAssembly LoadWithPartialNameInternal(AssemblyName an, Evidence securityEvidence, ref StackCrawlMark stackMark);

        [SecuritySafeCritical]
        [SecurityPermission(SecurityAction.Demand, ControlEvidence = true)]
        public override Module LoadModule(string moduleName, byte[] rawModule, byte[] rawSymbolStore);

        [SecuritySafeCritical]
        public override Module GetModule(string name);

        [SecuritySafeCritical]
        public override FileStream GetFile(string name);

        [SecuritySafeCritical]
        public override FileStream[] GetFiles(bool getResourceModules);

        [SecuritySafeCritical]
        public override string[] GetManifestResourceNames();

        [SecurityCritical]
        internal static Assembly GetExecutingAssembly(ref StackCrawlMark stackMark);

        [SecuritySafeCritical]
        public override AssemblyName[] GetReferencedAssemblies();

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override ManifestResourceInfo GetManifestResourceInfo(string resourceName);

        [SecurityCritical]
        internal Stream GetManifestResourceStream(Type type, string name, bool skipSecurityCheck, ref StackCrawlMark stackMark);

        [SecurityCritical]
        internal Stream GetManifestResourceStream(string name, ref StackCrawlMark stackMark, bool skipSecurityCheck);

        [SecurityCritical]
        internal Version GetVersion();

        [SecurityCritical]
        internal CultureInfo GetLocale();

        [SecuritySafeCritical]
        internal string GetSimpleName();

        [SecuritySafeCritical]
        internal byte[] GetRawBytes();

        [SecurityCritical]
        internal byte[] GetPublicKey();

        [SecurityCritical]
        internal void GetGrantSet(out PermissionSet newGrant, out PermissionSet newDenied);

        [SecuritySafeCritical]
        internal bool IsAllSecurityCritical();

        [SecuritySafeCritical]
        internal bool IsAllSecuritySafeCritical();

        [SecuritySafeCritical]
        internal bool IsAllSecurityTransparent();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override Assembly GetSatelliteAssembly(CultureInfo culture);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override Assembly GetSatelliteAssembly(CultureInfo culture, Version version);

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal Assembly InternalGetSatelliteAssembly(CultureInfo culture, Version version, ref StackCrawlMark stackMark);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal RuntimeAssembly InternalGetSatelliteAssembly(string name, CultureInfo culture, Version version, bool throwOnFileNotFound, ref StackCrawlMark stackMark);

        internal void OnCacheClear(object sender, ClearCacheEventArgs cacheEventArgs);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static RuntimeAssembly nLoadFile(string path, Evidence evidence);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static RuntimeAssembly nLoadImage(byte[] rawAssembly, byte[] rawSymbolStore, Evidence evidence, ref StackCrawlMark stackMark, bool fIntrospection, SecurityContextSource securityContextSource);

        [SecuritySafeCritical]
        internal Module[] GetModulesInternal(bool loadIfNotFound, bool getResourceModules);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public override Module[] GetModules(bool getResourceModules);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public override Module[] GetLoadedModules(bool getResourceModules);

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static RuntimeModule GetManifestModule(RuntimeAssembly assembly);

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static bool AptcaCheck(RuntimeAssembly targetAssembly, RuntimeAssembly sourceAssembly);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static int GetToken(RuntimeAssembly assembly);

        public override event ModuleResolveEventHandler ModuleResolve;
    }
}
