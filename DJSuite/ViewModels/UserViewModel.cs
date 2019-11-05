using DJSuite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DJSuite.ViewModels
{
    class UserViewModel : BaseViewModel
    {
        public User user { get; set; }
        public UserViewModel(User user = null)
        {
            this.user = user;
        }

       
    }    
}
