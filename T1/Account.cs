using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    public class Account : IAccId<string>
    {
        private readonly string _accountId;

        public Account()
        {
            _accountId = Guid.NewGuid().ToString();
        }

        public string AccountId()
        {
            return _accountId;
        }
    }
}
