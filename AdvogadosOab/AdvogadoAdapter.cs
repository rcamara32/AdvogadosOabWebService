using AdvogadosOab.AdvogadoOABWS;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AdvogadosOab.Models;

namespace AdvogadosOab
{
    public static class AdvogadoAdapter
    {
        public static IList<AdvogadoData> ConsultaAdvogado(string inscricao, string uf, string nome)
        {
            var service = new ServiceSoapClient();
            var auth = new Authentication { Key = "6c59e759-f52d-49e2-b37a-4b3e873c3119" };
            var result = service.ConsultaAdvogado(auth, inscricao, uf, nome);
            var xmlReader = new StringReader(result);
            var serializer = new XmlSerializer(typeof(List<AdvogadoData>), new XmlRootAttribute("ArrayOfAdvogadoData"));

            return (List<AdvogadoData>)serializer.Deserialize(xmlReader);
        }
    }
}