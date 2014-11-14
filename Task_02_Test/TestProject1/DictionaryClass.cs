using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace WindowsFormsApplication1
{
    class TDictionary
    {
        private List<string> m_Word_List;
        
        public TDictionary()
        {
            m_Word_List = new List<string>();
        }

        ~TDictionary()
        {
            Clear();
        }


        public void Clear()
        {
            m_Word_List.Clear();
        }

        public bool Load_From_File(string filename, string separator)
        {
            if (filename == "")     return false;
            if (separator == "")    return false;

            //открытие файла
            if (!File.Exists(filename))
            {
                //MessageBox.Show("Файл словаря отсутствует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            
            FileStream FS_dict;
            try
            {
                FS_dict = File.OpenRead(filename);                
            }
            catch
            {                
                //MessageBox.Show("Ошибка открытия файла словаря", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
                        
            //получение размера файла
            FileInfo f = new FileInfo(filename);
            long FTextSize = f.Length;
            if (FTextSize == 0)
                {
                    FS_dict.Close();             
                    //MessageBox.Show("Файл текста пуст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

            //создание массива
            byte[]  Buffer_read = new byte[FTextSize];

            //чтение всего файла
            int buffer_readed = FS_dict.Read(Buffer_read, 0, (int)FTextSize);
            if ((buffer_readed == 0) || (buffer_readed != FTextSize))
                {
                    FS_dict.Close();
                    //MessageBox.Show("Ошибка чтения файла текста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

            //перевод в строку
            Encoding m_Encoding = Encoding.Default;
            string Buf_str = m_Encoding.GetString(Buffer_read, 0, buffer_readed);

            //перевод в список
            Clear();

            //m_Word_List = Buf_str.Split(separator.ToCharArray()).ToList();
            
            int words_pos = 0;
            string  tmp_word = "";
            while (words_pos < Buf_str.Length)
            {
                int Pos = Buf_str.IndexOf(separator, words_pos);
                int L = 0;
                if (Pos >= words_pos)  //найдено
                    L = Pos - words_pos;
                else  //последнее слово
                    L = Buf_str.Length - words_pos;

                tmp_word = Buf_str.Substring(words_pos, L);

                words_pos += L;
                if (Pos >= 0) words_pos += separator.Length;

				if (!Exist_Word_In_Dictionary(tmp_word))
					m_Word_List.Add(tmp_word);
            }

            return true;            
        }

        public bool Exist_Word_In_Dictionary(string Word)
        {
            if (Word == "")             return false;
            if (m_Word_List.Count == 0) return false;

            for (int i = 0; i < m_Word_List.Count; i++)
                if (m_Word_List.ElementAt(i) == Word)
                    return true;
           
            return false;
        }
        
    }
}
