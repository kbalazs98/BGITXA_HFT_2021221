using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BGITXA_HFT_2021221.Data;
using BGITXA_HFT_2021221.Logic;
using BGITXA_HFT_2021221.Models;
using BGITXA_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;

namespace BGITXA_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(5000);
            RestService rest = new RestService("http://localhost:9910");

            //television
            var alltv = rest.Get<Television>("/televisions");//GET all tv
            var tvid10 = rest.Get<Television>(10,"/televisions"); //GET one tv
            rest.Post(new Television() { BrandId = 1, Model = "ujsamsungtvmutherfucker", Price = 10, OrderId = 2 },"/televisions"); //CREATE tv
            rest.Put(new Television() { Id = 10, BrandId = 3, Model = "sony", Price = 69696,OrderId=1 },"/televisions");//UPDATE tv with the given ID
            rest.Delete(32, "/televisions");//DELETE id 32
            var newtvs= rest.Get<Television>("/televisions");

            var result2 = rest.Get<Brand>("/brands");
            var result3 = rest.Get<Order>("/orders");
            var res4 = rest.Get<Television> (1,"/noncrud/CheapestTvOfTheBrand");
            ;
        }
    }
}
