using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Utilities.Exceptions
{
    public class NgocNhanShopException : Exception
    {
        public NgocNhanShopException()
        {

        }
        public NgocNhanShopException(string message): base(message)
        {

        }
        public NgocNhanShopException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
