//namespace CarDekho.Service
//{
//    using CarDekho.Models;

//    public class BuyerSecurity
//    {
//        private readonly CarDekhoDBContext car;

//        public BuyerSecurity(CarDekhoDBContext car)
//        {
//            this.car = car;
//        }

//        public static bool Login(string email,string password)
//        {
//            using (CarDekhoDBContext dBContext = new CarDekhoDBContext())
//            {
//                return dBContext.Buyers.Any(u => u.BuyerEmail.Equals(email,
//              StringComparison.OrdinalIgnoreCase) && u.BuyerPassword.Equals(password));
//            }
//        }
//    }
//}
