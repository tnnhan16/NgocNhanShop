using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.Common.Dtos
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }

        public T ResultObj { get; set; }

        public List<T> ListError { get; set; }
    }
}
