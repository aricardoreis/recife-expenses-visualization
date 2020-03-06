using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Response
{
    public class ExpenseSearchResponseData
    {
        [JsonProperty("result")]
        public ExpenseSearchResult Result { get; set; }
    }

    public class ExpenseSearchResult
    {
        [JsonProperty("records")]
        public IList<ExpenseResultRecord> Records { get; set; }
    }

    public class ExpenseResultRecord
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mes_movimentacao")]
        public int Month { get; set; }

        [JsonProperty("categoria_economica_nome")]
        public string CategoryName { get; set; }

        [JsonProperty("fonte_recurso_nome")]
        public string SourceName { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
