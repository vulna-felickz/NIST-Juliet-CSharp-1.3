/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__SByte_console_readLine_square_45.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-45.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: console_readLine Read data from the console using readLine
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: square
 *    GoodSink: Ensure there will not be an overflow before squaring data
 *    BadSink : Square data, which can lead to overflow
 * Flow Variant: 45 Data flow: data passed as a private class member variable from one function to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

using System.IO;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__SByte_console_readLine_square_45 : AbstractTestCase
{

    private sbyte dataBad;
    private sbyte dataGoodG2B;
    private sbyte dataGoodB2G;
#if (!OMITBAD)
    private void BadSink()
    {
        sbyte data = dataBad;
        /* POTENTIAL FLAW: if (data*data) > sbyte.MaxValue, this will overflow */
        sbyte result = (sbyte)(data * data);
        IO.WriteLine("result: " + result);
    }

    public override void Bad()
    {
        sbyte data;
        /* init data */
        data = 0;
        /* POTENTIAL FLAW: Read data from console with ReadLine*/
        try
        {
            string stringNumber = Console.ReadLine();
            if (stringNumber != null)
            {
                data = sbyte.Parse(stringNumber.Trim());
            }
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
        }
        catch (FormatException exceptNumberFormat)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with number parsing", exceptNumberFormat);
        }
        dataBad = data;
        BadSink();
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    private void GoodG2BSink()
    {
        sbyte data = dataGoodG2B;
        /* POTENTIAL FLAW: if (data*data) > sbyte.MaxValue, this will overflow */
        sbyte result = (sbyte)(data * data);
        IO.WriteLine("result: " + result);
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        sbyte data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        dataGoodG2B = data;
        GoodG2BSink();
    }

    private void GoodB2GSink()
    {
        sbyte data = dataGoodB2G;
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

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        sbyte data;
        /* init data */
        data = 0;
        /* POTENTIAL FLAW: Read data from console with ReadLine*/
        try
        {
            string stringNumber = Console.ReadLine();
            if (stringNumber != null)
            {
                data = sbyte.Parse(stringNumber.Trim());
            }
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
        }
        catch (FormatException exceptNumberFormat)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with number parsing", exceptNumberFormat);
        }
        dataGoodB2G = data;
        GoodB2GSink();
    }
#endif //omitgood
}
}
