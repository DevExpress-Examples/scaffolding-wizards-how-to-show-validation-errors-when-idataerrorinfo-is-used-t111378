﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using Scaffolding.ValidationErrors.Localization;
using Scaffolding.ValidationErrors.DepartmentContextDataModel;

namespace Scaffolding.ValidationErrors.ViewModels {
    /// <summary>
    /// Represents the root POCO view model for the DepartmentContext data model.
    /// </summary>
    public partial class DepartmentContextViewModel : DocumentsViewModel<DepartmentContextModuleDescription, IDepartmentContextUnitOfWork> {

        const string TablesGroup = "Tables";

        const string ViewsGroup = "Views";

        /// <summary>
        /// Creates a new instance of DepartmentContextViewModel as a POCO view model.
        /// </summary>
        public static DepartmentContextViewModel Create() {
            return ViewModelSource.Create(() => new DepartmentContextViewModel());
        }

        static DepartmentContextViewModel() {
            MetadataLocator.Default = MetadataLocator.Create().AddMetadata<DepartmentContextMetadataProvider>();
        }
        /// <summary>
        /// Initializes a new instance of the DepartmentContextViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the DepartmentContextViewModel type without the POCO proxy factory.
        /// </summary>
        protected DepartmentContextViewModel()
            : base(UnitOfWorkSource.GetUnitOfWorkFactory()) {
        }

        protected override DepartmentContextModuleDescription[] CreateModules() {
            return new DepartmentContextModuleDescription[] {
                new DepartmentContextModuleDescription(DepartmentContextResources.DepartmentPlural, "DepartmentCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Departments)),
            };
        }
    }

    public partial class DepartmentContextModuleDescription : ModuleDescription<DepartmentContextModuleDescription> {
        public DepartmentContextModuleDescription(string title, string documentType, string group, Func<DepartmentContextModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory) {
        }
    }
}