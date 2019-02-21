namespace Nash.Domain.Services
{
    using Nash.Domain.Enums;
    using Nash.Domain.Responses;
    using System.Threading.Tasks;

    public interface IExchangerService
    {
        Task<NashResponse> GetQuote(CurrenciesNameEnum currenciesName, CurrenciesCodeEnum currenciesCodeEnum);
    }
}
