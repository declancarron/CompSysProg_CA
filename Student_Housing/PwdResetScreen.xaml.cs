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
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Student_Housing
{
    /// <summary>
    /// Interaction logic for PwdResetScreen.xaml
    /// </summary>
    /// 

    




    public partial class PwdResetScreen : Window
    {
        public PwdResetScreen()
        {
            InitializeComponent();
        }

        private void btnPwdResetCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPwdResetSubmit_Click(object sender, RoutedEventArgs e)
        {
           // string pwdResetSubject = "";
           // string pwdResetMessage = "";
           // try
           // {
            //    Outlook._Application pwdResetMail = new Outlook._Application();
            //    Outlook.MailItem mail = (Outlook.MailItem)pwdResetMail.CreateItem(Outlook.OlItemType.olMailItem);

                //building the email message
            //    mail.To = tbxPwdEmailAddr.Text;
            //    mail.Subject = pwdResetSubject;
            //    mail.Body = pwdResetMessage;
            //    mail.Importance = Outlook.OlImportance.olImportanceHigh;
            //    ((Outlook.MailItem)mail.Send());
            //    MessageBox.Show("Please check your email for Password information", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK,MessageBoxImage.Error);
           // }
            

        }
    }
}
