namespace Hilton_Hotels.Services.Interface
{
    public interface IPaymentService
    {
        public double computeCost(DateTime checkin, DateTime checkout);
    }
}
