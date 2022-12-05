namespace Hilton_Hotels.Pages.Customer
{
    public class RoomLocator
    {
        Person user;
        Room room;
        DateTime inDate;
        DateTime outDate;
        string customer = "Customer";
        string hiltonEmployee = "Hilton Employee";
        double pay = 0;
        double days;

        public RoomLocator(string name, long phone_number, string email, int number, bool busy, DateTime inD, DateTime outD)
        {
            user =new Person(name, phone_number, email);
            room = new Room(number, busy);
            inDate = inD;
            outDate = outD;
        }
        public double computeCost(DateTime outdate, string Type)
        {
            double pay = 0;
            
            this.outDate = outdate;
            if (Type == "Customer")
            {
                days = (outDate - inDate).TotalDays;
                //return days;
                if (days < 5)
                {
                    pay = 20;
                    return pay;
                }
                if (days > 5)
                {
                    pay = 20;
                    double newday = days - 5;
                    newday *= 10;
                    pay += newday;
                    return pay;
                }
            }
            else if(Type=="Hilton Employee")
            {
                if (days<=5)
                { pay = 3; }
                if (days>5)
                { double newday = days - 5;
                    newday *= 3;
                        pay = 5;
                    pay += newday;
                    return pay;

                        }
                if (days>30)
                {
                    double dis = pay * .1;
                    pay = pay - dis;
                    return pay;

                }
                return pay;
            }

            return pay;
        }
    }
}
