using Proyecto.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;

namespace Proyecto.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Seccion2 : ContentPage
	{
		public Seccion2 ()
		{
			InitializeComponent ();

            BindingContext = SeguimientoViewModel.GetInstance();
        }
	}
}