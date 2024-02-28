using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CashierControl.Areas.Identity.Data;


public class Cashier : IdentityUser
{
    public string Name { get; set; }
    public bool AccessCode { get; set; }
}

