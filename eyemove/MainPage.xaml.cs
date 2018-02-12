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
using System.Drawing;
using Windows.UI.Core;

namespace eyemove
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CoreCursor buttonCursor = null;
        CoreCursor cursorBeforePointerEntered = null;
        public MainPage()
        {
            this.InitializeComponent();
            buttonCursor = new CoreCursor(CoreCursorType.Hand, 0);
    }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("nope");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();


        }
        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            // Cache the cursor set before pointer enter on button.
            cursorBeforePointerEntered = Window.Current.CoreWindow.PointerCursor;
            // Set button cursor.
            Window.Current.CoreWindow.PointerCursor = buttonCursor;
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            // Change the cursor back.
            Window.Current.CoreWindow.PointerCursor = cursorBeforePointerEntered;
        }
    }
}
