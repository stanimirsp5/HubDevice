using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Objects
{
    internal class House : Capability
    {
        // TODO call by background task
        public House()
        {
            Create();
        }

        public override void DoBuild()
        {
            Console.WriteLine("House build");
        }
    }
}
