/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__UInt16_rand_sub_42.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-42.tmpl.cs
*/
/*
 * @description
 * CWE: 191 Integer Underflow
 * BadSource: rand Set data to result of rand()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: sub
 *    GoodSink: Ensure there will not be an underflow before subtracting 1 from data
 *    BadSink : Subtract 1 from data, which can cause an Underflow
 * Flow Variant: 42 Data flow: data returned from one method to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__UInt16_rand_sub_42 : AbstractTestCase
{
#if (!OMITBAD)
    private static ushort BadSource()
    {
        ushort data;
        /* POTENTIAL FLAW: Use a random value */
        data = (ushort)(new Random().Next(ushort.MinValue, ushort.MaxValue));
        return data;
    }

    public override void Bad()
    {
        ushort data = BadSource();
        /* POTENTIAL FLAW: if data == ushort.MinValue, this will overflow */
        ushort result = (ushort)(data - 1);
        IO.WriteLine("result: " + result);
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private static ushort GoodG2BSource()
    {
        ushort data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        return data;
    }

    private static void GoodG2B()
    {
        ushort data = GoodG2BSource();
        /* POTENTIAL FLAW: if data == ushort.MinValue, this will overflow */
        ushort result = (ushort)(data - 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    private static ushort GoodB2GSource()
    {
        ushort data;
        /* POTENTIAL FLAW: Use a random value */
        data = (ushort)(new Random().Next(ushort.MinValue, ushort.MaxValue));
        return data;
    }

    private static void GoodB2G()
    {
        ushort data = GoodB2GSource();
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data > ushort.MinValue)
        {
            ushort result = (ushort)(data - 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too small to perform subtraction.");
        }
    }

    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }
#endif //omitgood
}
}
