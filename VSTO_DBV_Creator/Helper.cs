using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace VSTO_DBV_Creator
{
    public static class Helper
    {
        public static void WriteToFile(string text, string path, string name)
        {
            try
            {
                if (File.Exists(path + "\\" + name))
                    name = name.Split('.')[0] + "_NEW.pmlfnc" ;
                StreamWriter sw = new StreamWriter(path+"\\"+name);
                sw.Write(text);
                sw.Close();
                System.Diagnostics.Process.Start("explorer", path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Write done.");
            }
        }

        public static List<List<string>> ReadTable(Excel.Range rng)
        {       
            List<List<string>> retValue = new List<List<string>>();
            for (int iRow = rng.Row; iRow <= rng.Row+ rng.Rows.Count - 1; iRow++)
            {
                List<string> row = new List<string>();
                for (int iCount = rng.Column; iCount <= rng.Column+ rng.Columns.Count - 1; iCount++)
                {   
                    row.Add(GetValue(iRow, iCount));
                }
                retValue.Add(row);
            }
            return retValue;
        }
        
        private static string GetValue(int iRow, int iColumn)
        {
            var actSheet = Globals.ThisAddIn.Application.ActiveSheet;
            var cell = (Excel.Range)actSheet.Cells[iRow, iColumn];
            return cell.Text;
        }
    }
 
}
