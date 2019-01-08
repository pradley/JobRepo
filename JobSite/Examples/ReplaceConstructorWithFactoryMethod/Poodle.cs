using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace JobSite.Examples.ReplaceConstructorWithFactoryMethod
{
    public class Poodle:Dog
    {

        public Poodle() { }


        public override void Bark() => Debug.WriteLine("Bark bark I am a Poodle");

    
    }
}