/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__SByte_max_square_61a.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-61a.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: max Set data to the max value for sbyte
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: square
 *    GoodSink: Ensure there will not be an overflow before squaring data
 *    BadSink : Square data, which can lead to overflow
 * Flow Variant: 61 Data flow: data returned from one method to another in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__SByte_max_square_61a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        sbyte data = CWE190_Integer_Overflow__SByte_max_square_61b.BadSource();
        /* POTENTIAL FLAW: if (data*data) > sbyte.MaxValue, this will overflow */
        sbyte result = (sbyte)(data * data);
        IO.WriteLine("result: " + result);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        sbyte data = CWE190_Integer_Overflow__SByte_max_square_61b.GoodG2BSource();
        /* POTENTIAL FLAW: if (data*data) > sbyte.MaxValue, this will overflow */
        sbyte result = (sbyte)(data * data);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G()
    {
        sbyte data = CWE190_Integer_Overflow__SByte_max_square_61b.GoodB2GSource();
        /* FIX: Add a check to prevent an overflow from occurring */
        if (Math.Abs((long)data) <= (long)Math.Sqrt(sbyte.MaxValue))
        {
            sbyte result = (sbyte)(data * data);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too large to perform squaring.");
        }
    }
#endif //omitgood
}
}
