using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace homeWorkLesson6_3
{
    public partial class MainForm : Form
    {
        private Assembly assembly = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    assembly = Assembly.LoadFile(dlg.FileName);

                    textBoxOutput.Text = $"Сборка: {dlg.FileName} загружена!\n" + Environment.NewLine + Environment.NewLine;

                    Type[] types = assembly.GetTypes();

                    foreach (var type in types)
                    {
                        textBoxOutput.Text += $"Тип: {type}\n" + Environment.NewLine + Environment.NewLine;

                        var typeMethod = type.GetMethods();

                        if (typeMethod != null)
                        {
                            foreach (var method in typeMethod)
                            {
                                textBoxOutput.Text += $"Имя метода:{method.Name}" + Environment.NewLine + Environment.NewLine;
                                textBoxOutput.Text += $"Является ли метод статическим:{method.IsStatic}\n" + Environment.NewLine + Environment.NewLine;
                                textBoxOutput.Text += $"Является ли метод абстракным:{method.IsAbstract}\n" + Environment.NewLine + Environment.NewLine;
                                textBoxOutput.Text += $"Является ли метод закрытым:{method.IsPrivate} " + Environment.NewLine + Environment.NewLine;
                            }
                        }

                        var typeFields = type.GetFields();
                        if (typeFields != null)
                        {
                            foreach (var typeField in typeFields)
                            {
                                textBoxOutput.Text += $"Имя поля:{typeField.Name}\n" + Environment.NewLine + Environment.NewLine;
                                textBoxOutput.Text += $"Тип поля:{typeField.FieldType}" + Environment.NewLine + Environment.NewLine;
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Возникла ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
