﻿using HeBianGu.Base.WpfBase;
using HeBianGu.Service.Mvc;
using System;
using System.Threading.Tasks;

namespace HeBianGu.App.Tool
{
    [Controller("Loyout")]
    internal class LoyoutController : Controller<LoyoutViewModel>
    {
        public async Task<IActionResult> Home()
        {
            return await ViewAsync();
        }
    }
}
