using Agenda_Xamarin.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Agenda_Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCriar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CriarAcesso());
        }

        private async void btnLogar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var logar = new ServicosUser();
                bool verificarLogin = await logar.VerificarLogin(txtEmail.Text, txtSenha.Text);
                if (verificarLogin)
                {
                    await DisplayAlert("Sucesso", "usuario logado!", "Ok");
                    Navigation.PushAsync(new Contatos());
                }
                else
                {
                    await DisplayAlert("Falha", "usuario ou senha não corresponde!", "Ok");
                }
            }
            catch
            {
                await DisplayAlert("Falha", "Ocorreu um erro!", "Ok");
            }
        }

        private void btnSobre_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sobre());
        }
    }
}
