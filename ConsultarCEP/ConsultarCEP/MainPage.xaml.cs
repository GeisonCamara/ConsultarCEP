using ConsultarCEP.Servico;
using ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultarCEP
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
            string cep = txtCep.Text != null ? txtCep.Text.Trim() : string.Empty;

            if (IsValidCep(cep))
            {
                try
                {
                    Endereco endereco = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    var resultado = "Resultado:\n";
                    if (endereco != null && endereco.Cep != null)
                    {
                        if (!string.IsNullOrEmpty(endereco.Cep))
                            resultado += string.Format("CEP: {0}\n", endereco.Cep);
                        
                        if (!string.IsNullOrEmpty(endereco.Logradouro))
                            resultado += string.Format("Logradouro: {0}\n", endereco.Logradouro);

                        if (!string.IsNullOrEmpty(endereco.Complemento))
                            resultado += string.Format("Complemento: {0}\n", endereco.Complemento);

                        if (!string.IsNullOrEmpty(endereco.Bairro))
                            resultado += string.Format("Bairro: {0}\n", endereco.Bairro);                        

                        if (!string.IsNullOrEmpty(endereco.Localidade))
                            resultado += string.Format("Localidade: {0}\n", endereco.Localidade);
                        
                        if (!string.IsNullOrEmpty(endereco.Uf))
                            resultado += string.Format("UF: {0}\n", endereco.Uf);
                        
                        if (!string.IsNullOrEmpty(endereco.Unidade))
                            resultado += string.Format("Unidade: {0}\n", endereco.Unidade);
                        
                        if (!string.IsNullOrEmpty(endereco.Ibge))
                            resultado += string.Format("Código Ibge: {0}\n", endereco.Ibge);

                        lblResult.Text = resultado;
                    }
                    else
                    {
                        ClearResult();
                        DisplayAlert("Consultar CEP", string.Format("Não encontramos nenhum resultado para o CEP informado: {0}", cep), "OK");
                    }
                }
                catch (Exception e)
                {
                    ClearResult();
                    DisplayAlert("Erro ao Consultar", e.Message, "OK");
                }
            }
            else
            {
                ClearResult();
            }
        }

        private void ClearResult()
        {
            lblResult.Text = string.Empty;
        }

        private bool IsValidCep(string cep)
        {
            if (cep.Length == 0)
            {
                DisplayAlert("Atenção!", "Informe um CEP para efetuar a pesquisa.", "OK");
                return false;
            }

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
