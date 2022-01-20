using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTO_DBV_Creator.Model
{

    public class SourceElement
    {
        public SourceElement(string owner, string description, string expression, string exptype, bool autoCreate)
        {
            Owner = owner;
            DESC = description;
            EXPRESSION = expression;
            EXPTYPE = exptype;
            AUTCRE = autoCreate;
        }
        public SourceElement(List<string> lstValues)
        {
            if (lstValues.Count == 5)
            {
                Owner = lstValues[0];
                DESC = lstValues[1];
                EXPRESSION = lstValues[2];
                EXPTYPE = lstValues[3];
                AUTCRE = Convert.ToBoolean(lstValues[4]);
            }
        }
        public string Owner { get; set; }

        /// <summary>
        /// DESC 'PROC'
        /// </summary>
        public string DESC { get; set; }

        /// <summary>
        /// EXPRESSION 'XRQELE( typename :MechanicalEquipmentPROC )'
        /// </summary>
        public string EXPRESSION { get; set; }

        /// <summary>
        /// EXPTYPE 'PML'
        /// </summary>
        public string EXPTYPE { get; set; }

        /// <summary>
        /// AUTCRE true
        /// </summary>
        public bool AUTCRE { get; set; }

        //Список атрибутов
        public List<AttributeColumn> lstAttributeColumns = new List<AttributeColumn>();
        //Список правил
        //public List<Rule> lstRules = new List<Rule>();
        //Список дочерних источников данных
        public List<SourceElement> lstSourceElemnt = new List<SourceElement>();

        public string GetCode()
        {
            string retValue = string.Empty;
            retValue += "NEW SRCELEMENT" + Environment.NewLine +
                "   DESC " + "'"+ DESC +"'" + Environment.NewLine +
                "   EXPRESSION " + "'" + EXPRESSION+ "'" + Environment.NewLine +
                "   EXPTYPE " + "'"+EXPTYPE+ "'" + Environment.NewLine +
                "   AUTCRE " + AUTCRE + Environment.NewLine;


            if (lstSourceElemnt.Count != 0)
            {
                foreach (SourceElement srcElement in lstSourceElemnt)
                {
                    retValue += srcElement.GetCode();
                }
            }

            if (lstAttributeColumns.Count != 0)
            {
                foreach (AttributeColumn attributeColumn in lstAttributeColumns)
                {
                    retValue += attributeColumn.GetCode();
                }
            }
            retValue += "END" + Environment.NewLine;
            return retValue;
        }
    }
    
}
