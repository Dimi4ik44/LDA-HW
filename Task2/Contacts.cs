using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Contacts<T> : IContacts<T>
    {
        public string Adres { get; set; }
        public T PhoneNumber { get; set; }
        public T FriendPhoneNubmer { get; set; }

    }
}
