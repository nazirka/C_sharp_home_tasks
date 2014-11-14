using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WindowsFormsApplication1;

namespace TestProject1
{
    /// <summary>
    /// Сводное описание для UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        ///

        TTextClass m_Text;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_Text()
        {
            m_Text = new TTextClass();

            //запуск с пустым файлом
            Assert.IsFalse(m_Text.Dictionary.Load_From_File("", "\r\n"));

            //запуск с несуществующим файлом
            Assert.IsFalse(m_Text.Dictionary.Load_From_File("MazaFucka.txt", "\r\n"));

            //запуск с нормальным файлом
            Assert.IsFalse(!m_Text.Dictionary.Load_From_File("D:\\Dictionary.txt", "\r\n"));

            //проверка с пустым именем файла
            m_Text.Read_File_Name = "";
            Assert.IsFalse(m_Text.Convert());
            
            //проверка с пустым именем файла
            m_Text.Read_File_Name = "D:\\Text.txt";
            Assert.IsFalse(!m_Text.Convert());
            
        }

    }
}
