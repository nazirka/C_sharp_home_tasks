using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class TTextClass
    {
        public TTextClass()  
        {
            Dictionary = new TDictionary();
            m_Encoding = Encoding.Default;
        }

        ~TTextClass()
        { 
            
        }
        

        const int MAX_COUNT_STRINGS_HTML = 1024;
        const int MAX_BUFFER_SIZE_TEXT = 256;

        private Encoding m_Encoding;
        private string   m_Write_File_Name;

        public TDictionary  Dictionary;
        public string       Read_File_Name;


        private void Write_HTML_start(FileStream f_html)
        {
            string S = "<html><body><p>\r\n";
            f_html.Write(m_Encoding.GetBytes(S), 0, m_Encoding.GetByteCount(S));
        }

        private void Write_HTML_stop(FileStream f_html)
        {
            string S = "\r\n</p></body></html>";
            f_html.Write(m_Encoding.GetBytes(S), 0, m_Encoding.GetByteCount(S));
        }

        private void Write_HTML_end_string(FileStream f_html)
        {
            string S = "<br>";
            f_html.Write(m_Encoding.GetBytes(S), 0, m_Encoding.GetByteCount(S));
        }

        private void Write_HTML_start_textBOLD(FileStream f_html)
        {
            string S = "<b><i>";
            f_html.Write(m_Encoding.GetBytes(S), 0, m_Encoding.GetByteCount(S));
        }

        private void Write_HTML_stop_textBOLD(FileStream f_html)
        {
            string S = "</i></b>";
            f_html.Write(m_Encoding.GetBytes(S), 0, m_Encoding.GetByteCount(S));
        }

        private void Write_HTML_text(FileStream f_html, string S)
        {
            f_html.Write(m_Encoding.GetBytes(S), 0, m_Encoding.GetByteCount(S));
        }
        
        public  bool Convert()
        {
            if (Read_File_Name == "")    return false;

            //символ конца строки
            string separator_end_str = "\r\n";
            
            if (!File.Exists(Read_File_Name))
                {
                    MessageBox.Show("Файл текста отсутствует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

            //открытие файла
            FileStream FS_text;
            try
            {
                FS_text = File.OpenRead(Read_File_Name);                
            }
            catch
            {                
                MessageBox.Show("Ошибка открытия файла текста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            int FRead_Pos = 0;

            //получение размера файла и создание буфера
            FileInfo f = new FileInfo(Read_File_Name);
            long FTextSize = f.Length;
            if (FTextSize == 0)
                {
                    FS_text.Close();             
                    MessageBox.Show("Файл текста пуст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            
            //буфер чтения            
            byte[]  Buffer_read = new byte[MAX_BUFFER_SIZE_TEXT];

            //номер файла HTML
            int count_html_file = 1;
            bool Close_All = false;

            while (!Close_All)
                {
                    //файл записи
                    m_Write_File_Name = Read_File_Name;
                    if (count_html_file > 1)
                        m_Write_File_Name = m_Write_File_Name.Insert(m_Write_File_Name.Length - 4, count_html_file.ToString());
                    m_Write_File_Name = m_Write_File_Name.Remove(m_Write_File_Name.Length - 3, 3);
                    m_Write_File_Name = m_Write_File_Name.Insert(m_Write_File_Name.Length, "htm");

                    //создание файла HTML
                    FileStream FS_html;
                    try
                    {
                        FS_html = File.Open(m_Write_File_Name, FileMode.Create);
                    }
                    catch
                    {
                        FS_text.Close();
                        MessageBox.Show("Ошибка создания файла HTML", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                                
                    //счетчик строк
                    ulong count_strings_HTML = 0;

                    //запись заголовка HTML файла
                    Write_HTML_start(FS_html);
                
                    //цикл обработки!
                    while (!Close_All)
                        {
                            //установка указателя начала считывания
                            FS_text.Seek(FRead_Pos, SeekOrigin.Begin);
                                                   
                            //чтение буфера из файла
                            int buffer_readed = FS_text.Read(Buffer_read, 0, MAX_BUFFER_SIZE_TEXT);
                            if (buffer_readed == 0)
                                {
                                    FS_text.Close();
                                    FS_html.Close();
                                    MessageBox.Show("Ошибка чтения файла текста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return false;
                                }
                        
                            //поиск конца файла
                            bool end_of_file = ((buffer_readed > 0) && (buffer_readed < MAX_BUFFER_SIZE_TEXT));
                            
                            //перевод буфера в строку
                            string Buf_str = m_Encoding.GetString(Buffer_read, 0, buffer_readed);

                            //поиск конца строки
                            bool find_end_str = false;                        
                            int str_end_pos = Buf_str.IndexOf(separator_end_str, 0);
                            if (str_end_pos > 0)
                                find_end_str = true;
                            else
                                str_end_pos = Buf_str.Length; //позиция понца строки

                            //поиск слов
                            string word_separator = " ";
                            int words_pos = 0;
                            string  tmp_word = "";
                            while (words_pos < str_end_pos)
                                {
                                    int Pos = Buf_str.IndexOf(word_separator, words_pos);
                                    int L = 0;
                                    if (Pos >= words_pos)  //найдено
                                        L = Pos - words_pos;
                                    else  //последнее слово - если нойден признак конца строки в буфере или конец файла
                                        if (find_end_str || end_of_file)
                                            L = Buf_str.Length - words_pos;
                                        else //выход
                                            break;

                                    tmp_word = Buf_str.Substring(words_pos, L);
                        
                                    words_pos += L;
                                    if (Pos >= 0)   words_pos += word_separator.Length;
                                
                                    //поиск в словаре
                                    bool exist_word = Dictionary.Exist_Word_In_Dictionary(tmp_word);

                                    //=========запись в HTML==========
                                    //запись тэгов
                                    if (exist_word)
                                        Write_HTML_start_textBOLD(FS_html);
                        
                                    //запись текста
                                    if (Pos >= 0)   tmp_word += word_separator;
                                        Write_HTML_text(FS_html, tmp_word);
    
                                    //запись тэгов
                                    if (exist_word)
                                        Write_HTML_stop_textBOLD(FS_html);                        
                                }
                    

                            //рассчет новой позиции для чтения
                            FRead_Pos += words_pos;                            
                            if (find_end_str) FRead_Pos += m_Encoding.GetByteCount(separator_end_str);
                       
                            //запись конца строки
                            if (find_end_str)
                                {
                                    Write_HTML_end_string(FS_html);
                                    count_strings_HTML++;
                                }
                        
                            //проверка на количество строк
                            if (count_strings_HTML >= MAX_COUNT_STRINGS_HTML)
                                {
                                    count_strings_HTML = 0;
                                    count_html_file++;
                                    break;
                                }

                            if (FRead_Pos >= FTextSize - 1)      Close_All = true;
                        }
                        
                    //запись окончания HTML файла
                    Write_HTML_stop(FS_html);

                    FS_html.Close();      
                }
           
            FS_text.Close();

            return true;
        }  //function Convert

    } //class
}
