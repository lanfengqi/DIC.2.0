﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Data.Seedwork.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Infrastructure.Data.Seedwork.Resources.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot add null entity into {0} repository.
        /// </summary>
        internal static string info_CannotAddNullEntity {
            get {
                return ResourceManager.GetString("info_CannotAddNullEntity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot modify null item into {0} repository.
        /// </summary>
        internal static string info_CannotModifyNullEntity {
            get {
                return ResourceManager.GetString("info_CannotModifyNullEntity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot remove null entity into {0} repository.
        /// </summary>
        internal static string info_CannotRemoveNullEntity {
            get {
                return ResourceManager.GetString("info_CannotRemoveNullEntity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot track null item into {0} repository.
        /// </summary>
        internal static string info_CannotTrackNullEntity {
            get {
                return ResourceManager.GetString("info_CannotTrackNullEntity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Added object of type {0} in repository.
        /// </summary>
        internal static string trace_AddedItemRepository {
            get {
                return ResourceManager.GetString("trace_AddedItemRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Applied changes of type {0} in repository.
        /// </summary>
        internal static string trace_AppliedChangedItemRepository {
            get {
                return ResourceManager.GetString("trace_AppliedChangedItemRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attached item in repository of type {0}.
        /// </summary>
        internal static string trace_AttachedItemToRepository {
            get {
                return ResourceManager.GetString("trace_AttachedItemToRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Created repository for type {0}.
        /// </summary>
        internal static string trace_ConstructRepository {
            get {
                return ResourceManager.GetString("trace_ConstructRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deleted object of type {0} in repository.
        /// </summary>
        internal static string trace_DeletedItemRepository {
            get {
                return ResourceManager.GetString("trace_DeletedItemRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GetAll called in repository of type {0}.
        /// </summary>
        internal static string trace_GetAllRepository {
            get {
                return ResourceManager.GetString("trace_GetAllRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Get items by specification in repository of type {0}.
        /// </summary>
        internal static string trace_GetBySpec {
            get {
                return ResourceManager.GetString("trace_GetBySpec", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GetFilteredElements called in repository of type {0} with Filter:{1}.
        /// </summary>
        internal static string trace_GetFilteredElementsRepository {
            get {
                return ResourceManager.GetString("trace_GetFilteredElementsRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GetFilteredElements called in repository of type {0} with Filter:{1} PageIndex:{2} PageCount:{3} OrderBy:{4}.
        /// </summary>
        internal static string trace_GetFilteredPagedElementsRepository {
            get {
                return ResourceManager.GetString("trace_GetFilteredPagedElementsRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GetPagedElements called in repository of type {0} with PageIndex:{1},PageCount:{2},OrderBy:{3}.
        /// </summary>
        internal static string trace_GetPagedElementsRepository {
            get {
                return ResourceManager.GetString("trace_GetPagedElementsRepository", resourceCulture);
            }
        }
    }
}