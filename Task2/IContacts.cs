using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    interface IContacts<T> where T : PhoneNumber
    {
        public string Adres { get; set; }
        public T PhoneNumber { get; set; }
        public T FriendPhoneNubmer { get; set; }
    }
}
