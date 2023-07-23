using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EazyChain.Tests
{
    [TestClass]
    public class ChainRequestTests
    {
        [TestMethod]
        public void Faulted_HasCorrectProperties()
        {
            var request = new TestRequest();

            request.Faulted();

            Assert.IsTrue(request.IsFaulted);
            Assert.IsNull(request.Exception);
        }

        [TestMethod]
        public void Faulted_WithException_HasCorrectProperties()
        {
            var request = new TestRequest();
            var exception = new NullReferenceException();

            request.Faulted(exception);

            Assert.IsTrue(request.IsFaulted);
            Assert.AreEqual(exception, request.Exception);
        }
    }
}
