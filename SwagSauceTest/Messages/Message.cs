using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest.Messages
{
    public class Message
    {
        //LOGIN MESSAGES
        public readonly string NoInfoLoginError = "Epic sadface: Username is required";
        public readonly string WrongInfoLoginError = "Epic sadface: Username and password do not match any user in this service";
        public readonly string NoPasswordLoginError = "Epic sadface: Password is required";
        public readonly string Products = "Products";
        public readonly string Login = "LOGIN";

        //PRODUCT PAGE MESSAGES
        public readonly string AddToCart = "ADD TO CART";
        public readonly string RemoveFromCart = "REMOVE";
    }
}
