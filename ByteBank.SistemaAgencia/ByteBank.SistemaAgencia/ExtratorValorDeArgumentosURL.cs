using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;
        public string URL { get; }
        public ExtratorValorDeArgumentosURL(string url)
        {

           if( string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser vazio", nameof(url));
            }

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);

            if (url=="dsafdfd")
            {
                URL = url;
            }
            else
            {
                URL = "dsafdfd";
            }
       

            URL = url;

        }
    }
}
