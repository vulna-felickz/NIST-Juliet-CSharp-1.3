/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__int_Database_add_42.cs
Label Definition File: CWE190_Integer_Overflow__int.label.xml
Template File: sources-sinks-42.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: Database Read data from a database
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: add
 *    GoodSink: Ensure there will not be an overflow before adding 1 to data
 *    BadSink : Add 1 to data, which can cause an overflow
 * Flow Variant: 42 Data flow: data returned from one method to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

using System.Data.SqlClient;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__int_Database_add_42 : AbstractTestCase
{
#if (!OMITBAD)
    private static int BadSource()
    {
        int data;
        data = int.MinValue; /* Initialize data */
        /* Read data from a database */
        {
            try
            {
                /* setup the connection */
                using (SqlConnection connection = IO.GetDBConnection())
                {
                    connection.Open();
                    /* prepare and execute a (hardcoded) query */
                    using (SqlCommand command = new SqlCommand(null, connection))
                    {
                        command.CommandText = "select name from users where id=0";
                        command.Prepare();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            /* POTENTIAL FLAW: Read data from a database query SqlDataReader */
                            string stringNumber = dr.GetString(1);
                            if (stringNumber != null) /* avoid NPD incidental warnings */
                            {
                                try
                                {
                                    data = int.Parse(stringNumber.Trim());
                                }
                                catch (FormatException exceptNumberFormat)
                                {
                                    IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing data from string");
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error with SQL statement");
            }
        }
        return data;
    }

    public override void Bad()
    {
        int data = BadSource();
        /* POTENTIAL FLAW: if data == int.MaxValue, this will overflow */
        int result = (int)(data + 1);
        IO.WriteLine("result: " + result);
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private static int GoodG2BSource()
    {
        int data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        return data;
    }

    private static void GoodG2B()
    {
        int data = GoodG2BSource();
        /* POTENTIAL FLAW: if data == int.MaxValue, this will overflow */
        int result = (int)(data + 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    private static int GoodB2GSource()
    {
        int data;
        data = int.MinValue; /* Initialize data */
        /* Read data from a database */
        {
            try
            {
                /* setup the connection */
                using (SqlConnection connection = IO.GetDBConnection())
                {
                    connection.Open();
                    /* prepare and execute a (hardcoded) query */
                    using (SqlCommand command = new SqlCommand(null, connection))
                    {
                        command.CommandText = "select name from users where id=0";
                        command.Prepare();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            /* POTENTIAL FLAW: Read data from a database query SqlDataReader */
                            string stringNumber = dr.GetString(1);
                            if (stringNumber != null) /* avoid NPD incidental warnings */
                            {
                                try
                                {
                                    data = int.Parse(stringNumber.Trim());
                                }
                                catch (FormatException exceptNumberFormat)
                                {
                                    IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing data from string");
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error with SQL statement");
            }
        }
        return data;
    }

    private static void GoodB2G()
    {
        int data = GoodB2GSource();
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data < int.MaxValue)
        {
            int result = (int)(data + 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too large to perform addition.");
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
