using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Substitution_breaker;
using Substitution_breaker.Genetic_algorithm;
using BreakerLanguage = Substitution_breaker.Language;
using BreakerKey = Substitution_breaker.Key;

namespace Graphic
{
  
    public partial class MainWindow : Window
    {
        private Breaker _breaker;
        
        static string _rustext = "ЯРЯЩЮфЮйАИЯЮЕВЫБКЫЙЮЪШЭКЭЦИРЪЛЯЭЩББТЮНБЯАЖЙБФБИИЮГВДОЯЭЙЮФЫЬЮЕИБИРНЭКЭЮВЮЯЮЕЙЮЕЙИЮТЮИБШБФБИЯЮТШРЯЮИПАКЫЩЯРМАИБВБПРФЫИЮПОЮШЭКАЙЮБЕИБОИРЩЛБОБГВЮЕШЭШЮНЮТЮЕИБШРФЫИБЕВЮЩЙЮОНБОЫЯРЯАтнръошбоаиряэщоржцрзлборбОЯНДМЮЛИАЯАЛБЦЭОЯАНВАПАЦРЮТНРШЮЕЯОЮОДЬНРОЙЮЕАФАФЪЬЮЛИАЯГИБВЮЙИЪАВЮЙИАОЫИБИРШЮЯРЯЩЛБОФЮЦШБЩЫАЯРЯЬБЩВНАЪОИЮЮОШДЖРБОЭЩОРФЮБОБФЮРВНЮЖЮМАБШЭЙРЪОЩЙЭОИЮЛБНИЮОЮФЫЯЮЛПБНРЮЛШЮЛБФРРИИРРЖЙРОЮЛРГВЫЪЦРНРЦЮНБИИДЕШЮЙЦРЦФЭЪМАЦИЫЙЮЪЦРЮШАИЮПБЩОЛЮЛШЛЮБЙАЦРОБЬГГВЫЪЦРФЮМЫЙБИГВНБШРЛКАЖТЭЬЦРЙБНОЛДЕЖЮФЮШТФРЦЦРОЮПОЮЙАНМБЩОЮЯАТНЭЬЦРОЮПОЮЬЮТИБЩВРЩРИИРРЖЙРОЮЛРЯЮТШРГИЮПЫЪМШЭББВНАЖЮШРМАЦИЫЯРМБОЩГЛАЩАОИРЛЮФЮЩЯБПОЮВЮПБЩОАПОЮЪИЮЩОЫПОЮЩЛЮЬЮШРВНБШЙАФЮЕТЮЩОЫБЕЩШЭШЮПЯЮЕЛНЭЯБАЛЮОЛЮКФРЮОЯАИЭЛВЮЯНДЛРФЮЛИАЙРОБФЫИЮЛЦТФГИЭФРИРЙБИГБЕТЮЛЮНЪОДФЫШРИОЭШАЯОЮЛРФРЩОНРИАЗДРШРЮОЛБПРБОГРИИРРЖЙРОЮЛРЙЭЦР".ToLower();
        static string _text1 = "zphqaqpavqzmjmhmykzhmiqpsnpbhsimapprhmyzhmiqpsnpbhszlvqmyiuvppihszlvqmyiuvppimyizgkymyiupyqmhkyindmnzoqmgmyindqumlgkzznrpytjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqkomzuprypyqhprykytodqyndqzsyikiynzdkyqkaklgqisahjzdpeqvmyikomvgqinpndqhkyqkvpmiqizkfnqqynpypbyshuqrykyqlpmvmyindqznrpytupzzzmkioqvvuvqzzmhmzpsvjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqoqvvkbjpszqqhqmlphkyuqnnqrznqamzkiqmvpnpbhqyikiynmvpnpbhqyikqipyqbkznkzkrpyndqpndqrpbznqqvkbndqrktdnpyqipyntqnjpsndqyndqvqbnpyqokvvpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprq";
        static string _text = "pehjdziavahrazketakefakgayacaypzjpkefakgayjlvjprqyajllpsaalkgjkqilerqdptarksyqadzqujdktalqacakgqruehlztakgaadzqkleemrjrkgehfgpehjyalakkqdejdzqsqkryajlvallqzedkvjdkkemdevzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrehyiaieyqarkgapujdtaqdcqkqdfthkreiajyajlkefakgayiqfglpsyqfgkadqdfjrvazqatekgphehjdzqvqkggajzqdipgjdzrqrqkjdzuypzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrqkrjlladzqdfqfekkjrkennyakadzqdfvgevajyapehjdziaqujdraahrzpqdfjyavazedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrzedkkalliaujhraqkghykrqmdevvgjkpehjyarjpqdfrenlajrarkenaonljqdqdfzedkrnajmzedkrnajmzedkrnajmdeqmdevvgjkpehyakgqdmqdfjdzqzedkdaazpehyyajredrqmdevpehfeezqmdevpehfeezqmdevpehyajlfeezeg";

        public MainWindow()
        {
            InitializeComponent();
            _breaker = new Breaker(100, BreakerLanguage.English);            
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            CorrectionListView.Items.Clear();
            CipherTextRichTextBox.SelectAll();
            CipherTextRichTextBox.Selection.ApplyPropertyValue(TextElement.ForegroundProperty,Brushes.Black);
            var cipherText = GetCipherTextFromTextBox().Trim('\n');
            cipherText=cipherText.Trim('\r');
            var key = _breaker.FindKey(cipherText);
            PrintKey(key.Item1);
            PrintToTextBox(OpenTextRichTextBox,key.Item2);
            MessageBox.Show($"Приблизительный ключ найден!{Environment.NewLine}Результат функции: {key.Item1.Fitness}",
                "Результат выполнения");
            CipherTextRichTextBox.SelectAll();
            CipherTextRichTextBox.Selection.Text = CipherTextRichTextBox.Selection.Text.TrimEnd('\n').TrimEnd('\r');

        }

        private void PrintToTextBox(RichTextBox textBox,string text)
        {
            textBox.SelectAll();
            textBox.Selection.Text = "";
            textBox.AppendText(text);
        }

        private void PrintKey(BreakerKey key)
        {
            ClearMappingBox();
            foreach (var pair in key.Substitution.OrderBy(n=>n.Key))
            {
                AddItem(pair.Key, pair.Value);
            }
        }

        private void ClearMappingBox()
        {
            MapListView.Items.Clear();
        }

        private string GetOpenTextFromTextBox()
        {
            return GetTextFromRichTextBox(OpenTextRichTextBox);
        }

        private string GetCipherTextFromTextBox()
        {
            return GetTextFromRichTextBox(CipherTextRichTextBox);
        }

        private string GetTextFromRichTextBox(RichTextBox richTextBox)
        {
            richTextBox.SelectAll();
            var text = richTextBox.Selection.Text;
            return text;
        }

        private void AddItem(char first, char second)
        {
            var item=new ListViewItem();
            TuneListViewItem(item, first, second);
            MapListView.Items.Add(item);
        }

        private void TuneListViewItem(ListViewItem item,char first,char second)
        {
            item.HorizontalContentAlignment = HorizontalAlignment.Center;
            item.FontWeight = FontWeights.Bold;
            item.FontSize = 14;
            item.Content = $"{char.ToUpper(first)} → {char.ToUpper(second)}";
            item.KeyDown += MapListItemView_KeyDown;
        }

        private void MapListItemView_KeyDown(object sender, KeyEventArgs e)
        {
            var items = MapListView.Items;
            var letter = e.Key.ToString()[0];
            var nowItem = (ListViewItem) sender;
            if (nowItem.Background.Equals(Brushes.LimeGreen))
            {
                MessageBox.Show("Буква закреплена!", "Ошибка");
                return;
            }
            var content = ((string) nowItem.Content);
            var nowLetter = content[content.Length - 1];
            nowItem.Content = content.Replace(nowLetter, letter);

            foreach (var item in items)
            {
                if (item == sender) continue;
                var courced = item as ListViewItem;
                content = courced.Content as string;

                if (content[content.Length - 1] == letter)
                {
                    if (courced.Background.Equals(Brushes.LimeGreen))
                    {
                        MessageBox.Show("Вторая буква закреплена!", "Ошибка");
                        nowItem.Content = content.Replace(letter, nowLetter);
                        return;
                    }
                    courced.Content = content.Replace(letter, nowLetter);
                    break;
                }
            }

            OpenTextRichTextBox.SelectAll();
            var text = OpenTextRichTextBox.Selection.Text;
            var builder = new StringBuilder(text);
            letter = char.ToLower(letter);
            nowLetter = char.ToLower(nowLetter);
            for (int i = 0; i < builder.Length; i++)
            {
                if (builder[i] == letter)
                {
                    builder[i] = nowLetter;
                    continue;
                }
                if (builder[i] == nowLetter) builder[i] = letter;
            }
            OpenTextRichTextBox.SelectAll();
            OpenTextRichTextBox.Selection.Text = builder.ToString();

        }

        /// <summary>
        /// Я бы не смотрел сюда
        /// </summary>
        private char KeyboardEnglishCharToRussianMap(char englishChar)
        {
            switch (char.ToLower(englishChar))
            {
                case 'q':
                    return 'й';
                case '`':
                    return 'ё';
                case 'w':
                    return 'ц';
                case 'e':
                    return 'у';
                case 'r':
                    return 'к';
                case 't':
                    return 'е';
                case 'y':
                    return 'н';
                case 'u':
                    return 'г';
                case 'i':
                    return 'ш';
                case 'o':
                    return 'щ';
                case 'p':
                    return 'з';
                case '[':
                    return 'х';
                case ']':
                    return 'ъ';
                case 'a':
                    return 'ф';
                case 's':
                    return 'ы';
                case 'd':
                    return 'в';
                case 'f':
                    return 'а';
                case 'g':
                    return 'п';
                case 'h':
                    return 'р';
                case 'j':
                    return 'о';
                case 'k':
                    return 'л';
                case 'l':
                    return 'д';
                case ';':
                    return 'ж';
                case '\'':
                    return 'э';
                case 'z':
                    return 'я';
                case 'x':
                    return 'ч';
                case 'c':
                    return 'с';
                case 'v':
                    return 'м';
                case 'b':
                    return 'и';
                case 'n':
                    return 'т';
                case 'm':
                    return 'ь';
                case ',':
                    return 'б';
                case '.':
                    return 'ю';
                default:
                    return ' ';
            }
        }

        private void TuneCorrectionListViewItem(ListViewItem item)
        {
            item.HorizontalContentAlignment = HorizontalAlignment.Center;
            item.FontSize = 14;
        }

        private void CorrectionExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            var word = OpenTextRichTextBox.Selection.Text;
            AddItemToCorrectListView(word);
            foreach (var letter in word)
            {
                ColorMappingItem(letter);
            }
        }

        private void ColorMappingItem(char correctLetter)
        {
            var items = MapListView.Items;
            
            foreach (var item in items)
            {
                var courced = item as ListViewItem;
                if ((courced.Content as string).Last() == char.ToUpper(correctLetter))
                {

                    courced.Background = Brushes.LimeGreen;
                    break;
                }
            }
        }

        private void AddItemToCorrectListView(string word)
        {
            var item=new ListViewItem();
            TuneCorrectionListViewItem(item);
            item.Content = word;
            CorrectionListView.Items.Add(item);
        }

        private void OpenTextRichTextBox_MouseUp(object sender, RoutedEventArgs e)
        {
            var rtb1 = CipherTextRichTextBox;
            var rtb = OpenTextRichTextBox;
            if (rtb.Selection.IsEmpty) return;

            var startOffset = rtb.Selection.Start.GetOffsetToPosition(rtb.Document.ContentStart);
            var endOffset = rtb.Selection.End.GetOffsetToPosition(rtb.Document.ContentStart);

            var text=new TextRange(rtb.Document.ContentStart, rtb.Selection.Start).Text;
            var spacesCount = text.Count(n => n == ' ');
            var selectedText = new TextRange(rtb.Selection.Start, rtb.Selection.End).Text;
            int i = 0;
            var innerSpacec = selectedText.Trim().Count(n => n == ' ');
            endOffset += innerSpacec;
            while (selectedText[i]==' ')
            {
                endOffset++;
                i++;
            }
            i = selectedText.Length-1;
            while (selectedText[i]==' ')
            {
                endOffset++;
                i--;
            }
            startOffset+= spacesCount;
            endOffset += spacesCount;
            var start = rtb1.Document.ContentStart.GetPositionAtOffset(-startOffset);
            var end = rtb1.Document.ContentStart.GetPositionAtOffset(-endOffset);
            var range = new TextRange(start, end);

          //  var positionStart = rtb.Selection.Start;
          //  var textBefore = new TextRange(rtb.Document.ContentStart, positionStart).Text;
           // var spaces = textBefore.Trim().Count(n => n == ' ');
         //   positionStart = rtb.Selection.Start.GetPositionAtOffset(-spaces);
           // var positionEnd = rtb.Selection.End.GetPositionAtOffset(-spaces);


           // rtb1.Selection.Select(positionStart, positionEnd);
           // var allText = new TextRange(rtb1.Selection.Start, rtb1.Selection.End);
            range.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);          
        }

        private void OpenTextRichTextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rtb = sender as RichTextBox;
            if (rtb.Selection.IsEmpty) return;
            var rtb1 = CipherTextRichTextBox;
            rtb1.SelectAll();
            rtb1.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
            rtb1.Selection.Select(rtb1.Document.ContentStart, rtb1.Document.ContentStart);
        }
    }

   
}
