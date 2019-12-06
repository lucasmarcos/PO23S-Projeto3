using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Projeto3.View
{
    public class NotaProdutoComprado : UserControl
    {
        public NotaProdutoComprado()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
