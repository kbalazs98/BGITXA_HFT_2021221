using BGITXA_HFT_2021221.Logic;
using BGITXA_HFT_2021221.Models;
using BGITXA_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Test
{
    [TestFixture]
    class CRUDTests
    {
        ITelevisionLogic tvlogic;

        [SetUp]
        public void Setup()
        {
            Mock<ITelevisionRepository> tvmock =
              new Mock<ITelevisionRepository>();

            Brand brand1 = new Brand() { Id = 1, Name = "brand1" };
            Brand brand2 = new Brand() { Id = 2, Name = "brand2" };

            Order order1 = new Order() { Id = 1, CustomerName = " order1" };
            Order order2 = new Order() { Id = 2, CustomerName = " order2" };

            Television tv1 = new Television() { Id = 1, Price = 10, Model = "b1o1", Brand = brand1, Order = order1 };
            Television tv2 = new Television() { Id = 2, Price = 20, Model = "b1o2", Brand = brand1, Order = order2 };
            Television tv3 = new Television() { Id = 3, Price = 30, Model = "b2o1", Brand = brand2, Order = order1 };
            Television tv4 = new Television() { Id = 4, Price = 40, Model = "b2o2", Brand = brand2, Order = order2 };


            tvmock.Setup(x => x.ReadAll())
                .Returns(new List<Television> { tv1, tv2, tv3, tv4 }.AsQueryable());

            tvlogic = new TelevisionLogic(tvmock.Object);
        }
        [Test]
        public void SanityTest()
        {
            var moqlogic = tvlogic.ReadAll();
            Assert.NotNull(moqlogic);
        }
        [Test]
        public void TvCreateWithoutModel()
        {
            Assert.Throws<ArgumentNullException>(() => tvlogic.Create(new Television() { Id = 1, Price = 10, }));
        }
        [Test]
        public void TvUpdateWithoutModel()
        {
            Assert.Throws<ArgumentNullException>(() => tvlogic.Update(new Television() { Price = 10, }));
        }
        [Test]
        public void TvDeleteWithNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => tvlogic.Delete(-1));
        }
        [Test]
        public void TvCreateWithId()
        {
            Assert.DoesNotThrow( () => tvlogic.Create(new Television() { Id = 10, Model = "model", Price = 10 }) );
        }
        [Test]
        public void TvDeleteWihtPozitiveId()
        {
            Assert.DoesNotThrow(() => tvlogic.Delete(1));
        }
    }
}
