﻿namespace WcfService
{
    using System;

    using Castle.Facilities.WcfIntegration;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using Domain.Dal.Repositories.Abstract;
    using Domain.Dal.Repositories.Concrete;
    using Domain.Models;
    using Domain.Services.Abstract;
    using Domain.Services.Concrete;
    using Domain.Validations.Abstract;
    using Domain.Validations.Concrete;

    using WcfService.Contracts;

    public class Global : System.Web.HttpApplication
    {
        private IWindsorContainer _container;

        protected void Application_End(object sender, EventArgs e)
        {
            if (this._container != null)
            {
                this._container.Dispose();
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            DatabaseValidationSettings databaseValidationSettings = new DatabaseValidationSettings();
            DbRepositorySettings dbRepositorySettings = new DbRepositorySettings();

            this._container = new WindsorContainer();
            this._container.AddFacility<WcfFacility>()
                .Register(Component.For<DatabaseValidationSettings>()
                    .Instance(databaseValidationSettings), Component.For<DbRepositorySettings>()
                    .Instance(dbRepositorySettings), Component.For<IDatabaseValidation>()
                    .ImplementedBy<DatabaseValidation>(), Component.For<IDbRepository>()
                    .ImplementedBy<DbRepository>(), Component.For<IDatabaseService>()
                    .ImplementedBy<DatabaseService>(), Component.For<IDbWcfService>()
                    .ImplementedBy<DbWcfService>()
                    .Named("DbWcfService"));
        }
    }
}