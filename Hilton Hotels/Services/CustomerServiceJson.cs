using Hilton_Hotels.Models;

using System.Text.Json;

namespace Hilton_Hotels.Services
{
    public class CustomerServiceJson : ICustomerService
    {
        

       private const string fileDir = "../Hilton Hotels/wwwroot/Jsonfiles/";
        private const string fileName = fileDir + "CustomerJson.json";

        List<CustomerModel> _customers = new List<CustomerModel>();
        public CustomerServiceJson()
        {
            _customers = ReadFromJson();
        }
        public void Add(CustomerModel costumer)
        {
            _customers.Add(costumer);
            SaveToJson();
        }

        public void Delete(string UserName)
        {
            CustomerModel customer = Find(UserName);
            _customers.Remove(customer);
            SaveToJson();
            
        }

        public List<CustomerModel> ReadFromJson()
        {
            using(var file = File.OpenText(fileName))
            {
                String json= file.ReadToEnd();
                return JsonSerializer.Deserialize<List<CustomerModel>>(json);
            }
            return new List<CustomerModel>();
        }

        public CustomerModel Find(string UserName)
        {
            CustomerModel c = _customers.Find(c => c.Username == UserName);
            if (c is not null)
            {
                return c;
            }
            throw new KeyNotFoundException();
        }
        public void Update(CustomerModel newCustomer)
        {
            CustomerModel customer = Find(newCustomer.Username);

            customer.Name = newCustomer.Name;
            customer.Username = newCustomer.Username;
            customer.Password = newCustomer.Password;

            SaveToJson();
        }

        private void SaveToJson()
        {
            String json = JsonSerializer.Serialize(_customers);
            File.WriteAllText(fileName, json);
        }

        public List<CustomerModel> Get()
        {
            return new List<CustomerModel>(_customers);
        }
    }
}
