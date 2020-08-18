using ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConsultarCEP.Servico
{
    class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novaConsultaURL = string.Format(EnderecoURL, cep);

            WebClient client = new WebClient();
            string clientResponse = client.DownloadString(novaConsultaURL);

            return JsonConvert.DeserializeObject<Endereco>(clientResponse);
        }
    }
}
