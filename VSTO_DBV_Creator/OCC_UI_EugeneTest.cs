using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace VSTO_DBV_Creator
{
    public partial class OCC_UI_EugeneTest
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btn_Run_Click(object sender, RibbonControlEventArgs e)
        {

            #region --GetData--
            try
            {
                Excel.Range rngDBV = Globals.ThisAddIn.Application.get_Range("A3:E3");
                Excel.Range rngSource = Globals.ThisAddIn.Application.get_Range("A7:E100");
                Excel.Range rngAttr = Globals.ThisAddIn.Application.get_Range("G3:K200");
                var lstDBVValues = Helper.ReadTable(rngDBV);
                var lstSrcValues = Helper.ReadTable(rngSource);
                var lstAttrValues = Helper.ReadTable(rngAttr);

                //Сбор dbv
                if (lstDBVValues.First()[0] == "")
                {
                    System.Windows.Forms.MessageBox.Show("Check input data in DBV");
                }
                Model.DataBaseView dataBaseView = new Model.DataBaseView(lstDBVValues.First());


                //Сбор источников данных
                List<Model.SourceElement> lstSource = new List<Model.SourceElement>();
                foreach (var str in lstSrcValues)
                {
                    if (str[0] == "")
                        break;
                    lstSource.Add(new Model.SourceElement(str));
                }

                //Сбор атрибутов
                List<Model.AttributeColumn> lstAtr = new List<Model.AttributeColumn>();
                foreach (var str in lstAttrValues)
                {
                    if (str[0] == "")
                        break;
                    lstAtr.Add(new Model.AttributeColumn(str));
                }
                #endregion

                #region --Grouping--
                var srcGroup = lstSource.GroupBy(p => p.Owner);
                var attrGroup = lstAtr.GroupBy(p => p.Owner);

                foreach (var itm in attrGroup)
                {
                    
                    if (lstSource.Where(p => p.DESC.Equals(itm.Key)).Count() != 0)
                        lstSource.Where(p => p.DESC.Equals(itm.Key)).First().lstAttributeColumns.AddRange(itm.ToList());
                    if (itm.Key.Equals("DBV") || itm.Key.Equals(dataBaseView.Description) || itm.Key.Equals(dataBaseView.UserDefinedName))
                        dataBaseView.lstAttributeColumns.AddRange(itm.ToList());
                }


                foreach (var itm in srcGroup)
                {
                    if (lstSource.Where(p => p.DESC.Equals(itm.Key)).Count() != 0 && lstSource.Count() != 0)
                        lstSource.Where(p => p.DESC.Equals(itm.Key)).First().lstSourceElemnt.AddRange(itm.ToList());
                }

                dataBaseView.lstSourceElements.AddRange(lstSource.Where(p => p.Owner.Equals("DBV")));
                #endregion

                string code = dataBaseView.GetCode();
                Helper.WriteToFile(code, Globals.ThisAddIn.Application.ActiveWorkbook.Path,
                    dataBaseView.Description + ".pmlfnc");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

    }
}
