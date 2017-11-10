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
using System.Windows.Shapes;

namespace Student_Housing
{
    /// <summary>
    /// Interaction logic for NewUserReg.xaml
    /// </summary>
    public partial class NewUserReg : Window
    {
        string genderSelection = "";
        string yearOfStudySelection = "";
        string marriedStatusSelection = "";
        string rmPreferenceSelection = "";
        string deptSelection = "";

        public NewUserReg()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string fname = "";
            string sname = "";
            string studentEmail = "";
            string studentMobile = "";
            string address = "";
            string town = "";
            string city = "";
            string county = "";
            string country = "";
            string DOB = "";
            string courseOfStudy="";
            string courseDepartment = "";
            string yearOfStudy = "";
            string nationality = "";
            string parentName = "";
            string parentsEmail = "";
            string parentsTele = "";
            string RoomPreference = "";

            fname = tbxFName.Text.Trim();
            sname = tbxSName.Text.Trim();
            studentEmail = tbxEmail.Text.Trim();
            studentMobile = tbxMobile.Text.Trim();
            address = tbxHomeAddr.Text.Trim();
            town = tbxHomeTown.Text.Trim();
            city = tbxHomeCity.Text.Trim();
            county = tbxHomeCounty.Text.Trim();
            DOB = tbxDOB.Text.Trim();

            country = tbxHomeCountry.Text.Trim();
            nationality = tbxNationality.Text.Trim();

            courseOfStudy = tbxCourse.Text.Trim();
            parentName = tbxParentName.Text.Trim();
            parentsEmail = tbxParentEmail.Text.Trim();
            parentsTele = tbxParentTel.Text.Trim();

            

        }

        private void cboGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int genderSelected = cboGender.SelectedIndex;
            string genderSelection = "";
            
        }

        private void cboMarriedStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int marriedStatus = cboMarriedStatus.SelectedIndex;
            
            string marriedStatusSelection = "";
            
            
        }

        private void cboDept_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int deptChoice = cboDept.SelectedIndex;
            string deptSelection = "";
        }

        private void cboCourseYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int yearOfCourse = cboCourseYear.SelectedIndex;
            string yearOfStudySelection = "";
        }

        private void cboRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int roomChoice = cboRoomType.SelectedIndex;
            string rmPreferenceSelection = "";
        }
    }
}
