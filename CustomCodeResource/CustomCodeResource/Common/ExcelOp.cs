using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using ExcelNameSpace = Microsoft.Office.Interop.Excel;
namespace CustomCode
{
    public class ExcelOp
    {
        /// <summary>
        /// 从指定的EXCEL文件中获得对应的对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> PraseFromFile<T>(string strFileName) where T:new()
        {
            if (string.IsNullOrEmpty(strFileName))
            {
                return null;
            }

            if (!File.Exists(strFileName))
            {
                return null;
            }

            IList<T> result = new List<T>();


            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();


            object missing = System.Reflection.Missing.Value;
            ExcelNameSpace.Application excel = new ExcelNameSpace.Application();//lauch excel application  

            // 以只读的形式打开EXCEL文件  
            ExcelNameSpace.Workbook wb = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
             missing, missing, missing, true, missing, missing, missing, missing, missing);


            //取得第一个工作薄  
            ExcelNameSpace.Worksheet ws = (ExcelNameSpace.Worksheet)wb.Worksheets.get_Item(1);

            //取得总记录行数    (包括标题列)  
            int rowsint = ws.UsedRange.Cells.Rows.Count; //得到行数  


            for (int irow = 1; irow < rowsint - 1; irow++)
            {
                T evalue = new T();
                foreach (PropertyInfo property in properties)
                {
                    ExportAttribute attribute = property.GetCustomAttribute<ExportAttribute>();
                    if (attribute != null)
                    {
                        if (attribute.IsIgnor)
                        {
                            continue;
                        }
                    }

                    try
                    {
                        ExcelNameSpace.Range range = ws.Range[property.Name];
                        if (range != null)
                        {
                            string strValue = range.Offset[irow, 0].Text;
                            var vValue = range.Offset[irow, 0].Value2;

                            if (property.PropertyType == typeof(System.DayOfWeek))
                            {
                                DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), strValue);
                                property.SetValue(evalue, day, null);
                            }
                            else if (property.PropertyType == typeof(DateTime))
                            {
                                DateTime edate = DateTime.Now;
                                if (DateTime.TryParse(strValue, out edate))
                                {
                                    property.SetValue(evalue, edate, null);
                                   
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (property.PropertyType == typeof(string))
                                    {
                                        property.SetValue(evalue, strValue);
                                    }
                                    else
                                    {
                                        property.SetValue(evalue, vValue, null);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    if (property.PropertyType == typeof(int))
                                    {
                                        int targetvalue = 0;
                                        if (int.TryParse(strValue, out targetvalue))
                                        {
                                            property.SetValue(evalue, targetvalue, null);
                                        }
                                        else
                                        {
                                            //数据类型不符
                                            Trace.WriteLine(ex.Message + "," + property.Name + "," + strValue);
                                        }
                                    }
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        //这是不存在对应的名称定义
                        Trace.WriteLine(ex.Message + "," + property.Name);
                    }
                }
                result.Add(evalue);
            }
            wb.Close();
            excel.Quit();
            return result;
        }

        /// <summary>
        /// 将集合数据导出到excel文件中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="children"></param>
        /// <returns></returns>
        public static bool ExportToExcel<T>(IList<T> children,string fileName)
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            var excelApp = new ExcelNameSpace.Application();

            excelApp.Visible = false;

            ExcelNameSpace.Workbook excelWorkBook = excelApp.Workbooks.Add();

            ExcelNameSpace._Worksheet newshit = excelWorkBook.Worksheets.Add();

            //创建表头
            int colindex = 1;

            

            // 以只读的形式打开EXCEL文件  
            foreach (PropertyInfo property in properties)
            {
                ExportAttribute attribute = property.GetCustomAttribute<ExportAttribute>();
                if (!attribute.IsIgnor)
                {
                    try
                    {
                        newshit.Cells[1, colindex].Name = property.Name;
                        newshit.Cells[1, colindex].Value2 = attribute.Description;
                        if (attribute.IsCollapsed)
                        {
                            newshit.Columns[colindex].Hidden = true;
                        }
                        colindex++;
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.Message);
                    }
                }
            }

            if (children != null && children.Count>0)
            {
                foreach (PropertyInfo property in properties)
                {
                    ExportAttribute attribute = property.GetCustomAttribute<ExportAttribute>();
                    for (int i = 1; i < children.Count + 1; i++)
                    {
                        if (!attribute.IsIgnor)
                        {
                            newshit.Range[property.Name].Offset[i, 0].Value = "'" + property.GetValue(children[i - 1]).ToString();
                        }
                    }
                }
            }
            excelWorkBook.SaveAs(fileName);
            excelWorkBook.Close();
            excelApp.Quit();
            return true;
        }
    }
}
