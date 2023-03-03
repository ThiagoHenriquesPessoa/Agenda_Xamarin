using Agenda_Xamarin.Class;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriarAcesso : ContentPage
    {
        public CriarAcesso()
        {
            InitializeComponent();
        }

        private async void btnCriarAcesso_Clicked(object sender, EventArgs e)
        {
            if (txtCriarSenha.Text != txtConfirmarSenha.Text)
            {
                await DisplayAlert("falha", "senha não corresponde!", "Ok");
                return;
            }
            try
            {
                var acesso = new ServicosUser();
                bool criarAcesso = await acesso.RegistrarUsuario(txtCriarEmail.Text, txtCriarSenha.Text);
                if (criarAcesso)
                {
                    await DisplayAlert("Sucesso", "Usuario criado!", "Ok");
                    return;
                }
                else
                {
                    await DisplayAlert("Falha", "Não foi possivel criar usuario, Tente novamente!", "Ok");
                }
            }
            catch
            {
                await DisplayAlert("Falha", "Ocorreu um erro!", "Ok");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            txtCriarEmail.Text = string.Empty;
            txtCriarSenha.Text = string.Empty;
            txtConfirmarSenha.Text = string.Empty;
        }
    }
}