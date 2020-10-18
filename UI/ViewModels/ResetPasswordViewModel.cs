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
            Password = resetPassword.Password;
        }

        [ScaffoldColumn(false)]
        
        public string Token { get; set; }
        public string Password { get; set; }
    }
}