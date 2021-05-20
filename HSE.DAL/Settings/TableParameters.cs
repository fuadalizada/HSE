using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace HSE.DAL.Settings
{
    public static class TableParameters
    {
        public static void AddWithValue_Tvp_Int(this SqlParameterCollection paramCollection, string parameterName, List<int> data)
        {
            if (paramCollection != null)
            {
                SqlParameter p = paramCollection.Add(parameterName, SqlDbType.Structured);
                p.TypeName = "dbo.tvp_int";
                DataTable _dt = new DataTable() { Columns = { "Value" } };
                data?.ForEach(value => _dt.Rows.Add(value));
                p.Value = _dt;
            }
        }

        public static void AddWithValue_Tvp_Nvarchar(this SqlParameterCollection paramCollection, string parameterName, List<string> data)
        {
            if (paramCollection != null)
            {
                SqlParameter p = paramCollection.Add(parameterName, SqlDbType.Structured);
                p.TypeName = "dbo.tvp_nvarchar";
                DataTable _dt = new DataTable() { Columns = { "Value" } };
                data?.ForEach(value => _dt.Rows.Add(value));
                p.Value = _dt;
            }
        }

        public static void AddWithValue_Tvp_Bit(this SqlParameterCollection paramCollection, string parameterName, List<bool> data)
        {
            if (paramCollection != null)
            {
                SqlParameter p = paramCollection.Add(parameterName, SqlDbType.Structured);
                p.TypeName = "dbo.tvp_bit";
                DataTable _dt = new DataTable() { Columns = { "Value" } };
                data?.ForEach(value => _dt.Rows.Add(value));
                p.Value = _dt;
            }
        }
    }
}
