using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class InterestEarningAccount: BankAccount//все что есть в bankaccount можно использовать, кроме private
    {
        public InterestEarningAccount(string name, decimal initialBalance): base(name, initialBalance)
        {

        }
        //override (производный класс) позволяет в дочернем классе определить новую реализацию
        //метода PerformMonthAndTransactions
        public override void PerformMonthAndTransactions()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.02m;
                MakeDeposit(interest, DateTime.UtcNow, "Apply month interest");
            }
            
        }
    }
}
