using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTO_DBV_Creator.Model
{
    /// <summary>
    /// ATTCOLUMN
    /// </summary>
    public class AttributeColumn
    {


        public AttributeColumn(string owner, string description, string dbAttribute, string udna, bool promisse)//, bool isPML)
        {
            Owner = owner;
            DESC = description;
            DBATTRIBUTE = dbAttribute;
            UDNA = udna;
            READONLY = promisse;
            //IsPML = isPML;

        }
        public AttributeColumn(List<string> lstValues)
        {
            if (lstValues.Count == 6)
            {
                Owner = lstValues[0].Equals("") ? "DBV" : lstValues[0];
                DESC = lstValues[1];
                DBATTRIBUTE = lstValues[2];
                UDNA = lstValues[3];
                READONLY = Helper.ConvertToBool(lstValues[4]);
                IsPML = lstValues[5];
            }
        }

        public string Owner { get; set; }
        /// <summary>
        /// DESC 'Duty1UoM'
        /// </summary>
        public string DESC { get; set; }

        /// <summary>
        /// DBATTRIBUTE :Duty1UoM
        /// </summary>
        public string DBATTRIBUTE { get; set; }

        /// <summary>
        /// UDNA 'Duty1UoM'
        /// </summary>
        public string UDNA { get; set; }

        /// <summary>
        /// READONLY true
        /// </summary>
        public bool READONLY { get; set; }

        public string IsPML { get; set; }

        public string GetCode()
        {
            string retValue = string.Empty;
            if (IsPML.Equals("PML") || IsPML.Equals("XPATH"))
            {
                retValue += "NEW ATTCOLUMN" + Environment.NewLine +
                    "    DESC " + "'" + DESC + "'" + Environment.NewLine +
                    "    EXPRESSION " + "'" + DBATTRIBUTE + "'" + Environment.NewLine +
                    "    EXPTYPE " + "'" + IsPML + "'" + Environment.NewLine +
                    "    UDNA " + "'" + UDNA + "'" + Environment.NewLine +
                    "    UTYP TEXT " + Environment.NewLine +
                    "END" + Environment.NewLine;
            }
            else 
            {
                retValue += "NEW ATTCOLUMN" + Environment.NewLine +
                    "    DESC " + "'" + DESC + "'" + Environment.NewLine +
                    "    DBATTRIBUTE " + DBATTRIBUTE + Environment.NewLine +
                    "    UDNA " + "'" + UDNA + "'" + Environment.NewLine +
                    "    READONLY " + READONLY + Environment.NewLine +
                    "END" + Environment.NewLine;

            }
            
            return retValue;
        }
    }
}
