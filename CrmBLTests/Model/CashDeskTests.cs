using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            //Arrange
            var customer1 = new Customer()
            {
                Name = "testuser1",
                CustomerId = 1
            }; var customer2 = new Customer()
            {
                Name = "testuser2",
                CustomerId = 2
            };
            var seller = new Seller()
            {
                Name = "sellername",
                SellerId = 1
            };

            var produt1 = new Product()
            {
                ProductId = 1,
                Name = "pr1",
                Price = 100,
                Count = 10
            };
            var produt2 = new Product()
            {
                ProductId = 2,
                Name = "pr2",
                Price = 200,
                Count = 20
            };
            var cart1 = new Cart(customer1);

            cart1.Add(produt1);
            cart1.Add(produt1);
            cart1.Add(produt2);

            var cart2 = new Cart(customer2);
            cart2.Add(produt1);
            cart2.Add(produt2);
            cart2.Add(produt2);

            var cashdesk = new CashDesk(1, seller);

            cashdesk.MaxQueueLenght = 10;

            cashdesk.Enqueue(cart1);
            cashdesk.Enqueue(cart2);

            var cart1ExpectedResult = 400;
            var cart2ExpectedResult = 500;

            //Act

            var cart1ActualResult = cashdesk.Dequeue();
            var cart2ActualResult = cashdesk.Dequeue();


            //Assert

            Assert.AreEqual(cart1ExpectedResult, cart1ActualResult);
            Assert.AreEqual(cart2ExpectedResult, cart2ActualResult);
            Assert.AreEqual(7, produt1.Count);
            Assert.AreEqual(17, produt2.Count);

        }
    }
}