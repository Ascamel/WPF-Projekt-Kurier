using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projekt_WPF.Models
{
    public class Parcel
    {
        private int _id;
        private string _adress;
        private int _weight;
        private string _size;
        private Client _recipient;
        private string _clientName;
        private string _status;

        //

        public int Id { get => _id; set => _id=value; }
        public string Adress { get => _adress; set => _adress=value; }
        public int Weight { get => _weight; set => _weight=value; }
        public string Size { get => _size; set => _size=value; }
        public Client Recipient { get => _recipient; set => _recipient=value;  }
        public string ClientName { get => _clientName; set => _clientName=value; }
        public string Status {
            get { return _status; }
            set { _status=value; OnPropertyChanged(); }
        }

        public Parcel(int id, string adress, int weight, string size, string status, Client client, string clientName)
        {
            Id=id;
            Adress=adress;
            Weight=weight;
            Size=size;
            Recipient=client;
            ClientName=clientName;
            Status=status;
        }

        public Parcel()
        {
        }

        private void OnPropertyChanged()
         {
            if(Recipient!=null)
            {
                string emailTo = this.Recipient.email;
                string message = "Przesyłka numer: "+this.Id + "\nAktualny status przesyłki to: "+this.Status;
                Email(message, emailTo);
            }
           


        }

        public static void Email(string htmlString, string emailTo)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("pbwpfprojekt2022@gmail.com");
            message.To.Add(new MailAddress(emailTo));


            message.Subject = "Zmiana statusu przesyłki";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = htmlString;
            smtp.Port = 465;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("pbwpfprojekt2022@gmail.com", "H@slodoprojektu1");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //NIE DZIALA PO 30.05.20200
           // smtp.Send(message);

        }

        public override string ToString()
        {
            string idplusname;
            idplusname = "Numer przesyłki: "+Id.ToString();
            return idplusname;
        }
    }
}
