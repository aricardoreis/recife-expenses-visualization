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
        [JsonProperty("_id")]
        public int Id { get; set; }

        [JsonProperty("ano_movimentacao")]
        public int Year { get; set; }

        [JsonProperty("mes_movimentacao")]
        public int Month { get; set; }

        [JsonProperty("categoria_economica_codigo")]
        public int CategoryId { get; set; }

        [JsonProperty("categoria_economica_nome")]
        public string CategoryName { get; set; }

        [JsonProperty("fonte_recurso_codigo")]
        public int SourceId { get; set; }

        [JsonProperty("fonte_recurso_nome")]
        public string SourceName { get; set; }

        [JsonProperty("valor_pago")]
        public decimal Value { get; set; }

        //[JsonProperty("name")]
        //public string Name { get; set; }
    }
}
