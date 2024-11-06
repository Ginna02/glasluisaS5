using glasluisaS5.Models;

namespace glasluisaS5.Views;

public partial class Principal : ContentPage
{
    public Principal()
    {
        InitializeComponent();
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        App.personRepo.AddNewPerson(txtName.Text);
        lblStatus.Text = App.personRepo.Status;
        txtName.Text = string.Empty;
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(txtId.Text, out int id))
        {
            Persona person = new Persona
            {
                Id = id,
                Name = txtName.Text
            };
            App.personRepo.UpdatePerson(person);
            lblStatus.Text = App.personRepo.Status;
        }
        else
        {
            lblStatus.Text = "ID inválido";
        }
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personRepo.DeletePerson(id);
            lblStatus.Text = App.personRepo.Status;
        }
        else
        {
            lblStatus.Text = "ID inválido";
        }
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        List<Persona> people = App.personRepo.GetAllPeople();
        listapersonas.ItemsSource = people;
    }
}
