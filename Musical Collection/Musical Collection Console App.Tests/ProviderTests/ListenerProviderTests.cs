using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Tests.ProviderTests
{
    internal class ListenerProviderTests
    {
        ListenerProvider listenerProvider;
        Listener listener;

        [SetUp]
        public void SetUp()
        {
            listener = new Listener("Ivancho1", "Ivancho1", "Ivan Ivanov", "10.10.2000");
            listenerProvider = new ListenerProvider();
        }
    }
}
