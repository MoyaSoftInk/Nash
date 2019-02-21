namespace Nash.Domain.Models
{
    /// <summary>
    /// Represent the response was return from Cambios.TodayAPI.
    /// </summary>
    public class CambioTodayModel
    {
        public CambioTodayModel()
        {
            this.Result = new Result();
        }

        public Result Result { get; set; }
        public string Status { get; set; }
    }

    public class Result
    {
        public Result() { }

        public string Updated { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string Value { get; set; }
        public string Quantity { get; set; }
        public string Amount { get; set; }
    }
}
