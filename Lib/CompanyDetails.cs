using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentCodeLib
{
    public delegate string GetCompanyNameDel();
    public class CompanyDetails
    {
        public GetCompanyNameDel GetComName { get; set; }
        public string Caller()
        {
            return GetComName();
        }
        //public string GetCompanyName()
        //{
        //    return "siva comapany";
        //}
    }
}
