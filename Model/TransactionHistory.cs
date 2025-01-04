using System.Text.Json.Serialization;

namespace Coursework_BudgetMate.Model
{
    public class TransactionHistory
    {
        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("tags")]
        public string[] Tags { get; set; } = Array.Empty<string>();

        [JsonPropertyName("note")]
        public string Note { get; set; } = string.Empty;
    }
}