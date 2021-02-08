using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MZ
{
    class XMLHelper
    {
        public static IReadOnlyList<StackPanel> ReadXml(string filename)
        {
            var list = new List<StackPanel>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            if (xmlDoc.ChildNodes.Count < 2 && xmlDoc.ChildNodes[1].LocalName != "MZ") throw new ArgumentException();

            foreach (XmlNode rootElement in xmlDoc.ChildNodes)
            {
                foreach (XmlNode item in rootElement)
                {
                    if (item.LocalName == "StackPanel")
                    {
                        list.Add(MakeControls(item));
                    }
                }
            }
            return list;
        }

        private static StackPanel MakeControls(XmlNode node)
        {
            var panel = new StackPanel();

            foreach (XmlNode item in node.ChildNodes)
            {
                if (item.LocalName == "TextBox")
                {
                    var textbox = new TextBox
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        Text = item.Attributes["Text"].Value
                    };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    panel.Children.Add(textbox);
                }
                else if (item.LocalName == "Button")
                {
                    var button = new Button
                    {
                        Content = item.InnerText,
                    };
                    button.Click += (sender, args) =>
                    {
                        button.Content = "Clicked";
                    };
                    panel.Children.Add(button);
                }
            }
            return panel;
        }


    }
}
