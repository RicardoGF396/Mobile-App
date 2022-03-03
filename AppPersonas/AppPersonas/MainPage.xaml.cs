using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace AppPersonas
{
    public partial class MainPage : ContentPage
    {
        public List<PersonModel> People;

        public Command SelectCommand => new Command(SelectAction);


        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonLoadPersons_Clicked(object sender, EventArgs e)
        {

            IndicatorPersons.IsRunning = true;
            ButtonLoadPersons.IsEnabled = false;


            People = new List<PersonModel>()

            {
                new PersonModel
                {
                    Id = 1,
                    FirstName = "Cristiano",
                    LastName = "Ronaldo",
                    Age = 37,
                    Phone = "4778521469",
                    Picture = "https://c.tenor.com/TMAcSxENMPcAAAAd/broob-broseidon.gif"
                },
                new PersonModel
                {
                    Id = 2,
                    FirstName = "Leo",
                    LastName = "Messi",
                    Age = 35,
                    Phone = "5788522469",
                    Picture = "https://pbs.twimg.com/profile_images/1236147931566223360/b9TGcDca_400x400.jpg"
                },
                new PersonModel
                {
                    Id = 3,
                    FirstName = "Javier",
                    LastName = "Hernández",
                    Age = 33,
                    Phone = "3338521469",
                    Picture = "https://www.soyfutbol.com/__export/1636857480725/sites/debate/img/2021/11/13/chicharito.jpg_2011753056.jpg"
                }
            };

            ListPeople.ItemsSource = People;
            IndicatorPersons.IsRunning = false;
            ButtonLoadPersons.IsEnabled = true;
            


        }

        private void ButtonNewPerson_Clicked( object sender,EventArgs e)
        {
            Navigation.PushAsync(new DetailView(this));
        }

        private void SelectAction(object obj)
        {
            Navigation.PushAsync(new DetailView(this, (PersonModel)obj));
        }

        public void ListRefresh()
        {
            ListPeople.ItemsSource = null;
            ListPeople.ItemsSource = People;
        }


        //Este selecciona a la persona y manda a ver sus detalles
        private void ListPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonModel personSelected = e.CurrentSelection.FirstOrDefault() as PersonModel;

            if(personSelected != null)
            {
                Navigation.PushAsync(new DetailView(this, personSelected));
            }
        }

    }
}
