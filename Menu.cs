using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_13
{
    class Menu
    {
        public void Welcome()
        {
            Console.WriteLine("\n\n\n\t\t\t* * * Шифр Цезаря * * *");
            Console.WriteLine("\n\n\n  Программа умеет шифровать текстовый файл с заданым" +
                           "\n ключем и расшифровывать при вводе верного ключа." +
                           "\n Для начала работы  необходимо указать путь к файлу" +
                           "\n и целочисленное значение в качестве ключа.");
        }

        public int Select()
        {
            Console.WriteLine("\n\n\n\t\t\t\tМеню:");
            Console.WriteLine("\t\t1. Кодировать\n\t\t2. Раскодировать");
            Console.Write("\n\t\t\t\t:_\b");
            int sel = Convert.ToInt32(Console.ReadLine());
            return sel;
        }
        
        public void Action()
        {
            char ch = 'y';
            while (ch == 'y')
            {
                int variant = Select();
                Console.Write("\n\nВведите слово или путь к текстовому файлу: ");
                string p = Console.ReadLine();
                Console.Write("\n\nВведите ключ для шифрования:_\b");
                int k = Convert.ToInt32(Console.ReadLine());

                Crypto crypto = new Crypto(k, p);
                
                switch (variant)
                {
                    case 1:
                        crypto.Encipher();
                        break;
                    case 2:
                        crypto.Decipher();
                        break;
                   
                    default:
                        Console.WriteLine("Введите верный номер действия");
                        break;
                }
                Console.WriteLine("\n\nВозврат в меню: - y" +
                    "\nЗакрыть программу: - e");
                ch = Convert.ToChar(Console.ReadLine());
               
            }
            
            
        }
    }    
    
} 
