using Quote2Invoice.UI.Models.Orders.InputModels;
using Quote2Invoice.UI.Models.Orders.RequestModels;
using Quote2Invoice.UI.Models.Orders.ResponseModels;
using Quote2Invoice.UI.Models.Security.Authenticate.RequestModels;
using Quote2Invoice.UI.Models.Security.Authenticate.ResponseModels;
using System;
using System.Collections.Generic;

namespace Quote2Invoice.UI.Shared.WebApiCaller
{
  public class MockWebApi
  {
    public List<MockApiResponseModel> Responses;

    public MockWebApi()
    {
      Responses = new List<MockApiResponseModel>();
      ConfigureMock_RoleController_Responses();
    }

    public void ConfigureMock_RoleController_Responses()
    {
      // WebApi:Login
      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:Login",
        RequestModel = new LoginRequestModel
        {
          Username = "zunaid",
          Password = "111111",
          Browser = "Unable to determine",
          Device = "Unable to determine",
        },
        ResponseContent = new UserModel
        {
          Username = "zunaid",
          ApiSessionToken = Guid.NewGuid().ToString(),
          IsAuthenticated = true,
          CompanyProfileId = 1
        }
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:Login",
        RequestModel = new LoginRequestModel
        {
          Username = "rowena",
          Password = "111111",
          Browser = "Unable to determine",
          Device = "Unable to determine",
        },
        ResponseContent = new UserModel
        {
          Username = "rowena",
          ApiSessionToken = Guid.NewGuid().ToString(),
          IsAuthenticated = true,
          CompanyProfileId = 1
        }
      });

      // WebApi:Registration
      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:Register",
        RequestModel = new RegisterUserRequestModel
        {
          Username = "zunaid",
          Password = "111111",
          ConfirmPassword = "111111",
          FirstName = "1",
          LastName = "1",
          EmailAddress = "1@gmail.com",
          Browser = "Unable to determine",
          Device = "Unable to determine",
        },
        ResponseContent = new UserModel
        {
          Username = "zunaid",
          ApiSessionToken = Guid.NewGuid().ToString(),
          IsAuthenticated = true,
          CompanyProfileId = 1
        }
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:Register",
        RequestModel = new RegisterUserRequestModel
        {
          Username = "rowena",
          Password = "111111",
          ConfirmPassword = "111111",
          FirstName = "1",
          LastName = "1",
          EmailAddress = "1@gmail.com",
          Browser = "Unable to determine",
          Device = "Unable to determine",
        },
        ResponseContent = new UserModel
        {
          Username = "rowena",
          ApiSessionToken = Guid.NewGuid().ToString(),
          IsAuthenticated = true,
          CompanyProfileId = 1
        }
      });

      //"WebApi:Home:GetHomerOrders"
      var homeOrdersModels = new List<HomeOrdersModel>
      {
        new HomeOrdersModel
        {
          OrderId = 1, OrderNo = "Moq001", CreateDate = DateTime.Now.AddDays(24).ToShortDateString(), Total = "2 999.99", Status = "ACCEPTED", EmailAddress = "moq1@gmail.com", CustomerName = "Moq Customer 1"
        },
        new HomeOrdersModel
        {
          OrderId = 2, OrderNo = "Moq002", CreateDate = DateTime.Now.AddDays(2).ToShortDateString(), Total = "1 999.99", Status = "ACCEPTED", EmailAddress = "moq2@gmail.com", CustomerName = "Moq Customer 2"
        },
        new HomeOrdersModel
        {
          OrderId = 3, OrderNo = "Moq003", CreateDate = DateTime.Now.AddDays(2).ToShortDateString(), Total = "1 000.99", Status = "PROGRESS", EmailAddress = "moq3@gmail.com", CustomerName = "Moq Customer 3"
        },
        new HomeOrdersModel
        {
          OrderId = 4, OrderNo = "Moq004", CreateDate = DateTime.Now.AddDays(2).ToShortDateString(), Total = "99.99", Status = "ACCEPTED", EmailAddress = "moq4@gmail.com", CustomerName = "Moq Customer 4"
        },
        new HomeOrdersModel
        {
          OrderId = 5, OrderNo = "Moq005", CreateDate = DateTime.Now.AddDays(2).ToShortDateString(), Total = "10 000.99", Status = "PROGRESS", EmailAddress = "moq5@gmail.com", CustomerName = "Moq Customer 5"
        }

      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Home:GetHomeOrders",
        RequestModel = new GetHomeOrdersRequestModel()
        {
          Username = "zunaid",
          CompanyProfileId = 1,
        },
        ResponseContent = homeOrdersModels
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Home:GetHomeOrders",
        RequestModel = new GetHomeOrdersRequestModel()
        {
          Username = "rowena",
          CompanyProfileId = 1,
        },
        ResponseContent = homeOrdersModels
      });

      // WebApi:Home:GetVatRate
      Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:GetVatRate", RequestModel = null, ResponseContent = 0.15M });
      Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:GetOrderNoSeed", RequestModel = new GetCompanyOrderNoSeedRequestModel { CompanyProfileId = 1 }, ResponseContent = 1 });

      // WebApi:Orders:AddOrder
      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddOrder",
        RequestModel = new AddOrderRequestModel
        {
          OrderNo = "1",
          Username = "zunaid",
          CompanyProfileId = 1
        },
        ResponseContent = 1
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddOrder",
        RequestModel = new AddOrderRequestModel
        {
          OrderNo = "1",
          Username = "rowena",
          CompanyProfileId = 1
        },
        ResponseContent = 1
      });

      // WebApi:Orders:GetOrderDetailLineNo
      Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:GetOrderDetailLineNo", RequestModel = new GetOrderDetailLineNoRequestModel { OrderId = 1 }, ResponseContent = 1 });


      // WebApi:Orders:AddOrderDetail
      var addOrderDetailRequest = new List<AddOrderDetailRequestModel>
      {
        new AddOrderDetailRequestModel
        {
          LineNo = 1,
          OrderId = 1,
          ItemDescription = "1",
          UnitPrice = 1M,
          Quantity = 1,
          Discount = 0M,
          LineTotal = 1M,
          Username = "zunaid",
        }
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddOrderDetail",
        RequestModel = addOrderDetailRequest,
        ResponseContent = new ValidationResult()
      });

      addOrderDetailRequest = new List<AddOrderDetailRequestModel>
      {
        new AddOrderDetailRequestModel
        {
          LineNo = 1,
          OrderId = 1,
          ItemDescription = "1",
          UnitPrice = 1M,
          Quantity = 1,
          Discount = 0M,
          LineTotal = 1M,
          Username = "rowena",
        }
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddOrderDetail",
        RequestModel = addOrderDetailRequest,
        ResponseContent = new ValidationResult()
      });

      // WebApi:Orders:GetOrderCustomers
      var responseGetOrderCustomers = new List<CustomerModel>
      {
        new CustomerModel
        {
          CompanyProfileId = 1,
          CustomerId = 1,
          CustomerName = "City of Cape Town",
          CustomerDetails = "Ravensmead Centre c/o Jan Smuts and Gilleger rd",
          AccountNo = "Moq1",
          ContactNo = "0217548899",
          MobileNo = "0214458888",
          EmailAddress = "someemail@capetown.gov.za",
          CreateUser ="zunaid",
          CreateDate = DateTime.Now
        },
        new CustomerModel
        {
          CompanyProfileId = 1,
          CustomerId = 2,
          CustomerName = "The Juggernauts",
          CustomerDetails = "Fantastic Four",
          AccountNo = "Moq2",
          ContactNo = "0213966655",
          MobileNo = "0214458888",
          EmailAddress = "test@capetown.gov.za",
          CreateUser ="zunaid",
          CreateDate = DateTime.Now
        },
        new CustomerModel
        {
          CompanyProfileId = 1,
          CustomerId = 2,
          CustomerName = "Water Inc.",
          CustomerDetails = "Cravenby and Newlands",
          AccountNo = "Moq3",
          ContactNo = "0214458888",
          MobileNo = "0725584589",
          EmailAddress = "mo@capetown.gov.za",
          CreateUser ="zunaid",
          CreateDate = DateTime.Now
        }
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:GetOrderCustomers",
        RequestModel = new GetOrderCustomersRequestModel()
        {
          Username = "zunaid",
          CompanyProfileId = 1
        },
        ResponseContent = responseGetOrderCustomers
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:GetOrderCustomers",
        RequestModel = new GetOrderCustomersRequestModel()
        {
          Username = "rowena",
          CompanyProfileId = 1
        },
        ResponseContent = responseGetOrderCustomers
      });

      // WebApi:Orders:GetOrderCustomerDetail
      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:GetOrderCustomerDetails",
        RequestModel = new GetOrderCustomerDetailRequestModel { OrderId = 1 },
        ResponseContent = null
      });

      // WebApi:Orders:GetCustomerContacts
      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:GetCustomerContacts",
        RequestModel = new GetCustomerContactsRequestModel { CustomerId = 1 },
        ResponseContent = null
      });

      //WebApi: Orders: AddOrderCustomer
      var inputAddOrderCustomer = new AddOrderCustomerRequestModel
      {
        OrderId = 1,
        CustomerId = 0,
        CustomerName = "1",
        CustomerDetails = "1",
        CustomerContactNo = "1",
        CustomerMobileNo = "1",
        CustomerAccountNo = "1",
        CustomerEmailAddress = null,
        ContactId = 0,
        ContactAdded = false,
        ContactEmailAddress = null,
        ContactName = null,
        ContactNo = null,
        CompanyProfileId = 1,
        Username = "zunaid"
      };

      var responseAddOrderCustomer = new AddCustomerOrderModel
      {
        OrderId = 1,
        CustomerId = 1,
        ContactId = 1
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddOrderCustomer",
        RequestModel = inputAddOrderCustomer,
        ResponseContent = responseAddOrderCustomer
      });

      inputAddOrderCustomer = new AddOrderCustomerRequestModel
      {
        OrderId = 1,
        CustomerId = 0,
        CustomerName = "1",
        CustomerDetails = "1",
        CustomerContactNo = "1",
        CustomerMobileNo = "1",
        CustomerAccountNo = "1",
        CustomerEmailAddress = null,
        ContactId = 0,
        ContactAdded = false,
        ContactEmailAddress = null,
        ContactName = null,
        ContactNo = null,
        CompanyProfileId = 1,
        Username = "rowena"
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddOrderCustomer",
        RequestModel = inputAddOrderCustomer,
        ResponseContent = responseAddOrderCustomer
      });

      // WebApi:Orders:GetCustomerAddresses
      var responseGetCustomerAddresses = new List<AddressDetailsModel>
      {
        new AddressDetailsModel
        {
          AddressDetailId = 1,
          AddressType = "Work",
          AddressLine1 = "24 Victoria Street",
          AddressLine2= "Muizenberg",
          City = "Cape Town",
          PostalCode = "7786",
          Country = "South Africa",
          CreateUser = "zunaid",
          CreateDate = DateTime.Now
        },
        new AddressDetailsModel
        {
          AddressDetailId = 2,
          AddressType = "Home",
          AddressLine1 = "24 John Street",
          AddressLine2= "Pelican Park",
          City = "Cape Town",
          PostalCode = "7786",
          Country = "South Africa",
          CreateUser = "zunaid",
          CreateDate = DateTime.Now
        },
        new AddressDetailsModel
        {
          AddressDetailId = 3,
          AddressType = "Delivery",
          AddressLine1 = "City Of Cape Town",
          AddressLine2= "Adderley Street",
          City = "Cape Town",
          PostalCode = "7800",
          Country = "South Africa",
          CreateUser = "zunaid",
          CreateDate = DateTime.Now
        },
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:GetCustomerAddresses",
        RequestModel = new GetCustomerAddressesRequestModel { CustomerId = 1 },
        ResponseContent = responseGetCustomerAddresses
      });

      //// "WebApi:Orders:AddCustomerOrderAddress"
      var requestAddCustomerOrderAddress = new AddCustomerOrderAddressRequestModel
      {
        AddressDetailId = 3,
        AddressType = "Delivery",
        AddressLine1 = "City Of Cape Town",
        AddressLine2 = "Adderley Street",
        City = "Cape Town",
        PostalCode = "7800",
        Country = "South Africa",
        Username = "zunaid",
        CustomerId = 1,
        OrderId = 1
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddCustomerOrderAddress",
        RequestModel = requestAddCustomerOrderAddress,
        ResponseContent = "Success"
      });

      requestAddCustomerOrderAddress = new AddCustomerOrderAddressRequestModel
      {
        AddressDetailId = 3,
        AddressType = "Delivery",
        AddressLine1 = "City Of Cape Town",
        AddressLine2 = "Adderley Street",
        City = "Cape Town",
        PostalCode = "7800",
        Country = "South Africa",
        Username = "rowena",
        CustomerId = 1,
        OrderId = 1
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddCustomerOrderAddress",
        RequestModel = requestAddCustomerOrderAddress,
        ResponseContent = "Success"
      });

      requestAddCustomerOrderAddress = new AddCustomerOrderAddressRequestModel
      {
        AddressDetailId = 2,
        AddressType = "Home",
        AddressLine1 = "24 John Street",
        AddressLine2 = "Pelican Park",
        City = "Cape Town",
        PostalCode = "7786",
        Country = "South Africa",
        Username = "zunaid",
        CustomerId = 1,
        OrderId = 1
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddCustomerOrderAddress",
        RequestModel = requestAddCustomerOrderAddress,
        ResponseContent = "Success"
      });

      requestAddCustomerOrderAddress = new AddCustomerOrderAddressRequestModel
      {
        AddressDetailId = 2,
        AddressType = "Home",
        AddressLine1 = "24 John Street",
        AddressLine2 = "Pelican Park",
        City = "Cape Town",
        PostalCode = "7786",
        Country = "South Africa",
        Username = "rowena",
        CustomerId = 1,
        OrderId = 1
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddCustomerOrderAddress",
        RequestModel = requestAddCustomerOrderAddress,
        ResponseContent = "Success"
      });

      requestAddCustomerOrderAddress = new AddCustomerOrderAddressRequestModel
      {
        AddressDetailId = 1,
        AddressType = "Work",
        AddressLine1 = "24 Victoria Street",
        AddressLine2 = "Muizenberg",
        City = "Cape Town",
        PostalCode = "7786",
        Country = "South Africa",
        Username = "zunaid",
        CustomerId = 1,
        OrderId = 1
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddCustomerOrderAddress",
        RequestModel = requestAddCustomerOrderAddress,
        ResponseContent = "Success"
      });

      requestAddCustomerOrderAddress = new AddCustomerOrderAddressRequestModel
      {
        AddressDetailId = 1,
        AddressType = "Work",
        AddressLine1 = "24 Victoria Street",
        AddressLine2 = "Muizenberg",
        City = "Cape Town",
        PostalCode = "7786",
        Country = "South Africa",
        Username = "rowena",
        CustomerId = 1,
        OrderId = 1
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AddCustomerOrderAddress",
        RequestModel = requestAddCustomerOrderAddress,
        ResponseContent = "Success"
      });

      //"WebApi:Orders:AcceptOrder"
      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AcceptOrder",
        RequestModel = new AcceptOrderRequestModel { OrderId = 1, Username = "zunaid" },
        ResponseContent = null
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:AcceptOrder",
        RequestModel = new AcceptOrderRequestModel { OrderId = 1, Username = "rowena" },
        ResponseContent = null
      });

      // send email forgotten password
      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:ForgotPassword",
        RequestModel = new CredentialsRequestModel { EmailAddress = "1@gmail.com" },
        ResponseContent = new ValidationResult()
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:ValidateUsername",
        RequestModel = new ValidateUserRequestModel { Username = "zunaid" },
        ResponseContent = new ValidationResult()
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:ValidateUsername",
        RequestModel = new ValidateUserRequestModel { Username = "rowena" },
        ResponseContent = new ValidationResult()
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:ValidateUserEmail",
        RequestModel = new ValidateEmailRequestModel { EmailAddress = "1@gmail.com" },
        ResponseContent = new ValidationResult()
      });

      // WebApi:Authenticate:FindUserProfile
      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:FindUserProfile",
        RequestModel = new FindUserRequestModel { Username = "zunaid" },
        ResponseContent = new UpdateProfileModel
        {
          Username = "zunaid",
          FirstName = "1",
          LastName = "1",
          EmailAddress = "1@gmail.com"
        }
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:FindUserProfile",
        RequestModel = new FindUserRequestModel { Username = "rowena" },
        ResponseContent = new UpdateProfileModel
        {
          Username = "rowena",
          FirstName = "1",
          LastName = "1",
          EmailAddress = "1@gmail.com"
        }
      });

      // WebApi:Authenticate:SaveProfile
      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:SaveProfile",
        RequestModel = new UpdateProfileRequestModel
        {
          Username = "zunaid",
          FirstName = "1",
          LastName = "1",
          EmailAddress = "1@gmail.com"
        },
        ResponseContent = new ValidationResult()
      });

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Authenticate:SaveProfile",
        RequestModel = new UpdateProfileRequestModel
        {
          Username = "rowena",
          FirstName = "1",
          LastName = "1",
          EmailAddress = "1@gmail.com"
        },
        ResponseContent = new ValidationResult()
      });

      //// WebApi:Orders:GetOrderQuote DOWNLOAD ORDER
      var responseDownloadOrder = new OrderQuotationViewModel
      {
        CustomerDetail = new OrderCustomerDetailModel
        {
          OrderId = 1,
          CustomerName = "Test Costumer",
          CustomerDetails = "This is some long customer description",
          CustomerContactNo = "0214472215",
          CustomerAccountNo = "DC1122",
          CustomerMobileNo = "0728543333",
          CustomerEmailAddress = "someemail@gmail.com",
          ContactAdded = false,
          ContactName = "Contraption",
          ContactNo = "0214472215",
          ContactEmailAddress = "someemail@gmail.com",
        },
        DeliveryAddress = new AddressDetailsModel
        {
          AddressDetailId = 1,
          AddressType = "Work",
          AddressLine1 = "12 Strand Street",
          AddressLine2 = "Muizenberg",
          City = "Port Elizabeth",
          PostalCode = "7786",
          Country = "RSA",
          CreateUser = "testuser",
          CreateDate = DateTime.Now
        },
        OrderTotals = new OrderDetailModel
        {
          OrderId = 1,
          OrderNo = "CCoT1",
          CreateDate = DateTime.Now,
          SubTotal = 800M,
          VatTotal = 120M,
          Total = 920M,
          Discount = 0M,
          OrderLineDetails = new List<OrderLineDetailModel>
          {
            new OrderLineDetailModel
            {
              OrderId = 1,
              ItemDescription = "TestProduct",
              UnitPrice = 100M,
              Quantity = 2,
              Discount = 0M,
              LineTotal = 200M
            },
            new OrderLineDetailModel
            {
              OrderId = 1,
              ItemDescription = "AnotherProductName",
              UnitPrice = 300M,
              Quantity = 2,
              Discount = 0M,
              LineTotal = 600M
            },
          }
        },
        CompanyProfile = new CompanyProfileModel
        {
          AddressLine1 = "12 Strand Street",
          AddressLine2 = "Muizenberg",
          City = "Port Elizabeth",
          PostalCode = "7786",
          Country = "RSA",
          EmailAddress = "someemail@gmail.com",
          DisplayName = "A Nice Company Name",
          RegistrationNo = "2018/2378945",
          TaxReferenceNo = "819823",
          TelephoneNo = "0217123344",
          BankingDetails = new BankingDetailsModel
          {
            AccountNo = "4075896644",
            AccountHolder = "Some Account Holder",
            AccountType = "Cheque",
            BankName = "ABSA",
            BranchCode = "632005"
          }
        }
      };

      var requestDownloadOrder = new GetOrderQuoteRequestModel { OrderId = 1, CompanyProfileId = 1 };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:GetOrderQuote",
        RequestModel = requestDownloadOrder,
        ResponseContent = responseDownloadOrder
      });

      // WebApi:Orders:LoadOrderDetail
      var responseLoadOrderDetailModel = new OrderDetailViewModel
      {
        OrderId = 0,
        OrderNo = "",
        VatRate = Convert.ToDecimal(0.15),
        OrderNoSeed = 1
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:LoadOrderDetail",
        RequestModel = new LoadOrderDetailRequestModel { OrderId = 0 },
        ResponseContent = responseLoadOrderDetailModel
      });

      // WebApi:Orders:LoadOrderCustomerDetail
      var requestModelLoadOrderCustomerDetail = new LoadOrderCustomerRequestModel { OrderId = 1, Username = "zunaid" };

      var contactList = new List<ContactModel>
      {
        new ContactModel
        {
          CustomerId = 1,
          ContactId = 1,
          ContactName = "Chocalate",
          ContactNo = "0217548899",
          EmailAddress = "Chocalate@capetown.gov.za",
          CreateUser ="zunaid",
          CreateDate = DateTime.Now
        },
        new ContactModel
        {
          CustomerId = 1,
          ContactId = 2,
          ContactName = "2",
          ContactNo = "2",
          EmailAddress = "",
          CreateUser ="zunaid",
          CreateDate = DateTime.Now
        },
        new ContactModel
        {
          CustomerId = 1,
          ContactId = 3,
          ContactName = "Swedend",
          ContactNo = "0726985223",
          EmailAddress = "Swedend@capetown.gov.za",
          CreateUser ="zunaid",
          CreateDate = DateTime.Now
        }
      };

      var responseModelLoadOrderCustomerDetail = new OrderCustomerViewModel
      {
        Customers = new List<CustomerModel>
        {
          new CustomerModel
          {
            CompanyProfileId = 1,
            CustomerId = 1,
            CustomerName = "1",
            CreateUser = "zunaid",
            CreateDate = DateTime.Now
          },
          new CustomerModel
          {
            CompanyProfileId = 1,
            CustomerId = 2,
            CustomerName = "The Juggernauts",
            CreateUser = "zunaid",
            CreateDate = DateTime.Now
          },
          new CustomerModel
          {
            CompanyProfileId = 1,
            CustomerId = 3,
            CustomerName = "Water Inc.",
            CreateUser = "zunaid",
            CreateDate = DateTime.Now
          }
        },
        CustomerDetails = new OrderCustomerDetailModel
        {
          OrderId = 1,
          OrderNo = "",
          CustomerId = 1,
          CustomerName = "1",
          CustomerDetails = "1",
          CustomerContactNo = "1",
          CustomerAccountNo = "1",
          CustomerMobileNo = "1",
          CustomerEmailAddress = "",
          ContactId = 2,
          ContactName = "2",
          ContactNo = "2",
          ContactEmailAddress = "",
          ContactAdded = true
        },
        Contacts = contactList
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:LoadOrderCustomerDetail",
        RequestModel = requestModelLoadOrderCustomerDetail,
        ResponseContent = responseModelLoadOrderCustomerDetail
      });

      // WebApi:Orders:GetCustomerContactDetails
      contactList = new List<ContactModel>
      {
        new ContactModel
        {
          CustomerId = 2,
          ContactId = 4,
          ContactName = "new",
          ContactNo = "new",
          EmailAddress = "new.gov.za",
          CreateUser ="zunaid",
          CreateDate = DateTime.Now
        },
        new ContactModel
        {
          CustomerId = 2,
          ContactId = 5,
          ContactName = "asdf",
          ContactNo = "asdf",
          EmailAddress = "",
          CreateUser ="zunaid",
          CreateDate = DateTime.Now
        },
        new ContactModel
        {
          CustomerId = 2,
          ContactId = 6,
          ContactName = "11111",
          ContactNo = "11111",
          EmailAddress = "1111@capetown.gov.za",
          CreateUser ="zunaid",
          CreateDate = DateTime.Now
        }
      };

      var customerDetails = new CustomerModel
      {
        CompanyProfileId = 1,
        CustomerId = 2,
        CustomerName = "City of Port Elizabeth",
        CustomerDetails = "Some Long Detailed Description",
        ContactNo = "0214178855",
        EmailAddress = "comeemail@gmail.com",
        MobileNo = "0741102255",
        AccountNo = "AD4456",
      };

      var responseModelGetCustomerContacts = new CustomerContactDetailsModel
      {
        Contacts = contactList,
        Customer = customerDetails
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:GetCustomerContactDetails",
        RequestModel = new GetCustomerContactsRequestModel { CustomerId = 2 },
        ResponseContent = responseModelGetCustomerContacts
      });

      //WebApi:Orders:GetContactPersonDetails

      var requestGetContactPersonDetailsModel = new GetContactPersonDetailsRequestModel { ContactId = 6 };

      var responseGetContactPersonDetailsModel = new ContactModel
      {
        CustomerId = 1,
        ContactId = 6,
        ContactName = "City of Port Elizabeth",
        ContactNo = "0214178855",
        EmailAddress = "comeemail@gmail.com",
        CreateUser = "zunaid",
        CreateDate = DateTime.Now
      };

      Responses.Add(new MockApiResponseModel
      {
        WepApiUrl = "WebApi:Orders:GetContactPersonDetails",
        RequestModel = requestGetContactPersonDetailsModel,
        ResponseContent = responseGetContactPersonDetailsModel
      });

      // WebApi:Orders:GetCustomerOrderAddress
      //var responseGetOrderCustomerDetail = new OrderCustomerDetailModel
      //{
      //  CustomerName = "1",
      //  CustomerDetails = "1",
      //  CustomerContactNo = "1",
      //  CustomerAccountNo = "1",
      //  CustomerMobileNo = "1",
      //  CustomerEmailAddress = "1@gmail.com",
      //  ContactAdded = true,
      //  ContactName = "1",
      //  ContactNo = "1",
      //  ContactEmailAddress = "1@gmail.com",
      //  CustomerId = 1,
      //  ContactId = 1,
      //  OrderId = 1,
      //  OrderNo = "1",
      //  OrderCreateDate = DateTime.Now
      //};

      //var responseGetCustomerContacts = new List<ContactModel>
      //{
      //  new ContactModel
      //  {
      //    CustomerId = 1,
      //    ContactId = 1,
      //    ContactName = "Rustum Gabier",
      //    ContactNo = "0217548899",
      //    EmailAddress = "rustum@capetown.gov.za",
      //    CreateUser ="zunaid",
      //    CreateDate = DateTime.Now
      //  },
      //  new ContactModel
      //  {
      //    CustomerId = 1,
      //    ContactId = 2,
      //    ContactName = "Mobb Deep",
      //    ContactNo = "0825554444",
      //    EmailAddress = "mobbdeep@capetown.gov.za",
      //    CreateUser ="zunaid",
      //    CreateDate = DateTime.Now
      //  },
      //  new ContactModel
      //  {
      //    CustomerId = 1,
      //    ContactId = 3,
      //    ContactName = "Elton Pappy",
      //    ContactNo = "0726985223",
      //    EmailAddress = "elton@capetown.gov.za",
      //    CreateUser ="zunaid",
      //    CreateDate = DateTime.Now
      //  }
      //};

      //var responseModel2 = new AddressDetailsModel
      //{
      //  AddressDetailId = 1,
      //  AddressType = "Work",
      //  AddressLine1 = "24 Victoria Street",
      //  AddressLine2 = "Muizenberg",
      //  City = "Cape Town",
      //  PostalCode = "7786",
      //  Country = "South Africa"
      //};

      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:GetCustomerOrderAddress", RequestModel = new GetCustomerOrderAddressRequestModel { OrderId = 977 }, ResponseContent = responseModel2 });

      // WebApi:Orders:GetCustomerAddresses

      //var responseModel = new List<AddressDetailsModel>
      //{
      //  new AddressDetailsModel
      //  {
      //    AddressDetailId = 1,
      //    AddressType = "Work",
      //    AddressLine1 = "24 Victoria Street",
      //    AddressLine2= "Muizenberg",
      //    City = "Cape Town",
      //    PostalCode = "7786",
      //    Country = "South Africa",
      //    CreateUser = "zunaid",
      //    CreateDate = DateTime.Now
      //  },
      //  new AddressDetailsModel
      //  {
      //    AddressDetailId = 2,
      //    AddressType = "Home",
      //    AddressLine1 = "24 John Street",
      //    AddressLine2= "Pelican Park",
      //    City = "Cape Town",
      //    PostalCode = "7786",
      //    Country = "South Africa",
      //    CreateUser = "zunaid",
      //    CreateDate = DateTime.Now
      //  },
      //  new AddressDetailsModel
      //  {
      //    AddressDetailId = 3,
      //    AddressType = "Delivery",
      //    AddressLine1 = "City Of Cape Town",
      //    AddressLine2= "Adderley Street",
      //    City = "Cape Town",
      //    PostalCode = "7800",
      //    Country = "South Africa",
      //    CreateUser = "zunaid",
      //    CreateDate = DateTime.Now
      //  },
      //};

      ////resources.MockApiCaller.AddMockResponse("WebApi:Orders:GetCustomerAddresses", requestModel, responseModel);
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:GetCustomerAddresses", RequestModel = new GetCustomerAddressesRequestModel { CustomerId = 1 }, ResponseContent = responseModel });

      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:RemoveCustomerAddress", RequestModel = new RemoveCustomerAddressRequestModel { AddressDetailId = 1 }, ResponseContent = "Success" });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:RemoveCustomerAddress", RequestModel = new RemoveCustomerAddressRequestModel { AddressDetailId = 2 }, ResponseContent = "Success" });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:RemoveCustomerAddress", RequestModel = new RemoveCustomerAddressRequestModel { AddressDetailId = 3 }, ResponseContent = "Success" });

      //inputModel = new AddOrderCustomerRequestModel
      //{
      //  OrderId = 245,
      //  CustomerId = 0,
      //  CustomerName = "1",
      //  CustomerDetails = "1",
      //  CustomerContactNo = "1",
      //  CustomerMobileNo = "1",
      //  CustomerAccountNo = "1",
      //  CustomerEmailAddress = "",
      //  ContactId = 0,
      //  ContactAdded = true,
      //  ContactEmailAddress = "",
      //  ContactName = "1",
      //  ContactNo = "1"
      //};
      //responseModel4 = new AddCustomerOrderModel { OrderId = 245, CustomerId = 1, ContactId = 1 };

      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:AddOrderCustomer", RequestModel = inputModel, ResponseContent = responseModel4 });


      // WebApi: Orders: GetOrderDetail
      var responseGetOrderDetail = new OrderDetailModel
       {
         OrderId = 1,
         OrderNo = "QUOTE123",
         CreateDate = DateTime.Now,
         SubTotal = 222M,
         VatTotal = 20M,
         Total = 242M,
         Discount = 0M,
         OrderLineDetails = new List<OrderLineDetailModel>
         {
          new OrderLineDetailModel
          {
            OrderId = 1,
            ItemDescription = "TestProduct",
            UnitPrice = 111M,
            Quantity = 2,
            Discount = 0M,
            LineTotal = 242M
          },
          new OrderLineDetailModel
          {
            OrderId = 1,
            ItemDescription = "Delivery Fee",
            UnitPrice = 111M,
            Quantity = 21,
            Discount = 0M,
            LineTotal = 111M
          },
         }
       };

      Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:GetOrderDetail", RequestModel = new GetOrderDetailRequestModel { OrderId = 1 }, ResponseContent = responseGetOrderDetail });
      
      //var orderLineDetails = new List<OrderLineDetailModel>
      //  {
      //    new OrderLineDetailModel
      //    {
      //      OrderId = 123,
      //      ItemDescription = "TestProduct",
      //      UnitPrice = 111M,
      //      Quantity = 2,
      //      Discount = 0M,
      //      LineTotal = 242M
      //    },
      //    new OrderLineDetailModel
      //    {
      //      OrderId = 123,
      //      ItemDescription = "Delivery Fee",
      //      UnitPrice = 111M,
      //      Quantity = 21,
      //      Discount = 0M,
      //      LineTotal = 111M
      //    },
      //  };

      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:GetOrderLineDetails", RequestModel = new GetOrderLineDetailsRequestModel { OrderId = 123 }, ResponseContent = orderLineDetails });

      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:EditOrderNo", RequestModel = new EditOrderNoRequestModel { OrderId = 123, OrderNo = "QUOTE123", Username = "zunaid" }, ResponseContent = "Success" });

      //var inputModel = new List<OrderDetailInputModel>
      //{
      //  new OrderDetailInputModel
      //  {
      //    Product = "test",
      //    UnitPrice = 1M,
      //    Quantity = 1M,
      //    Discount = 0M,
      //    LineTotal = 1M
      //  },
      //  new OrderDetailInputModel
      //  {
      //    Product = "delivery",
      //    UnitPrice = 1M,
      //    Quantity = 1M,
      //    Discount = 0M,
      //    LineTotal = 1M
      //  }
      //};

      //foreach (var model in inputModel)
      //{
      //  var requestModel = new AddOrderDetailRequestModel
      //  {
      //    LineNo = 1,
      //    OrderId = 123,
      //    ItemDescription = model.Product,
      //    UnitPrice = model.UnitPrice,
      //    Quantity = model.Quantity,
      //    Discount = model.Discount,
      //    LineTotal = model.LineTotal,
      //    Username = "zunaid"
      //  };

      //  Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Orders:AddOrderDetail", RequestModel = requestModel, ResponseContent = new ValidationResult() });
      //}
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Home:GetUserOrders", RequestModel = new FindUserOrdersRequestModel { Username = "zunaid" }, ResponseContent = viewModel });

      // WebApi:Role:GetUsernames
      //var usernames = new List<string> { "Jon", "Jonny", "Jonathon", "Johno"};
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Users:Filter", RequestModel = "jj", ResponseContent = usernames });

      //usernames = new List<string> { "Adam", "Andrea", "Abigail", "Aslam" };
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Users:Filter", RequestModel = "aa", ResponseContent = usernames });

      // WebApi:Authenticate:ChangePassword
      //Responses.Add(new MockApiResponseModel
      //{
      //  WepApiUrl = "WebApi:Authenticate:ChangePassword",
      //  RequestModel = new ChangePasswordRequestModel
      //  {
      //    Username = "zunaid",
      //    NewPassword = "111111",
      //  },
      //  ResponseContent = new UserModel { Username = "zunaid", ApiSessionToken = new System.Guid().ToString(), IsAuthenticated = true }
      //});

      // WebApi:Register:Save
      //Responses.Add(new MockApiResponseModel
      //{
      //  WepApiUrl = "WebApi:Register:Save",
      //  RequestModel = new RegisterUserRequestModel
      //  {
      //    Username = "zunaid",
      //    Password = "222222",
      //    ConfirmPassword = "222222",
      //    FirstName = "3",
      //    LastName = "4",
      //    EmailAddress = "zunaid@gmail.com"
      //  },
      //  ResponseContent = new UserModel { Username = "zunaid", EmailAddress = "zunaid@gmail.com", ApiSessionToken = System.Guid.NewGuid().ToString() }
      //  });

      //Responses.Add(new MockApiResponseModel
      //{
      //  WepApiUrl = "WebApi:Register:Save",
      //  RequestModel = new RegisterUserRequestModel
      //  {
      //    Username = "111111",
      //    Password = "222222",
      //    ConfirmPassword = "222222",
      //    FirstName = "3",
      //    LastName = "4",
      //    EmailAddress = "5@gmail.com"
      //  },
      //  ResponseContent = null 
      //});

      //// WebApi:Register:ValidateUser
      //var responseModel = new ValidationResult();
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Register:ValidateUser", RequestModel = new ValidateUserRequestModel { Username = "zunaid" }, ResponseContent = responseModel });

      //responseModel = new ValidationResult();
      //responseModel.InValidate("", "Username already exists");
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Register:ValidateUser", RequestModel = new ValidateUserRequestModel { Username = "rowena" }, ResponseContent = responseModel });

      //responseModel = new ValidationResult();
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Register:ValidateUser", RequestModel = new ValidateUserRequestModel { Username = "111111" }, ResponseContent = responseModel });

      ////WebApi: Register: ValidateEmail
      //responseModel = new ValidationResult();
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Register:ValidateEmail", RequestModel = new ValidateEmailRequestModel { EmailAddress = "zunaid@gmail.com" }, ResponseContent = responseModel });

      //responseModel = new ValidationResult();
      //responseModel.InValidate("", "Already linked to another user.");
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Register:ValidateEmail", RequestModel = new ValidateEmailRequestModel { EmailAddress = "rowena@gmail.com" }, ResponseContent = responseModel });

      //responseModel = new ValidationResult();
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Register:ValidateEmail", RequestModel = new ValidateEmailRequestModel { EmailAddress = "5@gmail.com" }, ResponseContent = responseModel });



      //Responses.Add(new MockApiResponseModel
      //{
      //  WepApiUrl = "WebApi:Login",
      //  RequestModel = new LoginRequestModel { Username = "1", Password = "1" },
      //  ResponseContent = null
      //});

      //Responses.Add(new MockApiResponseModel
      //{
      //  WepApiUrl = "WebApi:Login",
      //  RequestModel = new LoginRequestModel { Username = "rowena", Password = "1234" },
      //  ResponseContent = new UserModel { Username = "rowena", ApiSessionToken = System.Guid.NewGuid().ToString(), IsAuthenticated = false, CompanyProfileId =  = 1 }
      //});

      //WebApi:Login:RequestCredentials
      //Responses.Add(new MockApiResponseModel
      //{
      //  WepApiUrl = "WebApi:Login:ForgotPassword",
      //  RequestModel = new CredentialsRequestModel { EmailAddress = "zunaid@gmail.com" },
      //  ResponseContent = true
      //});

      //Responses.Add(new MockApiResponseModel
      //{
      //  WepApiUrl = "WebApi:Login:RequestCredentials",
      //  RequestModel = new CredentialsRequestModel { EmailAddress = "5@gmail.com" },
      //  ResponseContent = false
      //});

      //WebApi: Permissions: GetArtifacts
      //var artifacts = new List<ArtifactModel> { new ArtifactModel { ArtifactId = 1, ArtifactName = "Add Customer"},
      //                                  new ArtifactModel { ArtifactId = 2, ArtifactName = "Create Quote"},
      //                                  new ArtifactModel { ArtifactId = 3, ArtifactName = "Add Company Profile"},
      //                                  new ArtifactModel { ArtifactId = 4, ArtifactName = "Remove Delivery Address"} };
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:GetArtifacts", RequestModel = null, ResponseContent = artifacts });

      //// WebApi:Permissions:AddArtifact - 
      //var responseModel = new ValidationResult();
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:AddArtifact", RequestModel = new AddArtifactRequestModel { ArtifactName = "Testing", CreateUsername = "zunaid" }, ResponseContent = new ValidationResult() });

      //// WebApi:Permissions:AddArtifact - Already exists
      //responseModel.InValidate("", "The artifact already exists");
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:AddArtifact", RequestModel = new AddArtifactRequestModel { ArtifactName = "Add Customer", CreateUsername = "zunaid" }, ResponseContent = responseModel });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:AddArtifact", RequestModel = new AddArtifactRequestModel { ArtifactName = "Create Quote", CreateUsername = "zunaid" }, ResponseContent = responseModel });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:AddArtifact", RequestModel = new AddArtifactRequestModel { ArtifactName = "Add Company Profile", CreateUsername = "zunaid" }, ResponseContent = responseModel });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:AddArtifact", RequestModel = new AddArtifactRequestModel { ArtifactName = "Remove Delivery Address", CreateUsername = "zunaid" }, ResponseContent = responseModel });

      //// WebApi:Permissions:RemoveArtifact 
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:RemoveArtifact", RequestModel = new RemoveArtifactRequestModel { ArtifactId = 1 }, ResponseContent = null });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:RemoveArtifact", RequestModel = new RemoveArtifactRequestModel { ArtifactId = 2 }, ResponseContent = null });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:RemoveArtifact", RequestModel = new RemoveArtifactRequestModel { ArtifactId = 3 }, ResponseContent = null });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:RemoveArtifact", RequestModel = new RemoveArtifactRequestModel { ArtifactId = 4 }, ResponseContent = null });

      //// WebApi:Permissions:Find
      //var permissions = new List<PermissionModel>();
      //permissions.Add(new PermissionModel { PermissionId = 1, ArtifactId = 1, RoleName = "Administrator" });
      //permissions.Add(new PermissionModel { PermissionId = 2, ArtifactId = 1, RoleName = "Operations" });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:Find", RequestModel = new FindPermissionsRequestModel { ArtifactId = 1 }, ResponseContent = permissions });

      //// WebApi: Permissions: EditArtifact - Successful
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:EditArtifact", RequestModel = new EditArtifactRequestModel { ArtifactId = 1, ArtifactName = "Testing", UpdateUsername = "zunaid" }, ResponseContent = new ValidationResult() });

      //// WebApi:Permissions:Remove
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:Remove", RequestModel = new RemovePermissionRequestModel { PermissionId = 1 }, ResponseContent = null });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:Remove", RequestModel = new RemovePermissionRequestModel { PermissionId = 2 }, ResponseContent = null });

      ////// WebApi:Permissions:Add - Successful
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:Add", RequestModel = new AddPermissionRequestModel { ArtifactId = 1, RoleId = 2, CreateUsername = "zunaid" }, ResponseContent = new ValidationResult() });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:Add", RequestModel = new AddPermissionRequestModel { ArtifactId = 1, RoleId = 3, CreateUsername = "zunaid" }, ResponseContent = new ValidationResult() });

      ////// WebApi:Permissions:Add - Already exists
      //responseModel = new ValidationResult();
      //responseModel.InValidate("", "The permission already exists");
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:Add", RequestModel = new AddPermissionRequestModel { ArtifactId = 1, RoleId = 1, CreateUsername = "zunaid" }, ResponseContent = responseModel });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Permissions:Add", RequestModel = new AddPermissionRequestModel { ArtifactId = 1, RoleId = 4, CreateUsername = "zunaid" }, ResponseContent = responseModel });


      // WebApi:Role:GetAll
      //var roles = new List<RoleModel> { new RoleModel { RoleId = 1, RoleName = "Administrator"},
      //                                  new RoleModel { RoleId = 2, RoleName = "Vetting Clerk"},
      //                                  new RoleModel { RoleId = 3, RoleName = "Programmer"},
      //                                  new RoleModel { RoleId = 4, RoleName = "Operations"} };
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:GetAll", RequestModel = null, ResponseContent = roles });

      // WebApi:Role:AddRole - Successful
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddRole", RequestModel = new AddRoleRequestModel { RoleName = "Legal" }, ResponseContent = new ValidationResult() });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddRole", RequestModel = new AddRoleRequestModel { RoleName = "Orders" }, ResponseContent = new ValidationResult() });

      // WebApi: Role: EditRole - Successful
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:EditRole", RequestModel = new EditRoleRequestModel { RoleId = 1, RoleName = "Legal", AuditUsername = string.Empty }, ResponseContent = new ValidationResult() });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:EditRole", RequestModel = new EditRoleRequestModel { RoleId = 1, RoleName = "Orders", AuditUsername = string.Empty }, ResponseContent = new ValidationResult() });

      // WebApi:Role:AddRole - Already exists
      //responseModel.InValidate("", "The role already exists");
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddRole", RequestModel = new AddRoleRequestModel { RoleName = "Administrator" }, ResponseContent = responseModel });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddRole", RequestModel = new AddRoleRequestModel { RoleName = "Vetting Clerk" }, ResponseContent = responseModel });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddRole", RequestModel = new AddRoleRequestModel { RoleName = "Programmer" }, ResponseContent = responseModel });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddRole", RequestModel = new AddRoleRequestModel { RoleName = "Operations" }, ResponseContent = responseModel });

      // WebApi:Role:GetMembers
      //var members = new List<MemberModel>();
      //members.Add(new MemberModel { MemberId = 1, RoleId = 1, Username = "jacob" });
      //members.Add(new MemberModel { MemberId = 2, RoleId = 1, Username = "aslam" });
      //members.Add(new MemberModel { MemberId = 3, RoleId = 1, Username = "melicia" });
      //members.Add(new MemberModel { MemberId = 4, RoleId = 1, Username = "craig" });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:GetMembers", RequestModel = new FindMembersRequestModel { RoleId = 1 }, ResponseContent = members} );

      //members = new List<MemberModel>();
      //members.Add(new MemberModel { MemberId = 5, RoleId = 2, Username = "john" });
      //members.Add(new MemberModel { MemberId = 6, RoleId = 2, Username = "kaasiem" });
      //members.Add(new MemberModel { MemberId = 7, RoleId = 2, Username = "abdullah" });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:GetMembers", RequestModel = new FindMembersRequestModel { RoleId = 2 }, ResponseContent = members });

      //members = new List<MemberModel>();
      //members.Add(new MemberModel { MemberId = 8, RoleId = 3, Username = "rugaya" });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:GetMembers", RequestModel = new FindMembersRequestModel { RoleId = 3 }, ResponseContent = members });

      //// WebApi:Role:AddMember - Successful
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddMember", RequestModel = new AddMemberRequestModel { RoleId = 1, Username = "Zunaid" }, ResponseContent = new ValidationResult() });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddMember", RequestModel = new AddMemberRequestModel { RoleId = 1, Username = "Regan" }, ResponseContent = new ValidationResult() });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddMember", RequestModel = new AddMemberRequestModel { RoleId = 1, Username = "John" }, ResponseContent = new ValidationResult() });

      //// WebApi:Role:AddMember - Already exists
      //responseModel = new ValidationResult();
      //responseModel.InValidate("", "The member already exists");
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddMember", RequestModel = new AddMemberRequestModel { RoleId = 1, Username = "jacob" }, ResponseContent = responseModel });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddMember", RequestModel = new AddMemberRequestModel { RoleId = 1, Username = "aslam" }, ResponseContent = responseModel });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddMember", RequestModel = new AddMemberRequestModel { RoleId = 1, Username = "melicia" }, ResponseContent = responseModel });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:AddMember", RequestModel = new AddMemberRequestModel { RoleId = 1, Username = "craig" }, ResponseContent = responseModel });

      // WebApi:Role:RemoveRole 
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:RemoveRole", RequestModel = new RemoveRoleRequestModel { RoleId = 1 }, ResponseContent = null });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:RemoveRole", RequestModel = new RemoveRoleRequestModel { RoleId = 2 }, ResponseContent = null });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:RemoveRole", RequestModel = new RemoveRoleRequestModel { RoleId = 3 }, ResponseContent = null });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:RemoveRole", RequestModel = new RemoveRoleRequestModel { RoleId = 4 }, ResponseContent = null });

      // WebApi:Role:RemoveMember
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:RemoveMember", RequestModel = new RemoveMemberRequestModel { RoleId = 1, MemberId = 1 }, ResponseContent = null });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:RemoveMember", RequestModel = new RemoveMemberRequestModel { RoleId = 1, MemberId = 2 }, ResponseContent = null });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:RemoveMember", RequestModel = new RemoveMemberRequestModel { RoleId = 1, MemberId = 3 }, ResponseContent = null });
      //Responses.Add(new MockApiResponseModel { WepApiUrl = "WebApi:Role:RemoveMember", RequestModel = new RemoveMemberRequestModel { RoleId = 1, MemberId = 4 }, ResponseContent = null });
    }
  }
}
