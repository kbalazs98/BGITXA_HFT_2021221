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
        ITelevisionRepository tvrepo;
        //IOrderLogic orderlogic;
        //IBrandLogic brandlogic;

        [SetUp]
        public void Setup()
        {
            Mock<ITelevisionRepository> tvmock =
              new Mock<ITelevisionRepository>();

            Brand b1 = new Brand() { Id = 1, Name = "elso" };
            Brand b2 = new Brand() { Id = 2, Name = "masodik" };

            Order o1 = new Order() { Id = 1, CustomerName = " AA" };
            Order o2 = new Order() { Id = 2, CustomerName = " BB" };

            tvmock.Setup(x => x.ReadAll())
                .Returns(new List<Television>
                {   new Television(){Id = 1,Price = 10,OrderId = 1},
                    new Television(){Id = 2,Price = 20,OrderId = 1},
                    new Television(){Id = 3,Price = 30,OrderId = 2},
                    new Television(){Id = 4,Price = 40,OrderId = 2},
                }.AsQueryable());

            tvlogic = new TelevisionLogic(tvmock.Object);
            tvrepo = tvmock.Object;
        }
        [Test]
        public void TVLogicCreate()
        {
            int numberoftvsbeforecreate = tvlogic.ReadAll().Count();
            Television newtw = new Television() { Id = 5, Price = 50, OrderId = 2 };
            tvlogic.Create(newtw);
            int numberoftvsaftercreate = tvlogic.ReadAll().Count();
            Assert.That(numberoftvsbeforecreate == numberoftvsaftercreate);
        }
        [Test]
        public void TVRepoCreate()
        {
            //it can create any type of tv

            int numberoftvsbeforecreate = tvrepo.ReadAll().Count();
            Television newtw = new Television() { Id = 5, Price = 50, OrderId = 2 };
            tvrepo.Create(newtw);
            int numberoftvsaftercreate = tvrepo.ReadAll().Count();
            Assert.That(numberoftvsbeforecreate == numberoftvsaftercreate);
        }
        [Test]
        public void TVLogicCreateWithException()
        {
            //throws exception 
            Television newtw = new Television() { Id = 5, Price = 50, OrderId = 2 };
            Assert.Throws<Exception>(() => tvlogic.Create(newtw));
        }
        [Test]
        public void TvLogicDelete()
        {
            int numberoftvsbeforedelete = tvlogic.ReadAll().Count();
            tvlogic.Delete(2);
            int numberoftvsafterdelete = tvlogic.ReadAll().Count();
            Assert.AreEqual(numberoftvsafterdelete, numberoftvsbeforedelete);
        }
        [Test]
        public void TvLogicUpdate()
        {
            Television newtv = new Television() { Id = 4, Price = 100, OrderId = 2 };
            tvlogic.Update(newtv);
            Television tvinrepo = tvlogic.ReadAll().Where(x=> x.Id == 3).FirstOrDefault();
            Assert.That(tvinrepo.Price == newtv.Price);
        }
    }
}
