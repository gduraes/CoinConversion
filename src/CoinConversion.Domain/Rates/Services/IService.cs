using System.Collections.Generic;

namespace CoinConversion.Domain.Rates.Services
{
    public interface IService<T>
    {
        List<T> GetAllRates();
        object Calculate(T model);
    }
}
