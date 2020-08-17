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
            
            if (IsValidCep(cep))
            {
                Endereco endereco = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                lblResult.Text = string.Format("Endereço: {0}, {1} {2}", endereco.Localidade, endereco.Uf, endereco.Logradouro);
            }
            else
            {
                lblResult.Text = string.Empty;
            }
        }

        private bool IsValidCep(string cep)
        {
            int _cep = 0;
            if (!int.TryParse(cep, out _cep))
            {
                DisplayAlert("Atenção!", "CEP inválido! O CEP deve ser composto apenas por números.", "OK");
                return false;
            }

            if (cep.Length != 8)
            {
                DisplayAlert("Atenção!", "CEP inválido! O CEP deve ter 8 caracteres.", "OK");
                return false;
            }

            return true;
        }
    }
}
