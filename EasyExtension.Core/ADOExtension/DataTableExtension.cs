using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace EasyExtension.Data
{
    public static class DataTableExtension
    {
        public static List<T> ToList<T>(this DataTable dataTable) where T :new()
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return new List<T>();
            }
            List<T> list = new List<T>();
            DataColumnCollection columns = dataTable.Columns;
            foreach (DataRow dr in dataTable.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    string name = pi.Name;
                    if (columns.Contains(name))
                    {
                        if (!pi.CanWrite) continue;

                        object value = dr[name];
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                list.Add(t);
            }
            return list;
        }
        public static T ToEntity<T>(this DataTable dataTable) where T : new()
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return default(T);
            }
            T t = new T();
            DataRow dr = dataTable.Rows[0];
            DataColumnCollection columns = dataTable.Columns;
            PropertyInfo[] propertys = t.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                string name = pi.Name;
                if (columns.Contains(name))
                {
                    if (!pi.CanWrite) continue;

                    object value = dr[name];
                    if (value != DBNull.Value)
                    {
                        pi.SetValue(t, value, null);
                    }
                }
            }
            return t;
        }
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            var dataTable = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = typeof(T).GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    dataTable.Columns.Add(pi.Name, pi.PropertyType);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dataTable.LoadDataRow(array, true);
                }
            }
            return dataTable;

        }
        public static DataTable ToDataTableEx<T>(this List<T> list)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] propertys = typeof(T).GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                if (!pi.CanRead) continue;
                dt.Columns.Add(pi.Name, pi.PropertyType);
            }
            foreach (T item in list)
            {
                propertys = item.GetType().GetProperties();
                DataRow newRow = dt.NewRow();
                foreach (PropertyInfo pi in propertys)
                {
                    if (!pi.CanRead) continue;
                    newRow[pi.Name] = pi.GetValue(item,null);
                }
                dt.Rows.Add(newRow);
            }
            return dt;
        }
    }
}
