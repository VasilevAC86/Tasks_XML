using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tasks_XML
{
    public class XmlHelper
    {
        public static Grid DeserializeXml(string xmlPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Grid));
            using (StreamReader reader = new StreamReader(xmlPath))
            {
                Grid grid = (Grid)serializer.Deserialize(reader);
                // Преобразование строк "True" и "False" в булевые значения
                foreach (var dockPanel in grid.DockPanels)
                {
                    if (dockPanel.LastChildFill == "True")
                        dockPanel.LastChildFill = "true";
                    else if (dockPanel.LastChildFill == "False")
                        dockPanel.LastChildFill = "false";
                }
                return grid;
            }            
        }
        // После того, как мы что-нибудь поменяем в объектах, записываем в файл изменённые данные
        public static void SerializeXml(Grid grid, string xmlPath) 
        {
            XmlSerializer ser = new XmlSerializer(typeof(Grid));
            using (StreamWriter writer = new StreamWriter(xmlPath)) 
            { 
                ser.Serialize(writer, grid); 
            }
        }
        // Метод для добавления текст-блоков
        public static void AddTextBlock(Grid grid, string text, string dock, int fontSize, string horizontalAligment)
        {
            TextBlock newTextBlock = new TextBlock
            {
                Text = text,
                Dock = dock,
                FontSize = fontSize,
                HorizontalAlignment = horizontalAligment
            };
            DockPanel targetDocPanel = grid.DockPanels[0]; // Выбираем первый DockPanels для примера
            targetDocPanel.Elements.Add(newTextBlock);
        }  
        public static void AddButton (Grid grid, string text, string doc, int gridColumn, int maxWidth, int minHeight, string background, string margin, string padding, string click)
        {
            Button newButton = new Button
            {
                Text = text,
                Dock = doc,
                GridColumn = gridColumn,
                MaxWidth = maxWidth,
                MinHeight = minHeight,
                Background = background,
                Margin = margin,
                Padding = padding,
                Click = click
            };
            DockPanel targetDockPanel = grid.DockPanels[0]; // Выбираем первый DockPanels для примера
            targetDockPanel.Elements.Add(newButton);
        }
        public static void AddAll<T>()
        {
            GroupBox groupBox = new GroupBox
            {
                StackPanel = new StackPanel
                {
                    TextBlocks = new List<TextBlock>
                    {
                        new TextBlock
                        {
                            Dock = "dock_1",
                            FontSize = 10,
                            HorizontalAlignment = "Centre"
                        },
                        new TextBlock
                        {
                            Dock = "dock_2",
                            FontSize = 100,
                            HorizontalAlignment = "Down"
                        },
                        new TextBlock
                        {
                            Dock = "dock1",
                            FontSize = 10,
                            HorizontalAlignment = "Centre"
                        }
                    }
                }
            };

        }
    }
}
