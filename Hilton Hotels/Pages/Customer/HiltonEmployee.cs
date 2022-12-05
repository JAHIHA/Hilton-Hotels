namespace Hilton_Hotels.Pages.Customer
{
    public class HiltonEmployee : Person
    {
        int salary;
        public HiltonEmployee(string name, long phone_number, string email, int salary) : base(name, phone_number, email)
        {
            this.salary = salary;
        }
        public override string Print()
        {
            return base.Print()+"\n" + "salary : " + salary + "\n";
        }
    }
}
