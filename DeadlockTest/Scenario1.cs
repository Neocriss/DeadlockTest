using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DeadlockTest
{
    public static class Scenario1
    {
        #region :: ~ Internal types ~ ::

        private class DeadlockTester
        {
            #region :: ~ Internal objects ~ ::

            private object o;   // <-- null
            private volatile uint number = 0;

            #endregion :: ^ Internal objects ^ ::

            //      ---     ---     ---     ---     ---

            #region :: ~ Methods ~ ::

            public void A()
            {
                lock (this.o)
                {
                    this.B(true);
                }
            }


            public void B(bool isA = false)
            {
                lock (this.o)
                {
                    Console.WriteLine("{0:D3}: To be or not to be. It's {1}.", ++this.number, isA ? "[A]" : "[B]");
                }
            }

            #endregion :: ^ Methods ^ ::
        }

        #endregion :: ^ Internal types ^ ::

        //      ---     ---     ---     ---     ---

        #region :: ~ Internal objects ~ ::

        private const ulong IterationCount = 140;

        #endregion :: ^ Internal objects ^ ::

        //      ---     ---     ---     ---     ---

        #region :: ~ Methods ~ ::

        public static void Run()
        {
            DeadlockTester dTester = new DeadlockTester();


            Thread thread = new Thread(() =>
            {
                for (ulong i = 0; i < Scenario1.IterationCount; i++)
                {
                    dTester.A();
                }
            });

            thread.Start();


            for (ulong i = 0; i < Scenario1.IterationCount; i++)
            {
                dTester.B();
            }
        }

        #endregion :: ^ Methods ^ ::
    }
}
