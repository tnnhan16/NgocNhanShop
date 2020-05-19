using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Validator.Message
{
    public class MessageValidator_VN
    {
        public const string isRequire = @"{0} không được rỗng.";

        public const string maxLenght = @"{0} không được nhiều hơn {1} ký tự.";

        public const string minLenght = @"{0} không được ít hơn {1} ký tự.";

        public const string email = @"{0} không phải là định dạng email.";

        public const string number = @"{0} không phải là định dạng số.";

        public const string phone = @"{0} không phải là định dạng số điện thoại.";

        public const string maxYear = @"{0} không được lớn hơn {1} năm.";

        public const string minDay = @"{0} không được nhỏ hơn {1} ngày hiện tại.";

        public const string isComformPassword = @"{0} không nhập khớp với mật khẩu trên.";

        public const string existUserName = @"{0} đã tồn tại trên hệ thống.";

    }
}
