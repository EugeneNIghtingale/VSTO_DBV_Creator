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


        public AttributeColumn(string owner, string description, string dbAttribute, string udna, bool promisse)
        {
            Owner = owner;
            DESC = description;
            DBATTRIBUTE = dbAttribute;
            UDNA = udna;
            READONLY = promisse;
        }
        public AttributeColumn(List<string> lstValues)
        {
            if (lstValues.Count == 5)
            {
                Owner = lstValues[0];
                DESC = lstValues[1];
                DBATTRIBUTE = lstValues[2];
                UDNA = lstValues[3];
                READONLY = Convert.ToBoolean(lstValues[4]);
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

        public string GetCode()
        {
            string retValue = string.Empty;
            retValue += "NEW ATTCOLUMN" + Environment.NewLine +
               "    DESC " + "'" + DESC + "'" + Environment.NewLine +
               "    DBATTRIBUTE " + DBATTRIBUTE + Environment.NewLine +
               "    UDNA " + "'" + UDNA + "'" + Environment.NewLine +
               "    READONLY " + READONLY + Environment.NewLine +
               "END" + Environment.NewLine;
            return retValue;
        }
    }
}
