using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Projeto3.View
{
    public class NotaCliente : UserControl
    {
        public NotaCliente()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
