namespace Nash.Domain.Responses
{
    /// <summary>
    /// Represent the response from NashApi.
    /// </summary>
    public class NashResponse
    {
        public NashResponse() { }

        public string Moneda { get; set; }
        public string Precio { get; set; }
    }
}
