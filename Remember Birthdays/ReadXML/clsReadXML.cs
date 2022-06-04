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
               
                string cadastro = @"./config.xml";
                //doc.Load(cadastro);
                //XmlNode nodeListTipo = doc.SelectNodes("//root//data//tipo").Item(0);
                //XmlNodeList nodeListMetadata = doc.SelectNodes("//root//data//tipo//metadata");
                //logValue = nodeListTipo.Attributes["logValue"].Value;

                //string sCaminhoDoArquivo = Server.MapPath(cadastro);

                //Lendo XML com XmlTextReader
                XmlDocument doc = new XmlDocument();
                doc.Load(cadastro);

                XmlNodeList LogValue = doc.GetElementsByTagName("logValue");
                this.setLog(LogValue[0].InnerText);

            }
            catch (Exception Ex)
            {
                throw;
            }
        }    //LER VALOR QUE O USUÁRIO DEIXOU PRA DEMOSTAR LOG
    }
}
