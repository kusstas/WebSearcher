using System;
using System.Windows.Forms;

using WebSearcher.Interfaces;
using WebSearcher.Ctrl;

namespace WebSearcher
{
    static class Program
    {
        /// <summary>
        /// Entry point of programm
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();
            Controller controller = new Controller();
            Model model = new Model();

            mainForm.Controller = controller;
            controller.View = mainForm;
            controller.Model = model;

            Application.Run(mainForm);
        }
    }
}
