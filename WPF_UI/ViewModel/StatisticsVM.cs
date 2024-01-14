using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.ViewModel
{
    class StatisticsVM: Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public StatisticsVM()
        {
            _pageModel = new PageModel();
        }
    }
}
