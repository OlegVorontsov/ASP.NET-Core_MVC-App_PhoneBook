using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_MVC_App_PhoneBook.Models;

namespace ASP.NET_Core_MVC_App_PhoneBook.Data
{
    public class DbInitializer
    {
        public static void Initialize(PhoneBookContext context)
        {
            context.Database.EnsureCreated();

            if (context.Contacts.Any())
            {
                return;
            }

            ContactInfo i1 = new ContactInfo() { Phone = "(921)123-34-76", Note = "электрика" };
            ContactInfo i2 = new ContactInfo() { Phone = "(923)543-87-12", Note = "учитель в школе" };
            ContactInfo i3 = new ContactInfo() { Phone = "(929)643-23-89", Note = "" };
            ContactInfo i4 = new ContactInfo() { Phone = "(910)123-44-12", Note = "огород, советы" };
            ContactInfo i5 = new ContactInfo() { Phone = "(999)764-12-45", Note = "позвонить 01.12.25" };
            ContactInfo i6 = new ContactInfo() { Phone = "(987)878-86-98", Note = "охрана" };
            ContactInfo i7 = new ContactInfo() { Phone = "(988)654-99-11", Note = "не брать трубку" };
            ContactInfo i8 = new ContactInfo() { Phone = "(925)345-00-22", Note = "отдых, рыбалка" };
            ContactInfo i9 = new ContactInfo() { Phone = "(965)234-45-54", Note = "" };
            ContactInfo i10 = new ContactInfo() { Phone = "(978)765-12-65", Note = "театр" };
            ContactInfo i11 = new ContactInfo() { Phone = "(987)878-86-98", Note = "бассейн" };
            ContactInfo i12 = new ContactInfo() { Phone = "(988)654-99-11", Note = "досуг" };
            ContactInfo i13 = new ContactInfo() { Phone = "(925)345-00-22", Note = "родственник" };
            ContactInfo i14 = new ContactInfo() { Phone = "(965)234-45-54", Note = "рабочий" };
            ContactInfo i15 = new ContactInfo() { Phone = "(978)765-12-65", Note = "" };
            context.ContactInfos.AddRange(new List<ContactInfo> { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15 });
            context.SaveChanges();

            Contact c1 = new Contact() { FName = "Олег", LName = "Федоров", MName = "Владимирович", Infos = new List<ContactInfo> { i1, i2, i3 } };
            Contact c2 = new Contact() { FName = "Егор", LName = "Павлов", MName = "Викторович", Infos = new List<ContactInfo> { i4 } };
            Contact c3 = new Contact() { FName = "Лиза", LName = "Цвелева", MName = "Юрьевна", Infos = new List<ContactInfo> { i5 } };
            Contact c4 = new Contact() { FName = "Федор", LName = "Иванов", MName = "Павлович", Infos = new List<ContactInfo> { i6, i7 } };
            Contact c5 = new Contact() { FName = "Макар", LName = "Макаров", MName = "Осипович", Infos = new List<ContactInfo> { i8, i9 } };
            Contact c6 = new Contact() { FName = "Остап", LName = "Бендер", MName = "Христофорович", Infos = new List<ContactInfo> { i10 } };
            Contact c7 = new Contact() { FName = "Виктор", LName = "Остафьев", MName = "Иванович", Infos = new List<ContactInfo> { i11, i12, i13 } };
            Contact c8 = new Contact() { FName = "Наталья", LName = "Пушкина", MName = "Сергеевна", Infos = new List<ContactInfo> { i14 } };
            Contact c9 = new Contact() { FName = "Анна", LName = "Каренина", MName = "Павловна", Infos = new List<ContactInfo> { i15 } };
            context.Contacts.AddRange(new List<Contact> { c1, c2, c3, c4, c5, c6, c7, c8, c9 });
            context.SaveChanges();
        }
    }
}
