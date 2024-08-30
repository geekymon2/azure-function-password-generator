using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekyMon2.Azure.Function.RandomPasswordGenerator
{
    public class ResponseData
    {
        public ResponseData(string? password)
        {
            this.password = password;
        }

        public string? password { get; set; }
    }
}
