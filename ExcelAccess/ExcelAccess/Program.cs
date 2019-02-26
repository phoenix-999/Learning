using System;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;


namespace ExcelAccess
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            string path = @"files.txt";
            //int count = System.IO.File.ReadAllLines(path).Length;

            //FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None);
            //fs.Close();
            Encoding enc;
            Stream fs = new FileStream("files.txt", FileMode.Open);
            using (StreamReader sr = new StreamReader(fs, true))
                enc = sr.CurrentEncoding;
            fs.Close();
            string[] readText = File.ReadAllLines(path, Encoding.Default);
            ExcelWork ew = new ExcelAccess.ExcelWork();
            foreach (string s in readText)
            {
                try
                {
                    ew.RefreshExcel(s.Trim());
                    string message = DateTime.Now.ToString() + "\tФайл "+s+" обновлен" + "\r\n";
                    File.AppendAllText("log.txt", message);
                }
                catch (Exception e)
                {
                    string message = DateTime.Now.ToString() + e.ToString() + "\r\n";
                    File.AppendAllText("log.txt", message);
                }
            }       
        }           
    }
    class ExcelWork
    {
        private Excel.Workbook fileExcel;
        public void RefreshExcel(string filename)
        {

            Excel.Application excel = new Excel.Application(); //создаем COM-объект Excel

            excel.Visible = false; //true - показывать / false - не показывать приложения Excel.

            //excel.SheetsInNewWorkbook = 3; //Количество листов

            //excel.Workbooks.Add(Type.Missing); //Открыть новую книгу Excel

            fileExcel = excel.Workbooks.Open(filename); //Открыть существующую книгу Excel

            fileExcel.RefreshAll(); //Обновить книгу Excel.

            fileExcel.Save(); //Сохранить книгу Excel.

            fileExcel.Close(); //Закрытие книгу Excel.

            excel.Quit(); //Закрытие приложения Excel.

            //Обнуляем созданые объекты
            fileExcel = null;
            excel = null;

            //Вызываем сборщик мусора для их уничтожения и освобождения памяти
            GC.Collect();
        }
        
    }
}
