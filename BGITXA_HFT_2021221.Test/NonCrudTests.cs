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


        [SetUp]
        public void Setup()
        {
            Mock<ITelevisionRepository> tvmock =
              new Mock<ITelevisionRepository>();

            Brand brand1 = new Brand() { Id = 1, Name = "brand1" };
            Brand brand2 = new Brand() { Id = 2, Name = "brand2" };

            Order order1 = new Order() { Id = 1, CustomerName = "order1",Televisions = new List<Television>() };
            Order order2 = new Order() { Id = 2, CustomerName = "order2",Televisions = new List<Television>() };

            Television tv1 = new Television() { Id = 1, Price = 10, Model = "b1o1", Brand = brand1, Order = order1 };
            Television tv2 = new Television() { Id = 2, Price = 20, Model = "b1o2", Brand = brand1, Order = order2 };
            Television tv3 = new Television() { Id = 3, Price = 30, Model = "b2o1", Brand = brand2, Order = order1 };
            Television tv4 = new Television() { Id = 4, Price = 40, Model = "b2o2", Brand = brand2, Order = order2 };

            order1.Televisions.Add(tv1);
            order1.Televisions.Add(tv2);
            order2.Televisions.Add(tv3);
            order2.Televisions.Add(tv4);


            tvmock.Setup(x => x.ReadAll())
                .Returns(new List<Television>{tv1,tv2,tv3,tv4}.AsQueryable());

            tvlogic = new TelevisionLogic(tvmock.Object);
        }
        [Test]
        public void AveragePriceByBrand()
        {
            var brandsandprices = tvlogic.AveragePriceOfBrand().ToList();
            Assert.That(brandsandprices[0].Value == 15 && brandsandprices[1].Value == 35);
        }
        [Test]
        public void CountTvByOrder()
        {
            var asd = tvlogic.CountTvByOrder().ToList();
            Assert.That(asd.ToArray()[0].Value == 2);
        }
        [Test]
        public void AveragePriceOfOrder()
        {
            var ordersandprices = tvlogic.AveragePriceOfOrder().ToList();
            Assert.That(ordersandprices[0].Key == "order1" && ordersandprices[0].Value == 20);

        }
        [Test]
        public void OrdersInOrderByPrice()
        {
            var ordersinorderbyprice = tvlogic.OrdersInOrderByPrice().ToList();
            Assert.That(ordersinorderbyprice.ToArray()[0].CustomerName == "order1" && ordersinorderbyprice.ToArray()[1].CustomerName=="order2");
        }
        [Test]
        public void CheapestTvOTheBrand()
        {
            var cheaptv = tvlogic.CheapestTvOfTheBrand(2);
            Assert.That(cheaptv.Model.Equals("b2o1"));
        }
    }
}
