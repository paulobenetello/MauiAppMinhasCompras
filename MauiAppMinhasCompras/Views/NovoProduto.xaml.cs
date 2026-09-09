using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			String _categoria;

			if(pck_categoria.SelectedIndex == 0)
			{
				_categoria = "Higiene";
			}else if (pck_categoria.SelectedIndex == 1)
            {
                _categoria = "Alimentação";
            }
            else if (pck_categoria.SelectedIndex == 2)
            {
                _categoria = "Limpeza";
            }
			else
			{
                _categoria = "Entretenimento";
            }
                Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				Categoria = _categoria,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};

			await App.Db.Insert(p);
			await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
			await Navigation.PopAsync();
		}
		catch(Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}
    }
}