using System;
using System.Collections.Generic;
using Polo.Framework.Core;
using Polo.Framework.Core.Security;
using Polo.Framework.Domain;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Exceptions;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services;

namespace Polo.Shop.CustomerContext.Domain.CustomerAggregate
{
    public class Customer : EntityBase
    {
        private string _userName;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;
        private readonly INationalCodeDublicationChecker _nationalCodeDublicationChecker;
        private readonly IPasswordHasher _passwordHasher;

        public Customer(
            INationalCodeDublicationChecker nationalCodeDublicationChecker,
            IPasswordHasher passwordHasher,
            //string userName,
            string email,
            string password,
            string firstName,
            string lastName,
            string nationalCode)
        {
            _nationalCodeDublicationChecker = nationalCodeDublicationChecker;
            _passwordHasher = passwordHasher;

            //SetUserName(userName);
            SetEmail(email);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPassword(password);
            SetNationalCode(nationalCode);
        }

        
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public ICollection<Address> Addresses { get; private set; }


        public void AddAddress(Address address)
        {
            //Do checking some invariants
            Addresses.Add(address);
        }

        private void SetNationalCode(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
                throw new NationalCodeRequiredException();

            if (_nationalCodeDublicationChecker.IsDublicated(nationalCode))
                throw new NationalCodeDublicatedException();

            NationalCode = nationalCode;
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new PasswordRequiredException();

            if (password.Length < 8)
                throw new PasswordLengthValidationException();

            Password = _passwordHasher.Hash(password, Id.ToString());
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
                throw new CheckEmailPatternException();

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
