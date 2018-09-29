using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiyilookGhtk.Classes;
using YiyilookGhtk.Classes.DTOS;
using YiyilookGhtk.Classes.ResponseWrappers;

namespace YiyilookGhtk.API
{
    public interface IGhtkApi
    {
        Task<IResult<GhtkOrder>> GetStatusOrderAsync(string idOrder);

        Task<IResult<FeeInfo>> GetFeeInfo(FeeRequestObject feeObject);
    }
}
