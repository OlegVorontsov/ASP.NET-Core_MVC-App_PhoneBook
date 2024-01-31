using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC_App_PhoneBook.Models
{
    public class ContactInfo
    {
        //id
        public int Id { get; set; }
        //телефон
        public string Phone { get; set; }
        //описание
        public string Note { get; set; }
        //id контакта
        public int? ContactId { get; set; }
        //контакт
        public Contact Contact { get; set; }
    }
}
