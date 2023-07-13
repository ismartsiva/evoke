using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentClassLib
{
    public delegate string GetCompanyNameDelegate();
    public class COmpanyDetails
    {
        public event GetCompanyNameDelegate MyEvent;
        public GetCompanyNameDelegate GetCompDel { get; set; }
        public string Caller()
        {
            MyEvent();
            return GetCompDel();
        }



    }
}