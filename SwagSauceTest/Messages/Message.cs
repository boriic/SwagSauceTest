using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest.Messages
{
    public static class Message
    {
        //LOGIN MESSAGES
        public const string NoInfoLoginError = "Epic sadface: Username is required";
        public const string WrongInfoLoginError = "Epic sadface: Username and password do not match any user in this service";
        public const string NoPasswordLoginError = "Epic sadface: Password is required";
        public const string Products = "Products";
        public const string Login = "LOGIN";

        //PRODUCT PAGE MESSAGES
        public const string AddToCart = "ADD TO CART";
        public const string RemoveFromCart = "REMOVE";
    }
}
