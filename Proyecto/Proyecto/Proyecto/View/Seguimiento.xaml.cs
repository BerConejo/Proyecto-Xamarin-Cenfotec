using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Seguimiento : TabbedPage
    {
        public Seguimiento ()
        {
            InitializeComponent();

            BarBackgroundColor = Color.FromHex("#3e91a3");

        }
    }
}