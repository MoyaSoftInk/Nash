namespace Nash.Domain.Models
{
    using System.Collections.Generic;

    public class ChartModel
    {
        public List<decimal> Data { get; set; }
        public string Label { get; set; }

        public ChartModel()
        {
            Data = new List<decimal>();
        }
    }
}
