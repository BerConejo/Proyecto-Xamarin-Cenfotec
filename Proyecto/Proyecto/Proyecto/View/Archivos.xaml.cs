using Proyecto.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;

namespace Proyecto.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Archivos : ContentPage
	{
		public Archivos ()
		{
			InitializeComponent ();

            BindingContext = OrdenViewModel.GetInstance();
        }
	}
}