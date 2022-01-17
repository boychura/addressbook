using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class SearchTest : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            Console.WriteLine(app.Contact.GetNumberOfSearchResults());
        }
    }
}
