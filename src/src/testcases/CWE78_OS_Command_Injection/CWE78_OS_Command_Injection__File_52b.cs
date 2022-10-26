/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE78_OS_Command_Injection__File_52b.cs
Label Definition File: CWE78_OS_Command_Injection.label.xml
Template File: sources-sink-52b.tmpl.cs
*/
/*
 * @description
 * CWE: 78 OS Command Injection
 * BadSource: File Read data from file (named data.txt)
 * GoodSource: A hardcoded string
 * Sinks: exec
 *    BadSink : dynamic command execution with Runtime.getRuntime().exec()
 * Flow Variant: 52 Data flow: data passed as an argument from one method to another to another in three different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE78_OS_Command_Injection
{
class CWE78_OS_Command_Injection__File_52b
{
#if (!OMITBAD)
    public static void BadSink(string data )
    {
        CWE78_OS_Command_Injection__File_52c.BadSink(data );
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string data )
    {
        CWE78_OS_Command_Injection__File_52c.GoodG2BSink(data );
    }
#endif
}
}
