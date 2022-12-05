namespace Hilton_Hotels.Pages.Customer
{
    public class Customer : Person
    {
        string payment_method;
        public Customer(string name, long phone_number, string email, string payment_method) : base(name, phone_number, email)
        {
            this.payment_method = payment_method;
        }
        public override string Print()
        {
            return base.Print()+"\n"+"payment_method : " + payment_method+"\n" ;
        }
    }
}
