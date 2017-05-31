using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Project_Diem_Danh
{
    public partial class Flashing : Form
    {
        public Flashing()
        {
            InitializeComponent();
        }
        private  Thread _splashThread;
        private  Flashing _splashForm;
        // Show the Splash Screen (Loading...)      
        public  void ShowSplash()
        {
            if (_splashThread == null)
            {
                // show the form in a new thread            
                _splashThread = new Thread(new ThreadStart(DoShowSplash));
                _splashThread.IsBackground = true;
                _splashThread.Start();
            }
        }
        // Called by the thread    
        private  void DoShowSplash()
        {
            if (_splashForm == null)
            {
                _splashForm = new Flashing();
                _splashForm.StartPosition = FormStartPosition.CenterScreen;
                _splashForm.TopMost = true;
            }
            // create a new message pump on this thread (started from ShowSplash)        
            Application.Run(_splashForm);
        }
        // Close the splash (Loading...) screen    
        public  void CloseSplash()
        {
            // Need to call on the thread that launched this splash   
            try
            {
                if (_splashForm.InvokeRequired)
                {
                    _splashForm.Invoke(new MethodInvoker(CloseSplash));
                    _splashThread = null;
                }

                else
                {
                    Application.ExitThread();
                    //_splashThread = null; 
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }
    }
}
