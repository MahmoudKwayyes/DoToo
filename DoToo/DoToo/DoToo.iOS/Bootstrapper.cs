using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoToo.iOS
{
    class Bootstrapper:DoToo.Bootstrapper
    {
        public static void Init()
        {
            var instance = new Bootstrapper();
        }
    }
}