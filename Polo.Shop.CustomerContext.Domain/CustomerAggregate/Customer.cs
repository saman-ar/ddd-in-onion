using System;
using System.Collections.Generic;
using System.Text;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Exceptions;
namespace Polo.Shop.CustomerContext.Domain.CustomerAggregate
{
    public class Customer
    {
        private string _userName;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;

        public Customer(string userName, string email, string password, string firstName, string lastName)
        {
            SetUserName(userName);
            SetEmail(email);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPassword(password);
        }

        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; private set; }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new PasswordRequiredException();

            if (password.Length < 8)
                throw new PasswordLengthValidationException();

            Password = password;
        }

        private void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new LastNameRequiredException();

            LastName = lastName;
        }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new FirstNameRequiredException();

            FirstName = firstName;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new EmailRequiredException();
            if (!email.Contains("@"))
                throw new CkeckEmailPatternException();
            Email = email;
        }

        private void SetUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new UserNameRequiredException();

            UserName = userName;
        }

    }
}
