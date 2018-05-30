using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_13
{
    class Crypto
    {
        private readonly string Abc = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public int Key;
        public string Path;

        public Crypto (int key, string path)
        {
            Key = key;
            Path = path;
        }
        // Метод шифрует текстровый файл, набранный на кирилице
        public void Encipher()
        {
            var s1 = File.ReadAllText(Path);    // чтение файла 
            var s = s1.ToLower();
            var str = "";
            int y = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!Char.IsLetter(s[i]))       // шифруются только символы алфавита
                    str += s[i];

                int x = Abc.IndexOf(s[i]);      // Метод string.IndexOf(Char) Возвращает индекс
                                                // с отсчетом от нуля первого вхождения 
                                                // указанного символа Юникода в данной строке.
                y = (x + Key) % Abc.Length;     // реализована формула Шифр Цезаря
                str += Abc[y];

            }
           
            File.WriteAllText(Path, str);        // Запись файла по указанному пути 
        }
        // Метод расшифровки текстового файла, набранный на кирилице
        public void Decipher()
        {
            var s = File.ReadAllText(Path);      // Чтение файла из указанного пути
            var str = "";
            int y = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!Char.IsLetter(s[i]))
                   str += s[i];

                int x = Abc.IndexOf(s[i]);
                y = (x - Key + Abc.Length) % Abc.Length;
                str += Abc[y];    
            }

            File.WriteAllText(Path, str); 
        }
        
    }
}
