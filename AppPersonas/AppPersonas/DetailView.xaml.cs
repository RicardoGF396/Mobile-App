using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPersonas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {
        MainPage MainPage;
        PersonModel Person = new PersonModel();

        public DetailView(MainPage mainPage)
        {
            InitializeComponent();
            this.MainPage = mainPage;

        }
        public DetailView(MainPage mainPage, PersonModel person)
        {
            InitializeComponent();
            this.MainPage = mainPage;
            //this.Person;
            //Cargar persona seleccionada
            this.Person.Id = person.Id;
            ImagePicture.Source = person.Picture;
            EntryPicture.Text = person.Picture;
            EntryFirstName.Text = person.FirstName;
            EntryLastName.Text = person.LastName;
            EntryAge.Text = person.Age.ToString();
            EntryPhone.Text = person.Phone;
        }
        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            if(this.Person.Id > 0)
            {
                //Actualizar

                for(int index = 0; index < this.MainPage.People.Count; index++)
                {
                    if(this.MainPage.People[index].Id == this.Person.Id)    
                    {
                        this.MainPage.People[index].Picture = EntryPicture.Text;
                        this.MainPage.People[index].FirstName = EntryFirstName.Text;
                        this.MainPage.People[index].LastName = EntryLastName.Text;
                        this.MainPage.People[index].Age = int.Parse(EntryAge.Text);
                        this.MainPage.People[index].Phone = EntryPhone.Text;
                        break;
                    }
                    
                }

                
            }
            else
            {
                //Crear
                Person.Picture = EntryPicture.Text;
                Person.FirstName = EntryFirstName.Text;
                Person.LastName = EntryLastName.Text;
                Person.Age = int.Parse(EntryAge.Text);
                Person.Phone = EntryPhone.Text;

                //Agregamos la nueva persona a nuestra lista de personas
                this.MainPage.People.Add(Person);
                    
            }
                //Refrescar nuestro collectionView
                this.MainPage.ListRefresh();

                //Regresar a la vista de listado
                Navigation.PopAsync();
        }

        private void ButtonEliminate_Clicked(object sender, EventArgs e)
        {
            if (this.Person.Id > 0)
            {
                //Actualizar

                for (int index = 0; index < this.MainPage.People.Count; index++)
                {
                    if (this.MainPage.People[index].Id == this.Person.Id)
                    {                      
                        this.MainPage.People.RemoveAt(index);
                        break;
                    }

                }


            }
           
            //Refrescar nuestro collectionView
            this.MainPage.ListRefresh();

            //Regresar a la vista de listado
            Navigation.PopAsync();
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}