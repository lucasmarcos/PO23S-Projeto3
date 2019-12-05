using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Projeto3
{
    public class JanelaPrincipal : Window
    {
        public JanelaPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}