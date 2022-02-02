using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class AccountViewModel
    {
        public LoginViewModel Login { get; set; }
        public RegisterViewModel Register { get; set; }

    }
}
