using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using NoSQL.Models;

namespace NoSQL.UI.ViewModels
{

    public class ResetPasswordViewModel
    {
        public ResetPasswordViewModel()
        {
        }

        public ResetPasswordViewModel(ResetPassword resetPassword)
        {
            Token = resetPassword.ReturnToken;
        }
        
        public string Token { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}