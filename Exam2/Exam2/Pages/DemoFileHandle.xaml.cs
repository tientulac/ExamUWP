using Exam2.Models;
using Exam2.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exam2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoFileHandle : Page
    {
        public DemoFileHandle()
        {
            this.InitializeComponent();
        }
        private void register(object sender, RoutedEventArgs e)
        {
            string name_a = user_name.Text;
            string password_a = password.Text;

            UserAccount c = new UserAccount(1, name_a, password_a);
            User user = new User();
            user.Register(c);
            txtBlock.Text = "Ban da dang ki thanh cong ! Nhap lai vao form de dang nhap ^ ^";
            user_name.Text = "";
            password.Text = "";
        }
        private async void login(object sender, RoutedEventArgs e)
        {
            User user = new User();
            var a = user.GetUser();
            string name_a_login = user_name.Text;
            string password_a_login = password.Text;
            foreach (var account in a)
            {
                if (account.user_name.ToString() == name_a_login && account.password.ToString() == password_a_login)
                {
                    txtLogin.Text = "Ban da dang nhap thanh cong !";
                    MediaElement mediaElement = new MediaElement();
                    var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
                    Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("You have Login Success ! Thank you ");
                    mediaElement.SetSource(stream, stream.ContentType);
                    mediaElement.Play();
                }
                else
                {
                    txtLogin.Text = "Dang nhap that bai !";
                    MediaElement mediaElement = new MediaElement();
                    var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
                    Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("You have Login Fail ! Thank you");
                    mediaElement.SetSource(stream, stream.ContentType);
                    mediaElement.Play();
                }
            }
        }
    }
}
