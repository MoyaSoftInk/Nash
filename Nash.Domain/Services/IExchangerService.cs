namespace Nash.Domain.Services
{
    using Nash.Domain.Enums;
    using Nash.Domain.Responses;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface ExchangerService.
    /// </summary>
    public interface IExchangerService
    {
        /// <summary>
        /// Get the quote of currency
        /// </summary>
        /// <param name="currenciesName"></param>
        /// <param name="currenciesCodeEnum"></param>
        /// <returns></returns>
        Task<NashResponse> GetQuote(CurrenciesNameEnum currenciesName, CurrenciesCodeEnum currenciesCodeEnum);
    }
}
