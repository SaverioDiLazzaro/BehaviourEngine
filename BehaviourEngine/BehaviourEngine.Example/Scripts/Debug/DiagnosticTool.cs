using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    public class DiagnosticTool : Behaviour, IUpdatable
    {
        void IUpdatable.Update()
        {
            Console.WriteLine(Time.DeltaTime);
        }
    }
}
