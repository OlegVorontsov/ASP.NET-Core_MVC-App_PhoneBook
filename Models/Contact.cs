using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC_App_PhoneBook.Models
{
    public class Contact
    {
        //id
        public int Id { get; set; }
        //имя
        public string FName { get; set; }
        //фамилия
        public string LName { get; set; }
        //отчество
        public string MName { get; set; }
        //инфо
        public ICollection<ContactInfo> Infos { get; set; }
        //конструктор
        public Contact()
        {
            Infos = new List<ContactInfo>();
        }
    }
}
