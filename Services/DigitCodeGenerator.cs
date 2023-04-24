using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Services
{
    public static class DigitCodeGenerator
    {
        public static int ConfirmCode;

        public static int Generate()
        {
            Random random = new Random();
            ConfirmCode= random.Next(10000, 99999);
            return ConfirmCode;
        }
    }
}
