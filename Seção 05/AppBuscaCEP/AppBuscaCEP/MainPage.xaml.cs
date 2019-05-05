using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppBuscaCEP.Servico;
using AppBuscaCEP.Servico.Modelo;

namespace AppBuscaCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            bt_BuscarCep.Clicked += Bt_BuscarCep_Clicked;
        }

        private void Bt_BuscarCep_Clicked(object sender, EventArgs e)
        {
            string cep = tx_Cep.Text.Trim().Replace("-","");
            try
            {
                if (cep.Length == 8)
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end.erro != true)
                    {
                        lb_Rua.Text = "Rua: " + end.logradouro;
                        lb_Bairro.Text = "Bairro: " + end.bairro;
                        lb_Cidade.Text = "Cidade: " + end.localidade + "-" + end.uf;
                        lb_IBGE.Text = "Cód. IBGE: " + end.ibge;
                    }
                    else
                        DisplayAlert("Ops!","Cep não encontrado","Ok");
                }
            }
            catch (Exception ex)
            {

                DisplayAlert("Ops! Algo deu errado",ex.Message,"Ok");
            }
            
        }
    }
}
