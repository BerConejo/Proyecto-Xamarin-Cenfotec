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
	public partial class Sistema : ContentPage
	{
		public Sistema ()
		{
			InitializeComponent ();

            BindingContext = OrdenViewModel.GetInstance();
        }

        #region picker
        private void TipoDocumentoLabel_OnTapped(object sender, EventArgs e)
        {
            TipoDocumento.Focus();
        }

        private void TipoDocumento_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            TipoDocumentoLabel.Text = TipoDocumento.Items[TipoDocumento.SelectedIndex];
        }

        private void TipoOrdenLabel_OnTapped(object sender, EventArgs e)
        {
            TipoOrden.Focus();
        }

        private void TipoOrden_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            TipoOrdenLabel.Text = TipoOrden.Items[TipoOrden.SelectedIndex];
        }

        private void TipoRecepcionLabel_OnTapped(object sender, EventArgs e)
        {
            TipoRecepcion.Focus();
        }

        private void TipoRecepcion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            TipoRecepcionLabel.Text = TipoRecepcion.Items[TipoRecepcion.SelectedIndex];
        }

        private void TipoServicioLabel_OnTapped(object sender, EventArgs e)
        {
            TipoServicio.Focus();
        }

        private void TipoServicio_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            TipoServicioLabel.Text = TipoServicio.Items[TipoServicio.SelectedIndex];
        }

        private void TipoAjusteLabel_OnTapped(object sender, EventArgs e)
        {
            TipoAjuste.Focus();
        }

        private void TipoAjuste_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            TipoAjusteLabel.Text = TipoAjuste.Items[TipoAjuste.SelectedIndex];
        }

        private void TipoSistemaLabel_OnTapped(object sender, EventArgs e)
        {
            TipoSistema.Focus();
        }

        private void TipoSistema_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            TipoSistemaLabel.Text = TipoSistema.Items[TipoSistema.SelectedIndex];
        }

        #endregion picker

    }
}