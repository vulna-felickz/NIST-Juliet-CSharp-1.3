/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE566_Authorization_Bypass_Through_SQL_Primary__Web_68b.cs
Label Definition File: CWE566_Authorization_Bypass_Through_SQL_Primary__Web.label.xml
Template File: sources-sink-68b.tmpl.cs
*/
/*
 * @description
 * CWE: 566 Authorization Bypass through SQL primary
 * BadSource:  user id taken from url parameter
 * GoodSource: hardcoded user id
 * BadSink: writeConsole user authorization not checked
 * Flow Variant: 68 Data flow: data passed as a member variable in the "a" class, which is used by a method in another class in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Data;

using System.Web;

namespace testcases.CWE566_Authorization_Bypass_Through_SQL_Primary
{
class CWE566_Authorization_Bypass_Through_SQL_Primary__Web_68b
{
#if (!OMITBAD)
    public static void BadSink(HttpRequest req, HttpResponse resp)
    {
        string data = CWE566_Authorization_Bypass_Through_SQL_Primary__Web_68a.data;
        SqlConnection dBConnection = IO.GetDBConnection();
        SqlCommand preparedStatement = null;
        int id = 0;
        try
        {
            id = int.Parse(data);
        }
        catch (FormatException nfx)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, nfx, "Could not parse int, setting to -1");
            id = -1; /* Assuming this id does not exist */
        }
        try
        {
            dBConnection.Open();
            using (preparedStatement = new SqlCommand(null, dBConnection))
            {
                preparedStatement.CommandText = "select * from invoices where uid=@id";
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 0);
                idParam.Value = id;
                preparedStatement.ExecuteNonQuery();
            }
            /* POTENTIAL FLAW: no check to see whether the user has privileges to view the data */
            IO.WriteString("Bad() - result requested: " + data + "\n");
        }
        catch (SqlException exceptSql)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error executing query");
        }
        finally
        {
            try
            {
                if (dBConnection != null)
                {
                    dBConnection.Close();
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Could not close Connection");
            }
        }
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(HttpRequest req, HttpResponse resp)
    {
        string data = CWE566_Authorization_Bypass_Through_SQL_Primary__Web_68a.data;
        SqlConnection dBConnection = IO.GetDBConnection();
        SqlCommand preparedStatement = null;
        int id = 0;
        try
        {
            id = int.Parse(data);
        }
        catch (FormatException nfx)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, nfx, "Could not parse int, setting to -1");
            id = -1; /* Assuming this id does not exist */
        }
        try
        {
            dBConnection.Open();
            using (preparedStatement = new SqlCommand(null, dBConnection))
            {
                preparedStatement.CommandText = "select * from invoices where uid=@id";
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 0);
                idParam.Value = id;
                preparedStatement.ExecuteNonQuery();
            }
            /* POTENTIAL FLAW: no check to see whether the user has privileges to view the data */
            IO.WriteString("Bad() - result requested: " + data + "\n");
        }
        catch (SqlException exceptSql)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error executing query");
        }
        finally
        {
            try
            {
                if (dBConnection != null)
                {
                    dBConnection.Close();
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Could not close Connection");
            }
        }
    }
#endif
}
}
