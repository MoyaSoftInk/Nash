namespace Nash.Domain.Credentials
{
    using Nash.Domain.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Credential currencies is a dictionary what contain all base url and key to access request.
    /// </summary>
    public class CredentialsCurrencies
    {
        public IDictionary<ExchangerEnum, CredentialsApi> KeyValues;
        
        public CredentialsCurrencies()
        {
            this.KeyValues = new Dictionary<ExchangerEnum, CredentialsApi>();

            this.KeyValues.Add(ExchangerEnum.CambioToday, new CredentialsApi("1772|16UgprtC6qKO1QigmgA16JjG7feXfhD~", "http://api.currencies.zone/v1/quotes/{0}/{1}/json?quantity=1&key={2}"));
            this.KeyValues.Add(ExchangerEnum.EstadisticasBCRA, new CredentialsApi("eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1ODIzMTA5NDgsInR5cGUiOiJleHRlcm5hbCIsInVzZXIiOiJtb3lhX2pvc2VfNTc1QGhvdG1haWwuY29tIn0.FgHEaaR_MZT0oxPovTUNbTfLS1PRZiKX73kM32Xcyx4G8ScUU7HOllXXnqJvkHsNjmwaxn-S0lm6qSWaFUQn2g", "http://api.estadisticasbcra.com/usd"));

        }
    }

    /// <summary>
    /// Credential Api class base of Credential currencies.
    /// </summary>
    public class CredentialsApi
    {
        public CredentialsApi(string key, string urlBase)
        {
            this.Key = key;
            this.URLBase = urlBase;
        }

        public string Key;
        public string URLBase;
    }
}
