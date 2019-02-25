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

    /// <summary>
    /// the service provide all methods relationated with quote of currencies
    /// </summary>
    public class ExchangerService : IExchangerService
    {
        private readonly CredentialsCurrencies credentialsCurrencies;
        private HttpClient httpClient;

        public ExchangerService()
        {
            this.credentialsCurrencies = new CredentialsCurrencies();
        }

        /// <summary>
        /// Get the quote of currency
        /// </summary>
        /// <param name="currencyName"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
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

        public async Task<List<ChartModel>> GetChartCurrencies()
        {
            List<ChartModel> chartModels = new List<ChartModel>();

            var quoteReal = await this.GetQuoteFromCambiosTodayAsync(CurrenciesCodeEnum.BRL);
            var quoteEuro = await this.GetQuoteFromCambiosTodayAsync(CurrenciesCodeEnum.EUR);
            var quoteDolar = await this.GetQuoteFromEstadisticasBcraAsync();

            List<ChartCurrenciesModel> chartCurrencies = new List<ChartCurrenciesModel>();

            chartModels.Add(new ChartModel() { Data = new List<decimal>() { decimal.Parse(quoteDolar.v) }, Label = "Dolar" });
            chartModels.Add(new ChartModel() { Data = new List<decimal>() { decimal.Parse(quoteEuro.Result.Value) }, Label = "Euro" });
            chartModels.Add(new ChartModel() { Data = new List<decimal>() { decimal.Parse(quoteReal.Result.Value) }, Label = "Real" });

            return chartModels;
        }

        /// <summary>
        /// Get USD currency from estadisticasBcraApi
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get the currency from CambiosTodayApi
        /// </summary>
        /// <param name="currenciesCode"></param>
        /// <returns></returns>
        private async Task<CambioTodayModel> GetQuoteFromCambiosTodayAsync(CurrenciesCodeEnum currenciesCode)
        {
            try
            {
                this.httpClient = new HttpClient();
                CambioTodayModel cambioToday = new CambioTodayModel();

                CredentialsApi credentials = this.credentialsCurrencies.KeyValues[ExchangerEnum.CambioToday];
                
                string cambiosTodayURL = string.Format(credentials.URLBase, currenciesCode.ToString("g"), CurrenciesCodeEnum.ARS.ToString("g"), credentials.Key);

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
