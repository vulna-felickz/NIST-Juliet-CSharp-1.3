/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__empty_while_10.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-10.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: empty_while
*    GoodSink: While statement contains code
*    BadSink : An empty while statement has no effect
* Flow Variant: 10 Control flow: if(IO.staticTrue) and if(IO.staticFalse)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__empty_while_10 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.staticTrue)
        {
            int i = 0;
            /* FLAW: An empty while statement has no effect */
            while(i++ < 10)
            {
            }
            IO.WriteLine("Hello from Bad()");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* good1() changes IO.staticTrue to IO.staticFalse */
    private void Good1()
    {
        if (IO.staticFalse)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            int i = 0;
            /* FIX: Do not include an empty while statement */
            while(i++ < 10)
            {
                IO.WriteLine("Inside the while statement");
            }
            IO.WriteLine("Hello from Good()");
        }
    }

    /* good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.staticTrue)
        {
            int i = 0;
            /* FIX: Do not include an empty while statement */
            while(i++ < 10)
            {
                IO.WriteLine("Inside the while statement");
            }
            IO.WriteLine("Hello from Good()");
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
