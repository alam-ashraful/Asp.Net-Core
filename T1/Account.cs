using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    public class Account : IAccId<string>, IName<string>, IBalance<double>
    {
        private readonly string _accountId;
        private string _name;
        private double _balance;

        public Account()
        {
            _accountId = Guid.NewGuid().ToString();
        }

        public string AccountId()
        {
            return _accountId;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetBalance(double balance)
        {
            if (balance > Constants.MIN_BALANCE && balance < Constants.MAX_BALANCE)
            {
                _balance = balance;
            }
            else
            {
                Console.WriteLine("Invalid balance...");
            }
        }

        public string GetName()
        {
            return _name;
        }

        public double GetBalance()
        {
            return _balance;
        }
    }
}
