using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;

namespace MZ
{
    public class MainWindow : Window
    {
        private int currentPanel = 0;
        private List<StackPanel> panelList = new List<StackPanel>();
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            panelList = XMLHelper.ReadXml("../../../ini/0.xml").ToList();
            Content = panelList[currentPanel];
        }

        public void NextPanel()
        {
            Content = panelList[++currentPanel];
        }

    }
}
