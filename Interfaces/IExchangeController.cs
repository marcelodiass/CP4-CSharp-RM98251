using Microsoft.AspNetCore.Mvc;

namespace CP4_RM98251.Interfaces
{
    public interface IExchangeController
    {
        JsonResult GetExchangeRate();
    }

}
