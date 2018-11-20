using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HLS.ViewModels
{
    class BaseLifeUnitsViewModel
    {
        private readonly ContentPage _parentPage;
        
        BaseLifeUnitsViewModel(ContentPage page)
        {
            _parentPage = page;
            
        }
    }
}
