using CoreAutomotive.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoreAutomotive.ViewComponents
{
    public class HeadingViewComponent : ViewComponent
    {

        public HeadingViewComponent()
        {
        }

        public async Task <IViewComponentResult> InvokeAsync(HeadingVM vm)
        {
            return View(vm);
        }


    }
}