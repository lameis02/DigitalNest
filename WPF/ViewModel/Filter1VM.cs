using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.ViewModel
{
    class Filter1VM: Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public Filter1VM()
        {
            _pageModel = new PageModel();
        }
    }
}
