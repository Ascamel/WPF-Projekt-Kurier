using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.Models
{
    public class Client
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string adress { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public bool isCompany { get; set; }
        public int? nip { get; set; }

        public List<Parcel> myParcels { get; set; }



        public Client(int id, string firstName, string surname, string adress, int phone, string email, bool isCompany, int? nip, List<Parcel> myParcels)
        {
            this.id = id;
            this.firstName=firstName;
            this.surname=surname;
            this.adress=adress;
            this.phone=phone;
            this.email=email;
            this.isCompany=isCompany;
            this.nip=nip;
            this.myParcels = myParcels;
        }

        public Client()
        {
        }

        public override string ToString()
        {
            string idplusname;
            idplusname = "["+id.ToString() +"] "+ firstName+" "+surname; 
            return idplusname;
        }
    }
}
