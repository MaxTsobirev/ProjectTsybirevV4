using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectTsybirevV4
{
    public partial class MainPage : ContentPage
    {
        string filename;
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        protected internal ObservableCollection<Maakond> Maakonnads { get; set; }
        public ObservableCollection<Maakond> Maakonnadss { get; }

        public MainPage()
        {
            InitializeComponent();
            Maakonnadss = new ObservableCollection<Maakond>
            {
                new Maakond {Nimetus="Harjumaa",Pealinn="Tallinn",Inimeste_arv=5239858},
                new Maakond {Nimetus="Tartumaa",Pealinn="Tartu",Inimeste_arv=324544},
                new Maakond {Nimetus="Ida-Virumaa",Pealinn="Kohtla",Inimeste_arv=1234123}
            };
            list.BindingContext = Maakonnadss;
        }
        private async void Button_Clicked(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new Maakonnad(null));
        }
        private async void list_ItemSelected(object sender,SelectedItemChangedEventArgs e)
        {
            Maakond selected = e.SelectedItem as Maakond;
            if(selected != null)
            {
                list.SelectedItem = null;
                await Navigation.PushAsync(new Maakonnad(selected));
            }
        }
        protected internal void AddMaakond(Maakond maakond)
        {
            Maakonnadss.Add(maakond);
        }
        private void Loe_failist(object sender, EventArgs e)
        {
            filename = "Maakonnad.txt";
            if (String.IsNullOrEmpty(filename)) return;
            if (filename != null)
            {
                String[] Andmed = File.ReadAllLines(Path.Combine(folderPath, filename));
                for (int i = 0; i < Andmed.Length; i++)
                {
                    var columns = Andmed[i].Split(' ');
                    var maakond = new Maakond(columns[0], columns[1], int.Parse(columns[2]));
                    if (Maakonnadss.Where(m => m.Nimetus == maakond.Nimetus).FirstOrDefault() == null)
                    {
                        Maakonnadss.Add(maakond);
                    }
                    list.BindingContext = Maakonnadss;
                }
            }
        }

    }
}