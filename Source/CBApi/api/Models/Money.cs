using System;
namespace com.careerbuilder.api.models {
    [Serializable]
    public class Money {
        public float Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string FormattedAmount { get; set; }
    }
}