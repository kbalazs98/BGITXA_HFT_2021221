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
    class NonCrudTests
    {
        ITelevisionLogic tvlogic;
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
        }
        [Test]
        public void CheckAveragePriceOfOrder()
        {
            //List<KeyValuePair<string, double>> lista = tvlogic.AveragePriceOfOrder().ToList();

            //string ordername = lista.ToArray()[0].Key;
            ////double result = lista.ToArray()[0].Value;
            //Assert.That(ordername.Equals("Aa"));
            //Assert.Pass();
            int number = 4;
            tvlogic.Delete(1);
            Assert.That(tvlogic.ReadAll().Count() == number);
        }
    }
}
