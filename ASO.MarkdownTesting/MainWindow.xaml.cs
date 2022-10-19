using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using ASO.Markdown;
using ASO.Markdown.MarkdownServise;
using Markdig;
using Markdig.Wpf;

namespace ASO.MarkdownTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {e.Parameter}") { CreateNoWindow = true });
            /*
             * http запрос, узнать что за содержание вернет видео или фильм
             */
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            player.SetSource(new System.Uri(@"https://save4k.ru/video.php?url=UUZGFkBYGkkRB1ZbRQYFFQpDHVJdVl4JUk5fAQELFlFWXx0QWgZQCRMOU0tVAgUKWlRLRVtLXFgGDgBQUVUJBggCFANaX14KFyRrCkYBKA4yBV55c2lSL0JVAiQtQlFCBAcDSARVG1dSWxwGA0UPBVheHnR2UAw1RUtAC1QxXENtH1RTfAUFXiQYQFhONCsHPUFWd1ZVUQZcaWI1Vi5eFFBGUwEOUAdAEA1HQFQGWxgKREdAUFwfF1JJQwwWAUtBVQ9LA0BEWA5eT0gUWg5bUlQUAXYAAB8IWQVFC0kFUVVVBFwDQUcHJRAMH1NeBBwTC0JJE19KBARCHQQmFgBNFFREDwsVD0MPXlMUQlteVFNDQVBYAARXChFRWAwQB09cXVBCFQ5QA1BRVwIUQRMUF1gAFVhbVFxYQVFSAAtBCnRUQgZAUAxHW1JWFEBWFwMDHEFSRkEEQABEHlIQFlkLBAEcAV4HRFkLF18DBARWUFVTAAMECwAIXA8IEAgQWQkEDwcGXgpWAF9FBERbR15URwNUS0UPCw1VBwkFUldBCnELBgJWBFABUEUBD3N5JzQuLHUVQUpJBFACCwRRV1YeQUlTQAdeEQgDGxJbQFJGVCIAWBYHcVBJQAV7XwFBVntbTVNVQwEhRgkWEFFXElElEwBARlxAXEoWWx0EJhQHVQAcAHEQQxBDQ1EhX1taBkNTJlJdRxcLehdWTFMHHRRZQUoXACVXF0dDUSFeX0NFFQgCDHJ6QwloLw9PZCQtA2oFdWVYNUA4AhQJGGJCGhkJJjVIQENBa09Tcl5jAAMAUwJ0VHcOZhBXKyYhe3BFVR4zUFNxUXhOcjxEeQEOIlANQ0kGelFkW3AJFVYHVn8SABAnVXh5eVIfCURIVxcFCUsPVFoXVHAPWENRIV9cElElDBYUAXZfTxxXdFVADEFWe0JVFwAlWgxcEgAVXFZVExVHCUJaUg94flZ0Z04kEzZpe153dzRVCVQMMQYEZGMnIgcIXwpnYEhmIntcT1NTFXJWUXpUUwUDbRUAWlBzdCo3JQFpe3pXcQFSAHFcDxBXYgJJdmIzVikYUiswVUdFKEsWLlBgXl5gClJacWdAVyAdAX0=&sid=ef6a12bd&title=To+The+Hellfire+-+Lorna+Shore+One+Take+Vocal+Playthrough.mp4"));
        }
    }
}
