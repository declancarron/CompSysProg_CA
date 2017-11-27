using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Housing
{
    /// <summary>
    /// Interaction logic for apartmentPage.xaml
    /// </summary>
    public partial class PageApartment : Page
    {
        public PageApartment()
        {
            InitializeComponent();
        }

        //village selection from Village Combobox will populate the appartments available for selection
        private void ApartmentVillageCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstApartmentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
