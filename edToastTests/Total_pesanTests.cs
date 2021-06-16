using Microsoft.VisualStudio.TestTools.UnitTesting;
using edToast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edToast.Tests
{
    [TestClass()]
    public class Total_pesanTests
    {
        [TestMethod()]
        public void totalTest()
        {
            double expected = 63000;
            int pesan1 = 1;
            int pesan2 = 0;
            int pesan3 = 1;
            int pesan4 = 1;

            double actual = edToast.Total_pesan.total(pesan1, pesan2, pesan3, pesan4);
            Assert.AreEqual(expected, actual);
        }
    }
}