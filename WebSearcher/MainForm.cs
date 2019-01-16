using System;
using System.Collections.Generic;
using System.Windows.Forms;

using WebSearcher.Interfaces;

namespace WebSearcher
{
    public partial class MainForm : Form, IView
    {
        public IController Controller { get { return m_controller;  } set { SetupController(value); } }

        public string StartUrl { get { return urlBox.Text; } }
        public string[] SearchedWords { get { return SplitWords(searchedWordsBox.Text); } }

        public uint CountThreads { get { return (uint)countThreadsSpinBox.Value; } }

        public uint MinCountThreads { get { return (uint)countThreadsSpinBox.Minimum; } set { countThreadsSpinBox.Minimum = value; } }
        public uint MaxCountThreads { get { return (uint)countThreadsSpinBox.Maximum; } set { countThreadsSpinBox.Maximum = value; } }

        private IController m_controller = null;

        public MainForm()
        {
            InitializeComponent();
        }

        public void ClearLog()
        {
            logBox.Clear();
        }

        public void Error(string message)
        {
            MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Log(string message)
        {
            logBox.AppendText(message + Environment.NewLine);
        }

        private string[] SplitWords(string text)
        {
            char[] spliters = { ' ', '\n', '\r' };

            return searchedWordsBox.Text.Split(spliters, StringSplitOptions.RemoveEmptyEntries);
        }

        private void SetupController(IController controller)
        {
            if (Controller != null)
            {
                Controller.OnRunning -= OnRunningChanged;
                Controller.OnStopped -= OnRunningChanged;
            }
            m_controller = controller;

            if (Controller != null)
            {
                Controller.OnRunning += OnRunningChanged;
                Controller.OnStopped += OnRunningChanged;
            }
        }

        private void OnRunningChanged()
        {
            bool enabled = !Controller.IsRunning;

            cancelButton.Enabled = Controller.IsRunning;

            urlBox.Enabled = enabled;
            runButton.Enabled = enabled;
            settingsBox.Enabled = enabled;
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            Controller?.Run();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Controller?.Cancel();
        }
    }
}
