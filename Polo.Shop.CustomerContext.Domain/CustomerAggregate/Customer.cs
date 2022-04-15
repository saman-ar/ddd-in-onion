using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Polo.Framework.Core.Domain;
using Polo.Framework.Core.Security;
using Polo.Framework.Domain;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Exceptions;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services;

namespace Polo.Shop.CustomerContext.Domain.CustomerAggregate
{
   public class Customer : EntityBase, IAggregateRoot<Customer>
   {
      //private string _userName;
      //private string _password;
      //private string _firstName;
      //private string _lastName;
      //private string _email;

      private List<Address> _addresses;
      private readonly INationalCodeDublicationChecker _nationalCodeDublicationChecker;
      private readonly IPasswordHasher _passwordHasher;

      public Customer()
      {
         _addresses = new List<Address>();
      }

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
         _addresses = new List<Address>();

      }

      public string UserName { get; private set; }
      public string Email { get; private set; }
      public string Password { get; private set; }
      public string FirstName { get; private set; }
      public string LastName { get; private set; }
      public string NationalCode { get; private set; }
      public int Score { get; private set; }
      public IReadOnlyList<Address> Addresses => _addresses.AsReadOnly();

      public void AddAddress(Address address)
      {
         
         //Do checking some invariants
         _addresses.Add(address);
      }

      public void UpdateScore(int score)
      {
         Score += score;
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

      public IEnumerable<Expression<Func<Customer, object>>> GetIncludeExpression()
      {
         yield return c => c.Addresses;


      }
   }
}
