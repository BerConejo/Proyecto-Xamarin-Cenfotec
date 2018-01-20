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
    public partial class Seccion1 : ContentPage
    {
        public Seccion1()
        {
            InitializeComponent();

            BindingContext = SeguimientoViewModel.GetInstance();
        }
        private void LugarAsistenciaLabel_OnTapped(object sender, EventArgs e)
        {
            LugarAsistencia.Focus();
        }

        private void LugarAsistencia_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LugarAsistenciaLabel.Text = LugarAsistencia.Items[LugarAsistencia.SelectedIndex];
        }

        private void EstadoOrdenLabel_OnTapped(object sender, EventArgs e)
        {
            EstadoOrden.Focus();
        }

        private void EstadoOrden_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            EstadoOrdenLabel.Text = EstadoOrden.Items[EstadoOrden.SelectedIndex];
        }

    }
}