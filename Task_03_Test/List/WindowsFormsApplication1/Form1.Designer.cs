namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.загрузкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьФайлСловаряToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьФайлТекстаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преобразоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузкаToolStripMenuItem,
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(353, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // загрузкаToolStripMenuItem
            // 
            this.загрузкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьФайлСловаряToolStripMenuItem});
            this.загрузкаToolStripMenuItem.Name = "загрузкаToolStripMenuItem";
            this.загрузкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.загрузкаToolStripMenuItem.Text = "Загрузка";
            // 
            // загрузитьФайлСловаряToolStripMenuItem
            // 
            this.загрузитьФайлСловаряToolStripMenuItem.Name = "загрузитьФайлСловаряToolStripMenuItem";
            this.загрузитьФайлСловаряToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.загрузитьФайлСловаряToolStripMenuItem.Text = "Загрузить файл словаря...";
            this.загрузитьФайлСловаряToolStripMenuItem.Click += new System.EventHandler(this.загрузитьФайлСловаряToolStripMenuItem_Click);
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьФайлТекстаToolStripMenuItem,
            this.преобразоватьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // выбратьФайлТекстаToolStripMenuItem
            // 
            this.выбратьФайлТекстаToolStripMenuItem.Name = "выбратьФайлТекстаToolStripMenuItem";
            this.выбратьФайлТекстаToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.выбратьФайлТекстаToolStripMenuItem.Text = "Выбрать файл текста...";
            this.выбратьФайлТекстаToolStripMenuItem.Click += new System.EventHandler(this.выбратьФайлТекстаToolStripMenuItem_Click);
            // 
            // преобразоватьToolStripMenuItem
            // 
            this.преобразоватьToolStripMenuItem.Name = "преобразоватьToolStripMenuItem";
            this.преобразоватьToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.преобразоватьToolStripMenuItem.Text = "Преобразовать";
            this.преобразоватьToolStripMenuItem.Click += new System.EventHandler(this.преобразоватьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 298);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестовое задание";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem загрузкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьФайлСловаряToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьФайлТекстаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преобразоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

