using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Remember_Birthdays.ReadXML
{
    public class clsReadXML
    {
        public string  logValue { get; set; }


        public void setLog(string logValue)
        {
            this.logValue = logValue;
        } //COLOCAR VALORES DA PROPRIEDADE

        public string getLog()
        {
            return this.logValue;
        }  //MOSTRAR VALORES DA PROPRIEDADE

        public void ReadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string cadastro = @"./config.xml";
                doc.Load(cadastro);
                XmlNode nodeListTipo = doc.SelectNodes("//root//data//tipo").Item(0);
                XmlNodeList nodeListMetadata = doc.SelectNodes("//root//data//tipo//metadata");
                logValue = nodeListTipo.Attributes["logValue"].Value;
            }
            catch (Exception Ex)
            {
                throw;
            }
        }    //LER VALOR QUE O USUÁRIO DEIXOU PRA DEMOSTAR LOG
    }
}
