using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Devart.Data.Linq;
using ErpContext;
using System.Reflection;

namespace ERP
{
    static class Globals
    {
        #region ObtainDataTableFromIEnumerable
        public static DataTable ObtainDataTableFromIEnumerable(System.Collections.IEnumerable ien)
        {
            try
            {
                DataTable dt = new DataTable();

                foreach (object obj in ien)
                {


                    Type t = obj.GetType();

                    PropertyInfo[] pis = t.GetProperties();

                    if (dt.Columns.Count == 0)

                    {

                        foreach (PropertyInfo pi in pis)
                        {
                            dt.Columns.Add(pi.Name, pi.PropertyType);
                        }
                    }

                    DataRow dr = dt.NewRow();

                    foreach (PropertyInfo pi in pis)
                    {
                        object value = pi.GetValue(obj, null);

                        dr[pi.Name] = value;
                    }

                    dt.Rows.Add(dr);

                }

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}