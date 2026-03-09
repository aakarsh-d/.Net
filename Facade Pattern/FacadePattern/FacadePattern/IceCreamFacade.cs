using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class IceCreamFacade
    {
        private FlavourServices _flavorService;
        private ConeServices _coneService;
        private PaymentServices _paymentService;

        public IceCreamFacade()
        {
            _flavorService = new FlavourServices();
            _coneService = new ConeServices();
            _paymentService = new PaymentServices();
        }

        public string GetIceCream()
        {
            Console.WriteLine("Mother is arranging the ice cream...");

            string flavor = _flavorService.GetFlavour();
            string cone = _coneService.GetCone();

            _paymentService.ProcessPayment();

            return flavor + " in a " + cone;
        }
    }
}