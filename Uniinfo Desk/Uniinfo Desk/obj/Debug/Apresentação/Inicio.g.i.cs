#pragma checksum "..\..\..\Apresentação\Inicio.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E795EDA583E6784E343E0F791ACC842E5BE54892"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Uniinfo_Desk.Apresentação;
using Uniinfo_Desk.Properties;


namespace Uniinfo_Desk.Apresentação
{


    /// <summary>
    /// Inicio
    /// </summary>
    public partial class Inicio : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 11 "..\..\..\Apresentação\Inicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLoggout;

#line default
#line hidden


#line 19 "..\..\..\Apresentação\Inicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExibirChamado;

#line default
#line hidden


#line 31 "..\..\..\Apresentação\Inicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Uniinfo Desk;component/apresenta%c3%a7%c3%a3o/inicio.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Apresentação\Inicio.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.mnConsulta = ((Uniinfo_Desk.Apresentação.Inicio)(target));
                    return;
                case 2:
                    this.btnLoggout = ((System.Windows.Controls.Button)(target));

#line 11 "..\..\..\Apresentação\Inicio.xaml"
                    this.btnLoggout.Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.btnExibirChamado = ((System.Windows.Controls.Button)(target));

#line 19 "..\..\..\Apresentação\Inicio.xaml"
                    this.btnExibirChamado.Click += new System.Windows.RoutedEventHandler(this.btnLogar_Click_1);

#line default
#line hidden
                    return;
                case 4:
                    this.grid = ((System.Windows.Controls.DataGrid)(target));

#line 31 "..\..\..\Apresentação\Inicio.xaml"
                    this.grid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window mnConsulta;
    }
}

