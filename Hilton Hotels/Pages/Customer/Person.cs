namespace Hilton_Hotels.Pages.Customer
{
    public class Person
    {
        string name;
        long phone_number;
        string email;
        public Person(string name, long phone_number, string email)
        {
            this.name = name;
            this.phone_number = phone_number;
            this.email = email;
        }

        public virtual string Print()
        {
            return "name : " + this.name + "\n " + "phone number is: " + phone_number + "\n" + "Email: " + email + "\n";
        }
    }
}
