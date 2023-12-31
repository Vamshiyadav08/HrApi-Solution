﻿using HrApi.Attribute;

namespace HrApi.DTOs
{
    public class ResetPasswordDTO
    {
        [NotEmpty(ErrorMessage = "Password must not be empty.")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must contain At least one lower case letter,At least one upper case letter,At least special character,At least one number,At least 8 characters length.")]
        public string OrginalPassword { get; set; } = null!;

        [NotEmpty(ErrorMessage = "Password must not be empty.")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must contain At least one lower case letter,At least one upper case letter,At least special character,At least one number,At least 8 characters length.")]
        public string ResetPassword { get; set; } = null!;
    }
}
