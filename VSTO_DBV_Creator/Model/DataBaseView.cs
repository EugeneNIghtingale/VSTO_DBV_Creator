using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTO_DBV_Creator.Model
{
    public class DataBaseView
    {
        public DataBaseView(List<string> lstValues)
        {
            if (lstValues.Count == 5)
            {
                Name = lstValues[0];
                Description = lstValues[1];
                UserDefinedName = lstValues[2];
                ElementTypes = lstValues[3];
                AUTCRE = Convert.ToBoolean(lstValues[4]);
            }
        }

        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserDefinedName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ElementTypes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool AUTCRE { get; set; }

        public List<SourceElement> lstSourceElements = new List<SourceElement>();
        //List<AttrubuteFilter> lstAttrubuteFilters { get; set; }
        //List<Rule> lstRule { get; set; }

        public string GetCode()
        {
            string retValue = string.Empty;
            retValue += "INPUT BEGIN" + Environment.NewLine +
                "   NEW DBVW " + Name + Environment.NewLine +
                "   DESC " + "'" + Description + "'"+ Environment.NewLine +
                "   UDNA " + "'" + UserDefinedName +"'"  +Environment.NewLine +
                "   ELEL ADD " + ElementTypes + Environment.NewLine +
                "   AUTCRE " + AUTCRE + Environment.NewLine;


            if (lstSourceElements.Count != 0)
            {
                foreach (SourceElement srcElement in lstSourceElements)
                {
                    retValue += srcElement.GetCode();
                }
            }

            retValue += "INPUT END";
            return retValue;
        }


    }
}
