﻿namespace Microservicios.Kaure.Deposit.DTOs
{
    public class TransactionRequest
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
