/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__Environment_write_12.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-12.tmpl.cs
*/
/*
* @description
* CWE: 400 Uncontrolled Resource Consumption
* BadSource: Environment Read count from an environment variable
* GoodSource: A hardcoded non-zero, non-min, non-max, even number
* Sinks: write
*    GoodSink: Write to a file count number of times, but first validate count
*    BadSink : Write to a file count number of times
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.IO;

using System.Web;

namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__Environment_write_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int count;
        if(IO.StaticReturnsTrueOrFalse())
        {
            count = int.MinValue; /* Initialize count */
            /* get environment variable ADD */
            /* POTENTIAL FLAW: Read count from an environment variable */
            {
                string stringNumber = Environment.GetEnvironmentVariable("ADD");
                if (stringNumber != null) // avoid NPD incidental warnings
                {
                    try
                    {
                        count = int.Parse(stringNumber.Trim());
                    }
                    catch (FormatException exceptNumberFormat)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing count from string");
                    }
                }
            }
        }
        else
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            count = 2;
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            int i;
            using (StreamWriter file = new StreamWriter(@"badSink.txt"))
            {
                /* POTENTIAL FLAW: Do not validate count before using it as the for loop variant to write to a file */
                for (i = 0; i < count; i++)
                {
                    try
                    {
                        file.Write("Hello");
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream writing", exceptIO);
                    }
                }
                /* Close stream reading objects */
                try
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Stream Writer", exceptIO);
                }
            }
        }
        else
        {
            /* FIX: Validate count before using it as the for loop variant to write to a file */
            if (count > 0 && count <= 20)
            {
                int i;
                using (StreamWriter file = new StreamWriter(@"badSink.txt"))
                {
                    /* POTENTIAL FLAW: Do not validate count before using it as the for loop variant to write to a file */
                    for (i = 0; i < count; i++)
                    {
                        try
                        {
                            file.Write("Hello");
                        }
                        catch (IOException exceptIO)
                        {
                            IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream writing", exceptIO);
                        }
                    }
                    /* Close stream reading objects */
                    try
                    {
                        if (file != null)
                        {
                            file.Close();
                        }
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Stream Writer", exceptIO);
                    }
                }
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink by changing the first "if" so that
     * both branches use the GoodSource */
    private void GoodG2B()
    {
        int count;
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            count = 2;
        }
        else
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            count = 2;
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            int i;
            using (StreamWriter file = new StreamWriter(@"badSink.txt"))
            {
                /* POTENTIAL FLAW: Do not validate count before using it as the for loop variant to write to a file */
                for (i = 0; i < count; i++)
                {
                    try
                    {
                        file.Write("Hello");
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream writing", exceptIO);
                    }
                }
                /* Close stream reading objects */
                try
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Stream Writer", exceptIO);
                }
            }
        }
        else
        {
            int i;
            using (StreamWriter file = new StreamWriter(@"badSink.txt"))
            {
                /* POTENTIAL FLAW: Do not validate count before using it as the for loop variant to write to a file */
                for (i = 0; i < count; i++)
                {
                    try
                    {
                        file.Write("Hello");
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream writing", exceptIO);
                    }
                }
                /* Close stream reading objects */
                try
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Stream Writer", exceptIO);
                }
            }
        }
    }

    /* goodB2G() - use badsource and goodsink by changing the second "if" so that
     * both branches use the GoodSink */
    private void GoodB2G()
    {
        int count;
        if(IO.StaticReturnsTrueOrFalse())
        {
            count = int.MinValue; /* Initialize count */
            /* get environment variable ADD */
            /* POTENTIAL FLAW: Read count from an environment variable */
            {
                string stringNumber = Environment.GetEnvironmentVariable("ADD");
                if (stringNumber != null) // avoid NPD incidental warnings
                {
                    try
                    {
                        count = int.Parse(stringNumber.Trim());
                    }
                    catch (FormatException exceptNumberFormat)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing count from string");
                    }
                }
            }
        }
        else
        {
            count = int.MinValue; /* Initialize count */
            /* get environment variable ADD */
            /* POTENTIAL FLAW: Read count from an environment variable */
            {
                string stringNumber = Environment.GetEnvironmentVariable("ADD");
                if (stringNumber != null) // avoid NPD incidental warnings
                {
                    try
                    {
                        count = int.Parse(stringNumber.Trim());
                    }
                    catch (FormatException exceptNumberFormat)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing count from string");
                    }
                }
            }
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: Validate count before using it as the for loop variant to write to a file */
            if (count > 0 && count <= 20)
            {
                int i;
                using (StreamWriter file = new StreamWriter(@"badSink.txt"))
                {
                    /* POTENTIAL FLAW: Do not validate count before using it as the for loop variant to write to a file */
                    for (i = 0; i < count; i++)
                    {
                        try
                        {
                            file.Write("Hello");
                        }
                        catch (IOException exceptIO)
                        {
                            IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream writing", exceptIO);
                        }
                    }
                    /* Close stream reading objects */
                    try
                    {
                        if (file != null)
                        {
                            file.Close();
                        }
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Stream Writer", exceptIO);
                    }
                }
            }
        }
        else
        {
            /* FIX: Validate count before using it as the for loop variant to write to a file */
            if (count > 0 && count <= 20)
            {
                int i;
                using (StreamWriter file = new StreamWriter(@"badSink.txt"))
                {
                    /* POTENTIAL FLAW: Do not validate count before using it as the for loop variant to write to a file */
                    for (i = 0; i < count; i++)
                    {
                        try
                        {
                            file.Write("Hello");
                        }
                        catch (IOException exceptIO)
                        {
                            IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream writing", exceptIO);
                        }
                    }
                    /* Close stream reading objects */
                    try
                    {
                        if (file != null)
                        {
                            file.Close();
                        }
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Stream Writer", exceptIO);
                    }
                }
            }
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
