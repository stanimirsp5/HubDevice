using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Objects
{
    public abstract class Capability : ICapability
    {
        public void Create()
        {
            DoBuild();
        }

        //public virtual void DoBuild()
        //{
        //    Console.WriteLine("from Capability");
        //}
        public abstract void DoBuild();
    }
}
