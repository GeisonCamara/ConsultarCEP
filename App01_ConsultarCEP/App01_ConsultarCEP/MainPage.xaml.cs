using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscarCep.Clicked += BuscarCep;
        }
        private void BuscarCep(object sender, EventArgs args)
        {
            string cep = txtCep.Text.Trim();
            Endereco endereco = ViaCEPServico.BuscarEnderecoViaCEP(cep);

            lblResult.Text = string.Format("Endereço: {0}, {1} {2}", endereco.Localidade, endereco.Uf, endereco.Logradouro);
        }
    }
}
