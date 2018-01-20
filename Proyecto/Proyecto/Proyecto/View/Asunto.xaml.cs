using Proyecto.ViewModel;
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
	public partial class Asunto : ContentPage
	{
        OrdenViewModel OrdenViewModel = OrdenViewModel.GetInstance();
        public Asunto()
        {
            InitializeComponent();

            BindingContext = OrdenViewModel.GetInstance();
        }

        private void EntryOrden_Completed(object sender, EventArgs e)
        {
            OrdenViewModel.cargaOrden();

        }
	}
}