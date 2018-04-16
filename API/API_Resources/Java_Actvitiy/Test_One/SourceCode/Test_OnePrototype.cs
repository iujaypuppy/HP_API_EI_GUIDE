using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HP.ST.Fwk.DesignerModel;
using System.Runtime.Serialization;

namespace Test_OneProject
{
    [DataContract]
    public class Test_OnePrototype : DefaultActivity
    {
        public override CanBeInvokedResult CanBeInvoked
        {
            get
            {
                return new CanBeInvokedResult("Running Java steps is not supported.") { CanBeInvoked = false, IsUIEnabled = false };
            }
        }
    }
}
