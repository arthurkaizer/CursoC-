using System;
using exercicioFixacao.Entities;

namespace exercicioFixacao.Services
{
    class ContractServices
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractServices(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.totalValue / months;
            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.date.AddMonths(i);
                double updatedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _onlinePaymentService.PaymentFee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
