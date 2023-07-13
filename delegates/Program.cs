// See https://aka.ms/new-console-template for more information
using ParentCodeLib;

Console.WriteLine("Hello, World!");
CompanyDetails companyDetails = new CompanyDetails();
//Console.WriteLine("My Product Name is Siva company");
companyDetails.GetComName = new GetCompanyNameDel(GetCliebtFun);

string comp = companyDetails.Caller();


Console.WriteLine(comp);


string GetCliebtFun()
{
    return "other company";
}