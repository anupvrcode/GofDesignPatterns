﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    public class Program
    {

        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            Console.WriteLine("------------------------------------State Pattern----------------------------------------------------------------------");
            Console.WriteLine("Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.");
            Console.WriteLine("Participants");
            Console.WriteLine("Context  (Account) ");
            Console.WriteLine("     defines the interface of interest to clients ");
            Console.WriteLine("     maintains an instance of a ConcreteState subclass that defines the current state. ");
            Console.WriteLine("State  (State) ");
            Console.WriteLine("     defines an interface for encapsulating the behavior associated with a particular state of the Context. ");
            Console.WriteLine("Concrete State  (RedState, SilverState, GoldState) ");
            Console.WriteLine("     each subclass implements a behavior associated with a state of Context.");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            // Open a new account
            
            Account account = new Account("Jim Johnson");



            // Apply financial transactions
            
            account.Deposit(500.0);

            account.Deposit(300.0);

            account.Deposit(550.0);

            account.PayInterest();

            account.Withdraw(2000.00);

            account.Withdraw(1100.00);



            // Wait for user

            Console.ReadKey();

        }

    }



    /// <summary>

    /// The 'State' abstract class

    /// </summary>

    abstract class State
    {

        protected Account account;

        protected double balance;



        protected double interest;

        protected double lowerLimit;

        protected double upperLimit;

        public State()
        {
            Console.WriteLine("Any State will  have an account associated.");
        }

        // Properties

        public Account Account
        {

            get { return account; }

            set { account = value; }

        }



        public double Balance
        {

            get { return balance; }

            set { balance = value; }

        }



        public abstract void Deposit(double amount);

        public abstract void Withdraw(double amount);

        public abstract void PayInterest();

    }





    /// <summary>

    /// A 'ConcreteState' class

    /// <remarks>

    /// Red indicates that account is overdrawn 

    /// </remarks>

    /// </summary>

    class RedState : State
    {

        private double _serviceFee;



        // Constructor

        public RedState(State state)
        {

            this.balance = state.Balance;

            this.account = state.Account;

            Initialize();

        }



        private void Initialize()
        {

            // Should come from a datasource

            interest = 0.0;

            lowerLimit = -100.0;

            upperLimit = 0.0;

            _serviceFee = 15.00;

        }



        public override void Deposit(double amount)
        {

            balance += amount;
            Console.WriteLine("Checking whether to change state for Deposit.");
            StateChangeCheck();

        }



        public override void Withdraw(double amount)
        {

            amount = amount - _serviceFee;

            Console.WriteLine("No funds available for withdrawal in RedState!");

        }



        public override void PayInterest()
        {
            Console.WriteLine("No Interset paid in RedState.");
            // No interest is paid

        }



        private void StateChangeCheck()
        {

            if (balance > upperLimit)
            {

                account.State = new SilverState(this);

            }

        }

    }



    /// <summary>

    /// A 'ConcreteState' class

    /// <remarks>

    /// Silver indicates a non-interest bearing state

    /// </remarks>

    /// </summary>

    class SilverState : State
    {

        // Overloaded constructors



        public SilverState(State state) :

            this(state.Balance, state.Account)
        {

        }



        public SilverState(double balance, Account account)
        {
            Console.WriteLine("Creating SilverState");
            this.balance = balance;

            this.account = account;

            Initialize();

        }



        private void Initialize()
        {
            Console.WriteLine("For SilverState interest is 0,lower limit is 0, upperlimit is 1000");
            // Should come from a datasource

            interest = 0.0;

            lowerLimit = 0.0;

            upperLimit = 1000.0;

        }



        public override void Deposit(double amount)
        {

            balance += amount;
            Console.WriteLine("Checking whether to change state for Deposit.");
            StateChangeCheck();

        }



        public override void Withdraw(double amount)
        {

            balance -= amount;
            Console.WriteLine("Checking whether to change state for WithDraw.");
            StateChangeCheck();

        }



        public override void PayInterest()
        {

            balance += interest * balance;
            Console.WriteLine("Checking whether to change state for PayInterest.");
            StateChangeCheck();

        }



        private void StateChangeCheck()
        {
            Console.WriteLine("Check for Balance.");
            if (balance <= lowerLimit)
            {
                Console.WriteLine("If balance is less than lower limit, change the associated account to RedState.");
                account.State = new RedState(this);

            }

            else if (balance >= upperLimit)
            {
                Console.WriteLine("If balance is greater than upper limit, change the associated account to GoldState.");
                account.State = new GoldState(this);

            }

        }

    }



    /// <summary>

    /// A 'ConcreteState' class

    /// <remarks>

    /// Gold indicates an interest bearing state

    /// </remarks>

    /// </summary>

    class GoldState : State
    {

        // Overloaded constructors

        public GoldState(State state)

            : this(state.Balance, state.Account)
        {

        }



        public GoldState(double balance, Account account)
        {
            Console.WriteLine("Creating GoldState");
            this.balance = balance;

            this.account = account;

            Initialize();

        }



        private void Initialize()
        {
            Console.WriteLine("For GoldState interest is 0.05,lower limit is 1000, upperlimit is 10000000");
            // Should come from a database

            interest = 0.05;

            lowerLimit = 1000.0;

            upperLimit = 10000000.0;

        }



        public override void Deposit(double amount)
        {

            balance += amount;
            Console.WriteLine("Checking whether to change state for Deposit.");
            StateChangeCheck();

        }



        public override void Withdraw(double amount)
        {

            balance -= amount;
            Console.WriteLine("Checking whether to change state for Withdraw.");
            StateChangeCheck();

        }



        public override void PayInterest()
        {

            balance += interest * balance;
            Console.WriteLine("Checking whether to change state for PayInterest.");
            StateChangeCheck();

        }



        private void StateChangeCheck()
        {
            Console.WriteLine("Check for Balance.");
            if (balance <= 0.0)
            {
                Console.WriteLine("If balance is less than 0, change the associated account to RedState.");
                account.State = new RedState(this);

            }

            else if (balance < lowerLimit)
            {
                Console.WriteLine("If balance is less than lower limit, change the associated account to RedState.If not continue in GoldState");
                account.State = new SilverState(this);

            }

        }

    }



    /// <summary>

    /// The 'Context' class

    /// </summary>

    class Account
    {

        private State _state;

        private string _owner;



        // Constructor

        public Account(string owner)
        {
            Console.WriteLine("Creating the instance of Context class Account.By default State of the account is Silver");
            // New accounts are 'Silver' by default

            this._owner = owner;

            this._state = new SilverState(0.0, this);

        }



        // Properties

        public double Balance
        {

            get { return _state.Balance; }

        }



        public State State
        {

            get { return _state; }

            set { _state = value; }

        }



        public void Deposit(double amount)
        {

            _state.Deposit(amount);

            Console.WriteLine("Deposited {0:C} --- ", amount);

            Console.WriteLine(" Balance = {0:C}", this.Balance);

            Console.WriteLine(" Status = {0}",

              this.State.GetType().Name);

            Console.WriteLine("");

        }



        public void Withdraw(double amount)
        {

            _state.Withdraw(amount);

            Console.WriteLine("Withdrew {0:C} --- ", amount);

            Console.WriteLine(" Balance = {0:C}", this.Balance);

            Console.WriteLine(" Status = {0}\n",

              this.State.GetType().Name);

        }



        public void PayInterest()
        {

            _state.PayInterest();

            Console.WriteLine("Interest Paid --- ");

            Console.WriteLine(" Balance = {0:C}", this.Balance);

            Console.WriteLine(" Status = {0}\n",

              this.State.GetType().Name);

        }

    }


}
