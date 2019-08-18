using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinjaTests
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            Mock<IStorage> storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);

            var order = new Order();
            service.PlaceOrder(order);

            storage.Verify(s => s.Store(order));
        }
    }
}
