using Bank;
using System;
using Xunit;

namespace BankXUnitTestProject
{
    public class BankAccountTest
    {
        [Fact]
        public void Adding_Funds_Updates_Balance()
        {
            //Arrange

            var account = new BankAccount(1000);

            //Act
            account.Add(100);

            //Assert
            Assert.Equal(1100, account.Balance);
        }



        [Fact]
        public void Withdraw_Funds_Updates_Balance()
        {
            //Arrange

            var account = new BankAccount(1000);

            //Act
            account.Withdraw(100);

            //Assert
            Assert.Equal(900, account.Balance);
        }


        [Fact]
        public void Transfer_Funds_Updates_BothAccounts()
        {
            //Arrange

            var account = new BankAccount(1000);
            var otherbankaccount= new BankAccount(1000);
            //Act
            account.TransferFundsTo(otherbankaccount, 500);

            //Assert
            Assert.Equal(500, account.Balance);
            Assert.Equal(1500,otherbankaccount.Balance);
        }

        [Fact]
        public void Add_Negative_Funds_ThrowException()
        {
            //Arrange

            var account = new BankAccount(1000);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-100));
           // Assert.Equal(1500, otherbankaccount.Balance);
        }

        [Fact]
        public void Withdraw_Negative_Funds_ThrowExceptio()
        {
            //Arrange

            var account = new BankAccount(1000);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-100));
            // Assert.Equal(1500, otherbankaccount.Balance);
        }

        [Fact]
        public void Transfer__Funds_ToNonExistingAccount_ThrowException()
        {
            //Arrange

            var account = new BankAccount(1000);
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null,100));
            // Assert.Equal(1500, otherbankaccount.Balance);
        }
    }
}