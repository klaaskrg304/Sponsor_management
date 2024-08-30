
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Projekt_SternbergundMehr
{
    
    public partial class Window_mail : Window
    {

        private DataTable dt;
        public Window_mail()
        {
            InitializeComponent();
            recieve_mail();
        }

        //methods

        private void recieve_mail()
        {
            try
            {
                Outlook.Application _app = new Outlook.Application();
                Outlook.NameSpace _ns = _app.GetNamespace("MAPI");
                Outlook.MAPIFolder inbox = _ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                _ns.SendAndReceive(true);

                dt = new DataTable("Inbox");
                dt.Columns.Add("Betreff", typeof(string));
                dt.Columns.Add("Absender", typeof(string));
                dt.Columns.Add("Inhalt", typeof(string));
                dt.Columns.Add("Datum", typeof(string));
                dataGrid_mail.ItemsSource = dt.DefaultView;

                foreach (Outlook.MailItem item in inbox.Items)
                {
                    dt.Rows.Add(new object[]
                    {
                        item.Subject,
                        item.SenderName,
                        item.Body, // Verwende `Body` anstelle von `HTMLBody`, um Plaintext zu nutzen
                        item.SentOn.ToLongDateString() + " " + item.SentOn.ToLongTimeString()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void send_mail()
        {
            try
            {

                Outlook._Application _app = new Outlook.Application();
                Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                mail.To = tbx_adress.Text;
                mail.Subject = tbx_subject.Text;
                mail.Body = tbx_message.Text;
                mail.Importance = Outlook.OlImportance.olImportanceNormal;
                ((Outlook._MailItem)mail).Send();
                MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       

        private async void DisplayStyledContentInWebView2(string htmlContent)
        {
            if (WebView2 != null)
            {
                await WebView2.EnsureCoreWebView2Async(null);
                string styledHtml = $@"
        <html>
        <head>
            <style>
                body {{ font-family: Arial, sans-serif; margin: 20px; }}
                .email-content {{ border: 1px solid #ddd; padding: 15px; border-radius: 5px; }}
                h1 {{ color: #333; }}
                p {{ color: #666; }}
            </style>
        </head>
        <body>
            <div class='email-content'>
                {htmlContent}
            </div>
        </body>
        </html>";

                WebView2.NavigateToString(styledHtml);
            }
        }


        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            send_mail();


        }
        

        private void btn_recieve_Click(object sender, RoutedEventArgs e)
        {
            recieve_mail();
        }

        private void dataGrid_mail_Selected(object sender, RoutedEventArgs e)
        {
            

        }

        private void dataGrid_mail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid_mail.SelectedItem is DataRowView rowView)
            {
                string bodyContent = rowView["Inhalt"].ToString();
                
                DisplayStyledContentInWebView2(bodyContent);
            }
        }

        private void dataGrid_mail_Selected_1(object sender, RoutedEventArgs e)
        {
            if (dataGrid_mail.SelectedItem is DataRowView rowView)
            {
                string bodyContent = rowView["Inhalt"].ToString();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void brief_prnt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
