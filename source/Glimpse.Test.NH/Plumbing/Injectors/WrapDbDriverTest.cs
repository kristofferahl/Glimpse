﻿using Glimpse.Core.Extensibility;
using Glimpse.NH.Plumbing.Injectors;
using Glimpse.Test.NH.DataContext;
using Moq;
using NUnit.Framework;

namespace Glimpse.Test.NH.Plumbing.Injectors
{
    [TestFixture]
    public class WrapDbDriverTest
    {
        private WrapDbDriver _sut;
        private Mock<IGlimpseLogger> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<IGlimpseLogger>();
            _sut = new WrapDbDriver(_logger.Object);
        }

        [Test]
        public void WrapDbDriver_Inject_does_not_throw_for_NH_320()
        {
            using (NHibernate.Version(NHibernateVersion.NH_320))
            {
                _sut.Inject();
            }
        }

        [Test, Ignore("Work in progress")]
        public void WrapDbDriver_Inject_does_not_throw_for_NH_310()
        {
            using (NHibernate.Version(NHibernateVersion.NH_310))
            {
                _sut.Inject();
            }
        }

        [Test, Ignore("Work in progress")]
        public void WrapDbDriver_Inject_does_not_throw_for_NH_300()
        {
            using (NHibernate.Version(NHibernateVersion.NH_300))
            {
                _sut.Inject();
            }
        }

        [Test, Ignore("Work in progress")]
        public void WrapDbDriver_Inject_does_not_throw_for_NH_212()
        {
            using (NHibernate.Version(NHibernateVersion.NH_212))
            {
                _sut.Inject();
            }
        }

        [Test, Ignore("Work in progress")]
        public void WrapDbDriver_Inject_does_not_throw_for_NH_210()
        {
            using (NHibernate.Version(NHibernateVersion.NH_210))
            {
                _sut.Inject();
            }
        }

        [Test, Ignore("Work in progress")]
        public void WrapDbDriver_Inject_does_not_throw_for_NH_201()
        {
            using (NHibernate.Version(NHibernateVersion.NH_201))
            {
                _sut.Inject();
            }
        }

        [Test, Ignore("Work in progress")]
        public void WrapDbDriver_Inject_does_not_throw_for_NH_121()
        {
            using (NHibernate.Version(NHibernateVersion.NH_121))
            {
                _sut.Inject();
            }
        }
    }
}