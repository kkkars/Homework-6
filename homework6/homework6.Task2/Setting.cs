using System.Text.Json.Serialization;

namespace homework6.Task2
{
    class Setting
    {
        [JsonPropertyName("primesFrom")]
        public int LowerBound { get; set; }

        [JsonPropertyName("primesTo")]
        public int UpperBound { get; set; }
    }
}
