﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NgocNhanShop.Business.System.Dtos
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên")]
        public string LastName { get; set; }
        [Display(Name = "Họ")]
        public string FirstName { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Tài khoản")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}
