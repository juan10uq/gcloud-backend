using System;
using System.Collections.Generic;
using System.Linq;
using GCloud.Models;

namespace GCloud.DataAccess.EF.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GCloudContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GCloudContext context)
        {

              var countries = new List<Country>
              {
                  new Country { Name = "Afghanistan", Code = "AF", CurrencyCode = "AFN", CurrencyName = "Afghani"},
                  new Country { Name = "Albania", Code = "AL", CurrencyCode = "ALL", CurrencyName = "Lek"},
                  new Country { Name = "Algeria", Code = "DZ", CurrencyName = "Dinar", CurrencyCode = "DZD"},
                  new Country { Name = "Andorra", Code = "AD", CurrencyName = "Peseta", CurrencyCode = "ADP"},
                  new Country { Name = "Angola", Code = "AO", CurrencyName = "Kwanza", CurrencyCode = "AOK"},
                  new Country { Name = "Costa Rica", Code = "CR", CurrencyName = "Colon", CurrencyCode = "CRC" },
                  new Country { Name = "Mexico", Code = "MX", CurrencyName = "Peso", CurrencyCode = "MXN" }
              };
              countries.ForEach(s => context.Countries.AddOrUpdate(c => c.Code, s));
              context.SaveChanges();

              //http://snipplr.com/view/54595/currencysql/
             var currencies = new List<Currency>
            {
                new Currency { Name = "Costa Rican Colon", Code = "CRC"},
                new Currency { Name = "Euro", Code = "EUR"},
                new Currency { Name = "Argentine Peso", Code = "ARS"},
                new Currency { Name = "Australian Dollar", Code = "AUD"},
                new Currency { Name = "US Dollar", Code = "USD"},
                new Currency { Name = "Mexican Peso", Code = "MXP"},
                new Currency { Name = "Nicaraguan Cordoba", Code = "NIO"}
            };
            currencies.ForEach(s => context.Currencies.AddOrUpdate(c => c.Code, s));
            context.SaveChanges();


            var periods = new List<FrequencyPeriod>
            {
                new FrequencyPeriod { Name = "Day", Code = "DY"},
                new FrequencyPeriod { Name = "Week", Code = "WK" },
                new FrequencyPeriod { Name = "Month", Code = "MH" },
                new FrequencyPeriod { Name = "Quarter", Code = "QR"},
                new FrequencyPeriod { Name = "Fortnight", Code = "FT"},
                new FrequencyPeriod { Name = "Semester", Code = "SR"},
                new FrequencyPeriod { Name = "Trimester", Code = "TR"},
                new FrequencyPeriod { Name = "Anual", Code = "AL"}
            };
            periods.ForEach(s => context.FrequencyPeriods.AddOrUpdate(c => c.Code, s));
            context.SaveChanges();


            var paymentTyes = new List<PaymentType>
            {
                new PaymentType { Name = "Cash", Code = "CH", PaymentCategory = PaymentCategory.General},
                new PaymentType { Name = "Cheque", Code = "CE", PaymentCategory = PaymentCategory.General},
                new PaymentType { Name = "Credit Card", Code = "CD", PaymentCategory = PaymentCategory.General },
                new PaymentType { Name = "EFTPOS", Code = "ES", PaymentCategory = PaymentCategory.General },
                new PaymentType { Name = "Finance", Code = "FE", PaymentCategory = PaymentCategory.General },
                new PaymentType { Name = "Voucher", Code = "VR", PaymentCategory = PaymentCategory.General },
                new PaymentType { Name = "Credit Note", Code = "CN", PaymentCategory = PaymentCategory.General, },
                new PaymentType { Name = "Cash (Concealed totals)", Code = "CCT", PaymentCategory = PaymentCategory.General }
            };

            paymentTyes.ForEach(s => context.PaymentTypes.AddOrUpdate(c => c.Code, s));
            context.SaveChanges();


            var crId = countries.Single(s => s.Code == "CR").Id;
            var mxId = countries.Single(s => s.Code == "MX").Id;

             var tenants = new List<Tenant>
              {
                  new Tenant { Name = "Fitness Santa Rosa", Active = true, CreateDate = DateTime.Now, CountryId = countries.Single(s => s.Code == "CR").Id, CurrencyId = currencies.Single(s => s.Code == "CRC").Id, TenantState = TenantState.Active},
                  new Tenant { Name = "Strong Gym", Active = true, CreateDate = DateTime.Now, CountryId = countries.Single(s => s.Code == "CR").Id, CurrencyId = currencies.Single(s => s.Code == "CRC").Id, TenantState = TenantState.Active},
                  new Tenant { Name = "Spa Gym", Active = true, CreateDate = DateTime.Now, CountryId = countries.Single(s => s.Code == "CR").Id, CurrencyId = currencies.Single(s => s.Code == "CRC").Id, TenantState = TenantState.Active}
              };
              tenants.ForEach(s => context.Tenants.AddOrUpdate(p => p.Name, s));
              context.SaveChanges();


              var tenantFitnesssrId = tenants.Single(s => s.Name == "Fitness Santa Rosa").Id;
              var tenantStrongId = tenants.Single(s => s.Name == "Strong Gym").Id;
              var tenantSpaId = tenants.Single(s => s.Name == "Spa Gym").Id;


              var gyms = new List<Gym>
              {
                  new Gym { Name = "Fitness Santa Rosa", Active = true, CurrencyId = currencies.Single(s => s.Code == "CRC").Id,  CountryId = countries.Single(s => s.Code == "CR").Id, TenantId = tenantFitnesssrId },
                  new Gym { Name = "Strong Gym", Active = true, CurrencyId = currencies.Single(s => s.Code == "CRC").Id,  CountryId = countries.Single(s => s.Code == "CR").Id, TenantId = tenantStrongId },
                  new Gym { Name = "Spa Gym", Active = true, CurrencyId = currencies.Single(s => s.Code == "CRC").Id, CountryId = countries.Single(s => s.Code == "CR").Id, TenantId = tenantSpaId}
              };
              gyms.ForEach(s => context.Gyms.AddOrUpdate(p => p.Name, s));
              context.SaveChanges();

              var userGuid = Guid.NewGuid();

              var customers = new List<Customer>
              {
                  //Fitness Santa Rosa
                  new Customer { Name = "Carson", Gender  = Gender.Male, LastName = "Alexander", TenantId = tenantFitnesssrId, Identification = "208790458", IdentificationType = IdentificationType.National, Card = 1, Birthday = new DateTime(1990, 2, 4, 5, 4, 8), State = State.Active,Email = "ngh@gmail.com", AllowNotifications = true, NacionalityId = crId, Note = "I will start to workout next friday", Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Meredith", Gender  = Gender.Female , LastName = "Alonso", TenantId = tenantFitnesssrId, Identification = "108790258", IdentificationType = IdentificationType.National, Card = 2, Birthday = new DateTime(1987, 3, 6, 5, 4, 8),State = State.Inactive,Email = "jadd@gmail.com", AllowNotifications = true,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Arturo",  Gender  = Gender.Male,  LastName = "Anand",  TenantId = tenantFitnesssrId, Identification = "408790456", IdentificationType = IdentificationType.National, Card = 3, Birthday = new DateTime(1998, 5, 4, 5, 4, 8),State = State.Moroso, Email = "asdf@gmail.com",AllowNotifications = false,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Gytis", Gender  = Gender.Male,    LastName = "Barzdukas", TenantId = tenantFitnesssrId, Identification =  "308590654", IdentificationType = IdentificationType.National, Card = 4, Birthday = new DateTime(1984, 7, 2, 5, 4, 8),State = State.Active,Email = "hrr@gmail.com", AllowNotifications = true,NacionalityId = mxId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Yan",   Gender  = Gender.Male,    LastName = "Li", TenantId = tenantFitnesssrId, Identification =  "201230456", IdentificationType = IdentificationType.National, Card = 5, Birthday = new DateTime(1980, 5, 9, 5, 4, 8),State = State.Active,Email = "asdf@gmail.com", AllowNotifications = true,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Peggy",  Gender  = Gender.Female ,   LastName = "Justice", TenantId = tenantFitnesssrId, Identification =  "208260167", IdentificationType = IdentificationType.Resident, Card = 6, Birthday = new DateTime(1991, 4, 2, 5, 4, 8),State = State.Moroso,Email = "hdh@gmail.com", AllowNotifications = false,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Laura", Gender  = Gender.Female,    LastName = "Norman", TenantId = tenantFitnesssrId, Identification = "508240467", IdentificationType = IdentificationType.Passport, Card = 7, Birthday = new DateTime(1992, 2, 2, 5, 4, 8),State = State.Active, Email = "frtr@gmail.com",AllowNotifications = false,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Nino", Gender  = Gender.Male,     LastName = "Olivetto", TenantId = tenantFitnesssrId, Identification = "301570987", IdentificationType = IdentificationType.Passport, Card = 8, Birthday = new DateTime(1990, 2, 4, 5, 4, 8),State = State.Active, Email = "ewqt@gmail.com",AllowNotifications = true,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  //Strong Gym
                  new Customer { Name = "Carlos", Gender  = Gender.Male, LastName = "Alexander", TenantId = tenantStrongId, Identification = "208790458", IdentificationType = IdentificationType.National, Card = 1, Birthday = new DateTime(1990, 2, 4, 5, 4, 8), State = State.Active,Email = "ngh@gmail.com", AllowNotifications = true, NacionalityId = crId, Note = "I will start to workout next friday", Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Andreina", Gender  = Gender.Female , LastName = "Alonso", TenantId = tenantStrongId, Identification = "108790258", IdentificationType = IdentificationType.National, Card = 2, Birthday = new DateTime(1987, 3, 6, 5, 4, 8),State = State.Inactive,Email = "jadd@gmail.com", AllowNotifications = true,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Maicol",  Gender  = Gender.Male,  LastName = "Anand",  TenantId = tenantStrongId, Identification = "408790456", IdentificationType = IdentificationType.National, Card = 3, Birthday = new DateTime(1998, 5, 4, 5, 4, 8),State = State.Moroso, Email = "asdf@gmail.com",AllowNotifications = false,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Miguel", Gender  = Gender.Male,    LastName = "Barzdukas", TenantId = tenantStrongId, Identification =  "308590654", IdentificationType = IdentificationType.National, Card = 4, Birthday = new DateTime(1984, 7, 2, 5, 4, 8),State = State.Active,Email = "hrr@gmail.com", AllowNotifications = true,NacionalityId = mxId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Manuel",   Gender  = Gender.Male,    LastName = "Li", TenantId = tenantStrongId, Identification =  "201230456", IdentificationType = IdentificationType.National, Card = 5, Birthday = new DateTime(1980, 5, 9, 5, 4, 8),State = State.Active,Email = "asdf@gmail.com", AllowNotifications = true,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Heidy",  Gender  = Gender.Female ,   LastName = "Justice", TenantId = tenantStrongId, Identification =  "208260167", IdentificationType = IdentificationType.Resident, Card = 6, Birthday = new DateTime(1991, 4, 2, 5, 4, 8),State = State.Moroso,Email = "hdh@gmail.com", AllowNotifications = false,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Nena", Gender  = Gender.Female,    LastName = "Norman", TenantId = tenantStrongId, Identification = "508240467", IdentificationType = IdentificationType.Passport, Card = 7, Birthday = new DateTime(1992, 2, 2, 5, 4, 8),State = State.Active, Email = "frtr@gmail.com",AllowNotifications = false,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Diego", Gender  = Gender.Male,     LastName = "Olivetto", TenantId = tenantStrongId, Identification = "301570987", IdentificationType = IdentificationType.Passport, Card = 8, Birthday = new DateTime(1990, 2, 4, 5, 4, 8),State = State.Active, Email = "ewqt@gmail.com",AllowNotifications = true,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },

                   //Spa Gym
                  new Customer { Name = "Juan", Gender  = Gender.Male, LastName = "Alexander", TenantId = tenantSpaId, Identification = "208790458", IdentificationType = IdentificationType.National, Card = 1, Birthday = new DateTime(1990, 2, 4, 5, 4, 8), State = State.Active,Email = "ngh@gmail.com", AllowNotifications = true, NacionalityId = crId, Note = "I will start to workout next friday", Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Karla", Gender  = Gender.Female , LastName = "Alonso", TenantId = tenantSpaId, Identification = "108790258", IdentificationType = IdentificationType.National, Card = 2, Birthday = new DateTime(1987, 3, 6, 5, 4, 8),State = State.Inactive,Email = "jadd@gmail.com", AllowNotifications = true,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Francisco",  Gender  = Gender.Male,  LastName = "Anand",  TenantId = tenantSpaId, Identification = "408790456", IdentificationType = IdentificationType.National, Card = 3, Birthday = new DateTime(1998, 5, 4, 5, 4, 8),State = State.Moroso, Email = "asdf@gmail.com",AllowNotifications = false,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Abrhaman", Gender  = Gender.Male,    LastName = "Barzdukas", TenantId = tenantSpaId, Identification =  "308590654", IdentificationType = IdentificationType.National, Card = 4, Birthday = new DateTime(1984, 7, 2, 5, 4, 8),State = State.Active,Email = "hrr@gmail.com", AllowNotifications = true,NacionalityId = mxId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Elberth",   Gender  = Gender.Male,    LastName = "Li", TenantId = tenantSpaId, Identification =  "201230456", IdentificationType = IdentificationType.National, Card = 5, Birthday = new DateTime(1980, 5, 9, 5, 4, 8),State = State.Active,Email = "asdf@gmail.com", AllowNotifications = true,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Melissa",  Gender  = Gender.Female ,   LastName = "Justice", TenantId = tenantSpaId, Identification =  "208260167", IdentificationType = IdentificationType.Resident, Card = 6, Birthday = new DateTime(1991, 4, 2, 5, 4, 8),State = State.Moroso,Email = "hdh@gmail.com", AllowNotifications = false,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Lucia", Gender  = Gender.Female,    LastName = "Norman", TenantId = tenantSpaId, Identification = "508240467", IdentificationType = IdentificationType.Passport, Card = 7, Birthday = new DateTime(1992, 2, 2, 5, 4, 8),State = State.Active, Email = "frtr@gmail.com",AllowNotifications = false,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                  new Customer { Name = "Jose", Gender  = Gender.Male,     LastName = "Olivetto", TenantId = tenantSpaId, Identification = "301570987", IdentificationType = IdentificationType.Passport, Card = 8, Birthday = new DateTime(1990, 2, 4, 5, 4, 8),State = State.Active, Email = "ewqt@gmail.com",AllowNotifications = true,NacionalityId = crId,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid }
              };
              customers.ForEach(s => context.Customers.AddOrUpdate(p => new { p.Name, p.TenantId }, s));
              context.SaveChanges();

                var addresses = new List<Address>
                {
                    //Fitness Santa Rosa
                    new Address { Address1 = "El estadio",  TenantId = tenantFitnesssrId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Nino").Id, PostalCode = "10101", Primary = true, AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantFitnesssrId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Carson").Id, PostalCode = "10102", Primary = true, AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantFitnesssrId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Meredith").Id, PostalCode = "10103", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantFitnesssrId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Arturo").Id, PostalCode = "10104", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantFitnesssrId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Gytis").Id, PostalCode = "10105", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantFitnesssrId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Yan").Id, PostalCode = "10106", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantFitnesssrId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Peggy").Id, PostalCode = "10107", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantFitnesssrId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Laura").Id, PostalCode = "10108", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    //Strong Gym
                    new Address { Address1 = "El estadio",  TenantId = tenantStrongId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Carlos").Id, PostalCode = "10101", Primary = true, AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantStrongId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Andreina").Id, PostalCode = "10102", Primary = true, AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantStrongId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Maicol").Id, PostalCode = "10103", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantStrongId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Miguel").Id, PostalCode = "10104", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantStrongId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Manuel").Id, PostalCode = "10105", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantStrongId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Heidy").Id, PostalCode = "10106", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantStrongId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Nena").Id, PostalCode = "10107", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantStrongId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Diego").Id, PostalCode = "10108", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },

                     //Spa Gym
                    new Address { Address1 = "El estadio",  TenantId = tenantSpaId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Juan").Id, PostalCode = "10101", Primary = true, AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantSpaId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Karla").Id, PostalCode = "10102", Primary = true, AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantSpaId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Francisco").Id, PostalCode = "10103", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantSpaId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Abrhaman").Id, PostalCode = "10104", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantSpaId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Elberth").Id, PostalCode = "10105", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantSpaId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Melissa").Id, PostalCode = "10106", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantSpaId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Lucia").Id, PostalCode = "10107", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new Address { Address1 = "El estadio",  TenantId = tenantSpaId, CountryId = crId, CustomerId = customers.Single(s => s.Name == "Jose").Id, PostalCode = "10108", Primary = true,AddressType = AddressType.Physical, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid }
                };
                addresses.ForEach(s => context.Addresses.AddOrUpdate(p => new { p.PostalCode, p.TenantId }, s));
                context.SaveChanges();

            /*****Security**********************************/
              var roles = new List<Rol>
              {
                  new Rol { Name = "Admin"},
                  new Rol { Name = "Manager"},
                  new Rol { Name = "Cashier"}
              };

              roles.ForEach(r => context.Roles.AddOrUpdate(ro => new { ro.Name}, r));
              context.SaveChanges();

            var rolAdmin = roles.Single(r => r.Name == "Admin");
            var rolManager = roles.Single(r => r.Name == "Manager");
            var rolCashier = roles.Single(r => r.Name == "Cashier");


              var users = new List<User>
              {
                  new User { UserName = "ngonzalez@fitness.com", Name = "Nelson", LastName  = "Gonzalez", Email = "ngonzalez@fitness.com", TenantId = tenantFitnesssrId, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                  new User { UserName = "jugalde@fitness.com", Name = "Juan", LastName  = "Ugalde", Email = "jugalde@fitness.com", TenantId = tenantFitnesssrId, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                  new User { UserName = "aesquivel@fitness.com", Name = "Andreina", LastName  = "Esquivel", Email = "aesquivel@fitness.com", TenantId = tenantFitnesssrId, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},

                  new User { UserName = "ngonzalez@spa.com", Name = "Nelson", LastName  = "Gonzalez", Email = "ngonzalez@spa.com", TenantId = tenantSpaId, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                  new User { UserName = "jugalde@spa.com", Name = "Juan", LastName  = "Ugalde", Email = "jugalde@wearegap.spa",  TenantId = tenantSpaId, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                  new User { UserName = "aesquivel@spa.com", Name = "Andreina", LastName  = "Esquivel", Email = "aesquivel@spa.com",  TenantId = tenantSpaId, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},

                   new User { UserName = "ngonzalez@strong.com", Name = "Nelson", LastName  = "Gonzalez", Email = "ngonzalez@strong.com", TenantId = tenantStrongId, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                  new User { UserName = "jugalde@strong.com", Name = "Juan", LastName  = "Ugalde", Email = "jugalde@strong.com",  TenantId = tenantStrongId, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                  new User { UserName = "aesquivel@strong.com", Name = "Andreina", LastName  = "Esquivel", Email = "aesquivel@strong.com",  TenantId = tenantStrongId, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
              };

              users.ForEach(u => context.Users.AddOrUpdate(user => new { user.Name, user.TenantId }, u));
              context.SaveChanges();

            var userNelsonStrong = users.Single(r => r.Name == "Nelson" && r.TenantId == tenantStrongId);
            var userJuanStrong = users.Single(r => r.Name == "Juan" && r.TenantId == tenantStrongId);
            var userAndreStrong = users.Single(r => r.Name == "Andreina" && r.TenantId == tenantStrongId);

            var userNelsonSpa = users.Single(r => r.Name == "Nelson" && r.TenantId == tenantSpaId);
            var userJuanSpa = users.Single(r => r.Name == "Juan" && r.TenantId == tenantSpaId);
            var userAndreSpa = users.Single(r => r.Name == "Andreina" && r.TenantId == tenantSpaId);

            var userNelsonFitnessr = users.Single(r => r.Name == "Nelson" && r.TenantId == tenantFitnesssrId);
            var userJuanFitnesssr = users.Single(r => r.Name == "Juan" && r.TenantId == tenantFitnesssrId);
            var userAndreFitnessr = users.Single(r => r.Name == "Andreina" && r.TenantId == tenantFitnesssrId);


            userNelsonStrong.Roles.Add(rolAdmin);
            userJuanStrong.Roles.Add(rolManager);
            userAndreStrong.Roles.Add(rolCashier);

            userNelsonSpa.Roles.Add(rolAdmin);
            userJuanSpa.Roles.Add(rolManager);
            userAndreSpa.Roles.Add(rolCashier);

            userNelsonFitnessr.Roles.Add(rolAdmin);
            userJuanFitnesssr.Roles.Add(rolManager);
            userAndreFitnessr.Roles.Add(rolCashier);

            context.SaveChanges();
            /************End Security*********************/

            /*****Phone Numbers******/

              var phones = new List<PhoneNumber>
                {
                    //Fitness Santa Rosa
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  CustomerId = customers.Single(s => s.Name == "Nino").Id, Number = "88798574", Primary = true, PhoneType = PhoneType.Mobil,Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  CustomerId = customers.Single(s => s.Name == "Carson").Id, Number = "85478963", Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  CustomerId = customers.Single(s => s.Name == "Meredith").Id, Number = "57489632",  Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  CustomerId = customers.Single(s => s.Name == "Arturo").Id, Number = "25874691", Primary = true, PhoneType = PhoneType.Home,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  CustomerId = customers.Single(s => s.Name == "Gytis").Id, Number = "35874196", Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  CustomerId = customers.Single(s => s.Name == "Yan").Id, Number = "78965874", Primary = true, PhoneType = PhoneType.Mobil, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  CustomerId = customers.Single(s => s.Name == "Peggy").Id, Number = "25789687", Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  CustomerId = customers.Single(s => s.Name == "Laura").Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                    //Fitness Santa Rosa Users
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  UserId = userNelsonFitnessr.Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  UserId = userJuanFitnesssr.Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantFitnesssrId,  UserId = userAndreFitnessr.Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},


                    //Strong Gym
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  CustomerId = customers.Single(s => s.Name == "Carlos").Id, Number = "88798574", Primary = true, PhoneType = PhoneType.Mobil,Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  CustomerId = customers.Single(s => s.Name == "Andreina").Id, Number = "85478963", Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  CustomerId = customers.Single(s => s.Name == "Maicol").Id, Number = "57489632",  Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  CustomerId = customers.Single(s => s.Name == "Miguel").Id, Number = "25874691", Primary = true, PhoneType = PhoneType.Home,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  CustomerId = customers.Single(s => s.Name == "Heidy").Id, Number = "35874196", Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  CustomerId = customers.Single(s => s.Name == "Nena").Id, Number = "78965874", Primary = true, PhoneType = PhoneType.Mobil, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  CustomerId = customers.Single(s => s.Name == "Manuel").Id, Number = "25789687", Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  CustomerId = customers.Single(s => s.Name == "Diego").Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},

                    //Strong Gym Users
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  UserId = userNelsonStrong.Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  UserId = userJuanStrong.Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantStrongId,  UserId = userAndreStrong.Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                    
                    //Spa Gym
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  CustomerId = customers.Single(s => s.Name == "Juan").Id, Number = "88798574", Primary = true, PhoneType = PhoneType.Mobil,Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  CustomerId = customers.Single(s => s.Name == "Karla").Id, Number = "85478963", Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  CustomerId = customers.Single(s => s.Name == "Francisco").Id, Number = "57489632",  Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  CustomerId = customers.Single(s => s.Name == "Abrhaman").Id, Number = "25874691", Primary = true, PhoneType = PhoneType.Home,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  CustomerId = customers.Single(s => s.Name == "Elberth").Id, Number = "35874196", Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  CustomerId = customers.Single(s => s.Name == "Melissa").Id, Number = "78965874", Primary = true, PhoneType = PhoneType.Mobil, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  CustomerId = customers.Single(s => s.Name == "Lucia").Id, Number = "25789687", Primary = true, PhoneType = PhoneType.Mobil,  Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid },
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  CustomerId = customers.Single(s => s.Name == "Jose").Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                   //Spa Gym Users
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  UserId = userNelsonSpa.Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  UserId = userJuanSpa.Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                    new PhoneNumber { AreaCode = "506",  TenantId = tenantSpaId,  UserId = userAndreSpa.Id, Number = "17896541", Primary = true,  PhoneType = PhoneType.Work, Active = true, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, CreatedBy = userGuid, UpdatedBy = userGuid},
                    
                };
              phones.ForEach(s => context.PhoneNumbers.AddOrUpdate(p => new { p.Number, p.TenantId }, s));
              context.SaveChanges();
            /****End Phone Numbers***/


        }
    }
}
