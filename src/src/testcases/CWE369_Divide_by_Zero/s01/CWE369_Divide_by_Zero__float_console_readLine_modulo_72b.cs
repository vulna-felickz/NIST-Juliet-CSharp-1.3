/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE369_Divide_by_Zero__float_console_readLine_modulo_72b.cs
Label Definition File: CWE369_Divide_by_Zero__float.label.xml
Template File: sources-sinks-72b.tmpl.cs
*/
/*
 * @description
 * CWE: 369 Divide by zero
 * BadSource: console_readLine Read data from the console using readLine
 * GoodSource: A hardcoded non-zero number (two)
 * Sinks: modulo
 *    GoodSink: Check for zero before modulo
 *    BadSink : Modulo by a value that may be zero
 * Flow Variant: 72 Data flow: data passed in a Hashtable from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;
using System.Collections;

using System.Web;

namespace testcases.CWE369_Divide_by_Zero
{
class CWE369_Divide_by_Zero__float_console_readLine_modulo_72b
{
#if (!OMITBAD)
    public static void BadSink(Hashtable dataHashtable )
    {
        float data = (float) dataHashtable[2];
        /* POTENTIAL FLAW: Possibly modulo by zero */
        int result = (int)(100.0 % data);
        IO.WriteLine(result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use GoodSource and BadSink */
    public static void GoodG2BSink(Hashtable dataHashtable )
    {
        float data = (float) dataHashtable[2];
        /* POTENTIAL FLAW: Possibly modulo by zero */
        int result = (int)(100.0 % data);
        IO.WriteLine(result);
    }

    /* goodB2G() - use BadSource and GoodSink */
    public static void GoodB2GSink(Hashtable dataHashtable )
    {
        float data = (float) dataHashtable[2];
        /* FIX: Check for value of or near zero before modulo */
        if (Math.Abs(data) > 0.000001)
        {
            int result = (int)(100.0 % data);
            IO.WriteLine(result);
        }
        else
        {
            IO.WriteLine("This would result in a modulo by zero");
        }
    }
#endif
}
}
