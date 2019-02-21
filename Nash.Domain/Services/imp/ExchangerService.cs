namespace Nash.Domain.Services.imp
{
    using Nash.Domain.Credentials;
    using Nash.Domain.Enums;
    using Nash.Domain.Models;
    using Nash.Domain.Responses;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class ExchangerService : IExchangerService
    {
        private readonly CredentialsCurrencies credentialsCurrencies;
        private HttpClient httpClient;

        public ExchangerService()
        {
            this.credentialsCurrencies = new CredentialsCurrencies();
        }

        public async Task<NashResponse> GetQuote(CurrenciesNameEnum currencyName, CurrenciesCodeEnum currencyCode)
        {

            NashResponse nashResponse = new NashResponse();
            CambioTodayModel cambioToday = new CambioTodayModel();

            if (currencyCode.Equals(CurrenciesCodeEnum.USD))
            {
                var EstadisticasBcraModel = await this.GetQuoteFromEstadisticasBcraAsync();

                nashResponse.Precio = EstadisticasBcraModel.v;
                nashResponse.Moneda = currencyName.ToString("g");
            }
            else
            {
                cambioToday = await this.GetQuoteFromCambiosTodayAsync(currencyCode);

                nashResponse.Moneda = currencyName.ToString("g");
                nashResponse.Precio = cambioToday.Result.Value;
            }           

            return nashResponse;
        }

        private async Task<EstadisticasBcraModel> GetQuoteFromEstadisticasBcraAsync()
        {
            try
            {
                this.httpClient = new HttpClient();
                EstadisticasBcraResponse estadisticasBcraResponse = new EstadisticasBcraResponse();

                CredentialsApi credentials = this.credentialsCurrencies.KeyValues[ExchangerEnum.EstadisticasBCRA];

                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", credentials.Key);

                var response = await this.httpClient.GetAsync(credentials.URLBase);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    estadisticasBcraResponse.estadisticasBcras = JsonConvert.DeserializeObject<List<EstadisticasBcraModel>>(result);
                    return estadisticasBcraResponse.estadisticasBcras.Last();
                }

            }
            catch(Exception)
            {
                throw new Exception("Ha ocurrido un problema, por favor intente más tarde");
            }

            return null;
           
        }

        private async Task<CambioTodayModel> GetQuoteFromCambiosTodayAsync(CurrenciesCodeEnum currenciesCode)
        {
            try
            {
                this.httpClient = new HttpClient();
                CambioTodayModel cambioToday = new CambioTodayModel();

                CredentialsApi credentials = this.credentialsCurrencies.KeyValues[ExchangerEnum.CambioToday];
                
                string cambiosTodayURL = string.Format(credentials.URLBase, CurrenciesCodeEnum.USD.ToString("g"), currenciesCode.ToString("g"), credentials.Key);

                var response = await this.httpClient.GetAsync(cambiosTodayURL);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    cambioToday = JsonConvert.DeserializeObject<CambioTodayModel>(result);
                    return cambioToday;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un problema, por favor intente más tarde");
            }

            return null;
        }
        
    }
}
