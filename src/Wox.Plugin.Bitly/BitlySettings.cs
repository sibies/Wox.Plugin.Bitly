using System.Windows.Controls;
using System.Diagnostics;
using System.CodeDom.Compiler;

namespace Wox.Plugin.Bitly
{
    public partial class BitlySettings : UserControl
    {
        public BitlySettings()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://support.bitly.com/hc/en-us/articles/231140388-How-do-I-find-my-API-key-");
        }

        [DebuggerNonUserCode, GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            //if (this._contentLoaded)
            //{
            //    return;
            //}
            //this._contentLoaded = true;
            //Uri resourceLocater = new Uri("/Wox.Plugin.Shell;component/shellsetting.xaml", UriKind.Relative);
            //Application.LoadComponent(this, resourceLocater);
        }

    }
}
