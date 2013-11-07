using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraCopy
{
    public class Application
    {
        public static string LocalPath
        {
            get
            {
                return System.Windows.Forms.Application.LocalUserAppDataPath;
            }
        }
    }
}
