/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE470_Unsafe_Reflection__Web_Get_Cookies_Web_01.cs
Label Definition File: CWE470_Unsafe_Reflection__Web.label.xml
Template File: sources-sink-01.tmpl.cs
*/
/*
* @description
* CWE: 470 Use of Externally-Controlled Input to Select Classes or Code ('Unsafe Reflection')
* BadSource: Get_Cookies_Web Read data from the first cookie using Cookies
* GoodSource: Set data to a hardcoded class name
* BadSink:  Instantiate class named in data
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Web;


namespace testcases.CWE470_Unsafe_Reflection
{

class CWE470_Unsafe_Reflection__Web_Get_Cookies_Web_01 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        data = ""; /* initialize data in case there are no cookies */
        /* Read data from cookies */
        {
            HttpCookieCollection cookieSources = req.Cookies;
            if (cookieSources != null)
            {
                /* POTENTIAL FLAW: Read data from the first cookie value */
                data = cookieSources[0].Value;
            }
        }
        /* POTENTIAL FLAW: Instantiate object of class named in data (which may be from external input) */
        var container = Activator.CreateInstance(null, data);
        Object tempClassObj = container.Unwrap();
        IO.WriteLine(tempClassObj.GetType().ToString()); /* Use tempClassObj in some way */
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
    }

    /* goodG2B() - uses goodsource and badsink */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data;
        /* FIX: Use a hardcoded class name */
        data = "Testing.test";
        /* POTENTIAL FLAW: Instantiate object of class named in data (which may be from external input) */
        var container = Activator.CreateInstance(null, data);
        Object tempClassObj = container.Unwrap();
        IO.WriteLine(tempClassObj.GetType().ToString()); /* Use tempClassObj in some way */
    }
#endif //omitgood
}
}
