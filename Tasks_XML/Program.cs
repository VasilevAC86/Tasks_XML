namespace Tasks_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xmlPath = "XML.xml";
            Grid grid = XmlHelper.DeserializeXml("XML.xml");
            XmlHelper xmlHelper = new XmlHelper();
            XmlHelper.AddButton(grid, "Обновить", "Новая", 15, 50, 5, "Чёрный", "08500", "5", "Да фиг знает что делает");
            XmlHelper.AddTextBlock(grid, "Новый текстовый блок", "Топ", 20, "Center");
            XmlHelper.SerializeXml(grid, xmlPath);
            Console.WriteLine("Элементы добавлены и XML файл обновлён");
        }
    }
}
