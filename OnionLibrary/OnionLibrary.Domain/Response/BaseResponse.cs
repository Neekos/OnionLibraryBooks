using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using OnionLibrary.Domain.Enum;

namespace OnionLibrary.Domain.Response
{
    public class BaseResponse<T>:IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode Status { get; set; }
        public T Data { get; set; }

    }
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
        StatusCode Status { get; }
    }
}
