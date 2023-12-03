
using System;

namespace les8
{
    class Program
    {

        //Объедините две предыдущих работы(практические работы 2 и 3): поиск файла и поиск текста в файле
        //написав утилиту которая ищет файлы определенного расширения с указанным текстом.Рекурсивно.
        //Пример вызова утилиты: utility.exe txt текст.

     
            static void Main(string[] args)
            {
            try
            {
                string directory = "D:\\Users\\mkn\\Desktop\\developer\\C#\\GB_projects\\les1\\";
                string fileName = "text.txt";
                string searchValue = "3333";

                FileSearchUtility.SearchForFile(directory, fileName);
                FileSearchUtility.SearchForValueInFile(fileName, searchValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
              
            }

        }
    }

