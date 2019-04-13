using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safety_Net
{
    class PI
    {
        private string varName;
        private string varInfo;
        public PI(string name, string info)
        {
            varName = name;
            varInfo = info;
        }
        public string getVarName()
        {
            return varName;
        }
        public string getVarInfo()
        {
            return varInfo;
        }
      
    }
}
