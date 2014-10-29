using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Linq;

namespace theRightDirection.Library.Extensions
{
    public static class DataTableExtension
    {
        public static void ToXml(this DataTable datatable, string xmlFileName, string rootNodeName, string nodeName)
        {
            XElement xmlDocument = new XElement(rootNodeName);
            foreach (DataRow row in datatable.Rows)
            {
                XElement xmlNode = new XElement(nodeName);
                for (int i = 0; i < row.ItemArray.Length; i++)
                { 
                    string columnName = row.Table.Columns[i].ColumnName;
                    XElement xmlDataNode = new XElement(columnName);
                    xmlDataNode.Value = row.ItemArray[i].ToString();
                    xmlNode.Add(xmlDataNode);
                }
                xmlDocument.Add(xmlNode);
            }
            xmlDocument.Save(xmlFileName);
        }
    }
}