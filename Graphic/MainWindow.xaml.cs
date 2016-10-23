using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        private BreakerLanguage _language;
        private int _attempts;
        public int Attempts { get { return _attempts; } set { _attempts = value; _breaker=new Breaker(_attempts,_language); } }

        //private static string sample36 =
        //    "ШЙФЩЪСЮУПЫФПХЗЭЧЙФЙХЙЗГЯЕВЕФНЙЪСЕУШДЗЭДФСЬЧЙУСШЙФФПДЙНДЧЕВЙФРПВЙФЙБРПЕЪЕЙФЩЪЕЫЙФДФДГЧСЫKГСЩСШСЧЕЭKСМНБСЗЭСДШЗВСНСЩЧЙФЕЫЕШЙЮЗKЫЙЦДШЗДЩСБДВЪЙЧЙРЕДАЗШСЕХЯФЕШДЧЗЕЭДЭЗВЕХГСУФЙФЕАСГЧДЗЭЯГЪДФЕЕЕФЙВЙУЙФЕЕВЙОБПАЕУФЕХЬДУЯЗЪСШФСУФЙДЭЫЭСЪФЭСЪЗЭСАЙШЭСЧЧСНЙФЙШСАФЙЕНЕЧНФСЩЕДЪЕДЩСЫЕЭЙЪЕБЧЯЩСАШСГЧСЗВСДВЭСФЙЗЪПЁЙФСЬЙГЫДХСШДДЗЪЕШЙНГСШДУДЭЗЗСЬДЗДБФЕВСНЭСШПЗНСОДЭДГДЧДНСЪШЕЭKЗЮСШБФЙЬСВСШДЕЙЬЯФЕФДГСЩСШСЧЕЭKСФПФДЁФЕХГЕЗЙЭДЪЮХИНЕЩЧЙФЭЙХЫЭСВЙЗЙДЭЗЮГЯЁВЕФЙЭСГСУФЙФЕЮВЙВГЧЙШЕЪСЗВЯБФПЭДНЯБЕШЕЭДЪKФДДЫЭСЯОДЗГДЧШПХНЕФЯЭНСДЩСГЧЕДУБЙШВЙФЙБЯДЦДШЙИЧСГСЧЭЯНСФЧДЙЪЮЮЯЗЪПЁЙЪЗЭЧСМПДШЩДФЕЮСФДЩЕФЙЕУЯЗЭЗСШЗДНФДЧСЗЗЕАЗВСЩСЕЪЕЗСШДЭЗВСЩСИНЕЩЧЙФЭЙЕБЙОДЫДЪСШДВЙФДЕНДШЁДЩСЭСЩБЙШБДШЮФСЗЭСНЩСБЯФЕВЙВЕХЗШЮУДАЗЭЙВЕНЕИНЕЩЧЙФЭЙНЕЙГЧСМДЗЗСЧЙНЙЭДНЙЭЕВЕЯФЕШДЧЗЕЭДЭЙНЙВЩЕЪЪШПХСБРЙЕУЖОФСАЙМЧЕВЕГСЪЯЫЕШЁДЩССЬЧЙУСШЙФЕДШВДНЬЧЕБОДБЕСФЙЩЕЪKБДФХДАУЙЧЙЗЗВЙОЯСЬСШЗДНГСГСЧЮБВЯЮГСЪЯЫЕЪГЧЕЩЪЙЁДФЕДГЧСМДЗЗСЧЗВСАЫДЭПФЙЧЙАФЙЕВЙФЭПЩЯГЭЙГЧЕДХЙЭKФЙБШЙНДЗЮРЙШШЕФФЕГДЩЕЗСШНДЗЭФСГСЧЙЬСЭЙЭKФЙБЧЮБСНФЙЯЫФПХ"
        //        .ToLower().Replace('k', 'к');

        //private static string sample371 = "ПЩИМИЙЛЬМЪГПРЧГГЪЖМГХЪЧДЛИКЩПЛПАБКОЬКЛШГУИЖИГГЪЖБРЫЗИЙЛЯЛЕТЙСЩЪДОДСЕЖЦЫКЕТРПЭМЙПАЪЪСЭЫАЦМОЫРЛДЦЫАИЖЖЫЫРЧЛЯЛУНЛЖЯЖЬЯЫКЦТЙЖОЯГЫДВЪЖЯСАЪЧРИЛРЕРХЛЙШТЦЩЙЫНСИИДФЦПЩЪАДЪИПЛШЛХКЛШЦЕЖЫКЛХЪОУПРСОДОРТЮУФИДРЦЯЖИТАКЦСЩСРЛЧИШЛЦЪАДЬХЧГБЪЪФЖВКЦТМАЛМСАВЮХЖАКЛЙГОЬГРТЮРНЩДЛШЦМСАГПФСОГНЙСНДГРТОГЗИУЦИНШЧФБЗЙЖЫКВЖБАВЪПУЛЭАЧЦЛМЛЙГОСГУМТАТФЭРУЪЖЕПУПРСЪАЭЯЛГУЛЩЪВХНГЖЪХЛМШИЫЖРЫЬВЖНХТУПМЙЛКЛУМЛЦБИИЮВВНЙОВЕЦТЙШНЬГРГКИФЬЫЫЙЖЙШНМЦЮЫЫИЧТЭОРЕАВЪЖХЫЧАЧЕЯСЯЛФЪЫБЗСВСАЧМИДЬИЙИФЭЩЧРКЪИПГБККДЯЧКЩООЫИНКЛШЪЛБГЭЪЛБГЩЖЛЧЛГОВЙРВЩШСОУТЩЙЛГПШЪЪЫНДЕГВБВЪОЯНЙМЮЧРЖХРЖПРЖААЪЛБГОПСЪЙАНМТОСЬЕТЖДЫИЕОЧАХТЮСЖЛЖНСДПЖГУЪЖИЮДЪЛИЕССЕЛЮДЮЖШГЫРЛМРИОТМНСРЛИРУЮЖШТФПМЖАКАЛДЕЬЫЦЖМСАНПГБДЛКЕЬЫЦТЩЮБГЖЬВЗЙСЫХЛЙСПППЬОЬСАЛЕТУЛРЕТЖОРДГЫГГЖАГПЕЧГНБИУИОПТДГДЫКПГЯЛЧЦАСБЛИТФБЛЩЪДКЙЛМВЪИПЛШОЬТНВКУТЩОБЖЧОЬГЦШРМКЦЪЗДЯЖИРЭЩИДРППМЕЙСГЦШРУПЦЛНИЛЯЖОДПЕМНВВЖШЕЫЬЧУВСГРЕАВШИЧГУЖЖФОВЖЖФОЩАЧЗЮВЫМСВЩАЧЗЮВЫМСВУПДЕРПЪЖИРХНМЧФКЛЦЦПХЦУУТЯБЛПОСЫМЙТКНРТНИТЙСБХЛТЧПЭПВЪВЭНФХГЖИЧХГЖИЧМНВВЖШГУКЩЙГЯПЕЖЪГЫЧЙЛОПСЪНИПМЖЦСРЖМРЖЦЕЖЛХЛТЧФШОЙООЫЖРИТПЛЙИГШЪНШЫЮЕЩЪМВЪЛХЖЫАЖЦГАШИШНСЬЪХЪНБЭЪОСЫЛИРУЭЙЭТИЯЧФТХЫИФЕВЪЙЖОДЬЪХЙПРЙЫЕСЫВСУУПТЦЪДФЪСЪДСЛМРУОИЙЛШЪЧРФСДКЕИШЯЙТОДАЕЪЧХЛСЪО";

        //private static string sample372 =
        //    "ЕАСЗУВНУВРДУАЙЪБВФЪЙХТВАЙЪБВФЪЙЪКВЙПЪАХБЕУДАСЗТДЗХРУСТМЙЪФЪЙХЭУХЦХДРЩХМХУЕЩПУДТХБЕХМПЕУДУАСЗЯЩХЭИЗВЮЩПЖЕТХЗХФАСЗЩХБФВЪБЗГМЮЦЙЪМДЗЪЮХЮУСЮЗХИУХЮУВЮЩЪЮЩГРВЗЪЦЪЙЦЪИТДЙНЗСЭБЙГУЩЙДАЕЩВИЦВЗСИВЗЪЙПЕУХБЙГНЪЗЪЩВРЦЪРДЙДНЦЙВЭВЕЧХФЪЗУВФЦХЩЗХИВУХТМХЦЙЪЦЪИВЗФВИВЭФВИВЭЪТХЛДЩЮЩВЗАСЕТДЙНВИКДТЦХБФВАХФЪУЪНЩДЧЙДАЕЩЦХТУДМХЩЙВМГУДМХФУЕЗЮЕБХЗГАХБЗВНЪГБЗХИВЩУДФДЫДИЪЮЦВНВЗХУИУЕЩУХИТХЪБЗВНВЮТХЩЙЕИГМХЙЪМХФМХЗХЭДБХАГЫЗВЩВАЗДЮУГЗХЩЩХРДУУСЭЩХМХЙУДХЩГБЙХНСХЙХАДЗЕЩВТЛЪНУПИЮДБФВУВИХЗХЮЦДИЦХУКДЦХУКХИФХЫЗХАФХФДЗВНВАГЙУЪЦАСЗИТХДЭЙГЦДУХЮЩВЗХЮЩЙВЫУХХЩЩХБХТУДРЩХЯЩХАСЗЩХИВЙЪШТХЭЕЪЮДБХФУЕЕЮУХМХТУЖЮГЙХИСЭИНБЗЕФДБХМЙЕТХЭФЙГНПЕТХЪИЗЪЧЪДЮЙХЦЪИСАСЗЪЮЪЗПУСТЪЗЖФПТЪЮМВЮЪАХИВТНВЩДГЙХЦЪГЙХЦЪБУДИВЪЗЖАИЪВУВЩХЗЪЭЛЪБГЗЪУ";
        //private static string sample373 = "ДЮМНЗРЛЮЬДСЬЗЕЮТЪШАЬЛРЗПЗВЮНМЮЬЛСАПСЕСЖДШЩЭНЗЙШНТЩЬТВЮРКАРШБЗПЛШАЬЛРЗЮЛВТЬЬДЮАЖСВДРШЮЛЙСЛЗЙДЮМНЗЧВШПСРЬДЗИЬЛЮЙШЖЗБЗЪКРРСЙШХШСЬРЮСДЗДЮЧУИПСРОЗИЪЙТНПШЖЗПСБПЗЙЗДЛЮЪСВСЛССЕПСМЮЙЮЬЪКЙЮПБРЗЙТЛСОПЮЮПМЮРЮВШЙШНШЬЯНЗЮЬЛЗРУЬРЮАДВЗАМЙТЩЮАШМВСОПКАЮЬЛЗРУВЮЬЬШЯПЗРЬСМНЗИДВЮРУЮЛВТДЛРЮШЩЮЛЕЮЯШБЬСВНЖЗРКПТХСВПКАЬЛКНИПЮРКЕШЕСПСЕЧЮДВЮЯЪЮЙУЧЮВЗЭСПШАШЮЪШНПЮВЗРПЮНТОПЮШЬЧЮДЮАПЮВТДЗЕШИБЗЕДПТЙЗЬЙТЩХЛЮЪЫЛЮАВСХУЯПСНЮЬЛЮАПЮАПСЮЬДРСВПШЙЬИЬДЮВЪПКАНТЩЗППЗЗЩЕЗЛЮРЗХСВПССЛНЮВЮМЗЧВШЕЮВЬДЮМЮЬЗНЗЭСЙЛКШЬРСЭШГЮПЗВШИЮХСПУЬЧЮДЮАПЗИЛЮЙУДЮПСПЗНЮЬЮЕПЮЯЮПСЕМЮРЮВШЛУЛКЕШЙКАШРСВПКАЕКЪТНСЕНВТБУИЕШМТЙИЛУЖСЙЮРЗЛУЬИЬЛЗВСЛУШЙСМДШСЕСЬИЖКЪТНТЛПЗНПЗЕШДЗДЬПСЭПКСБРСБНКЙСЛСЛУЗППЗЗЩЕЗЛЮРЗЮНПЗШБЧСЬСПДЮЛЮВКСШЬЧЮЙПИЙРСВЛШПЬДША";
        //private static string sample374 = "ЯРЯЩЮФЮЙАИЯЮЕВЫБКЫЙЮЪШЭКЭЦИРЪЛЯЭЩББТЮНБЯАЖЙБФБИИЮГВДОЯЭЙЮФЫЬЮЕИБИРНЭКЭЮВЮЯЮЕЙЮЕЙИЮТЮИБШБФБИЯЮТШРЯЮИПАКЫЩЯРМАИБВБПРФЫИЮПОЮШЭКАЙЮБЕИБОИРЩЛБОБГВЮЕШЭШЮНЮТЮЕИБШРФЫИБЕВЮЩЙЮОНБОЫЯРЯАТНРЪОШБОАИРЯЭЩОРЖЦРЗЛБОРБОЯНДМЮЛИАЯАЛБЦЭОЯАНВАПАЦРЮТНРШЮЕЯОЮОДЬНРОЙЮЕАФАФЪЬЮЛИАЯГИБВЮЙИЪАВЮЙИАОЫИБИРШЮЯРЯЩЛБОФЮЦШБЩЫАЯРЯЬБЩВНАЪОИЮЮОШДЖРБОЭЩОРФЮБОБФЮРВНЮЖЮМАБШЭЙРЪОЩЙЭОИЮЛБНИЮОЮФЫЯЮЛПБНРЮЛШЮЛБФРРИИРРЖЙРОЮЛРГВЫЪЦРНРЦЮНБИИДЕШЮЙЦРЦФЭЪМАЦИЫЙЮЪЦРЮШАИЮПБЩОЛЮЛШЛЮБЙАЦРОБЬГГВЫЪЦРФЮМЫЙБИГВНБШРЛКАЖТЭЬЦРЙБНОЛДЕЖЮФЮШТФРЦЦРОЮПОЮЙАНМБЩОЮЯАТНЭЬЦРОЮПОЮЬЮТИБЩВРЩРИИРРЖЙРОЮЛРЯЮТШРГИЮПЫЪМШЭББВНАЖЮШРМАЦИЫЯРМБОЩГЛАЩАОИРЛЮФЮЩЯБПОЮВЮПБЩОАПОЮЪИЮЩОЫПОЮЩЛЮЬЮШРВНБШЙАФЮЕТЮЩОЫБЕЩШЭШЮПЯЮЕЛНЭЯБАЛЮОЛЮКФРЮОЯАИЭЛВЮЯНДЛРФЮЛИАЙРОБФЫИЮЛЦТФГИЭФРИРЙБИГБЕТЮЛЮНЪОДФЫШРИОЭШАЯОЮЛРФРЩОНРИАЗДРШРЮОЛБПРБОГРИИРРЖЙРОЮЛРЙЭЦР";
        //private static string sample381 = @"pehjdziavahrazketakefakgayacaypzjpkefakgayjlvjprqyajllpsaalkgjkqilerqdptarksyqadzqujdktalqacakgqruehlztakgaadzqkleemrjrkgehfgpehjyalakkqdejdzqsqkryajlvallqzedkvjdkkemdevzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrehyiaieyqarkgapujdtaqdcqkqdfthkreiajyajlkefakgayiqfglpsyqfgkadqdfjrvazqatekgphehjdzqvqkggajzqdipgjdzrqrqkjdzuypzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrqkrjlladzqdfqfekkjrkennyakadzqdfvgevajyapehjdziaqujdraahrzpqdfjyavazedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrzedkkalliaujhraqkghykrqmdevvgjkpehjyarjpqdfrenlajrarkenaonljqdqdfzedkrnajmzedkrnajmzedkrnajmdeqmdevvgjkpehyakgqdmqdfjdzqzedkdaazpehyyajredrqmdevpehfeezqmdevpehfeezqmdevpehyajlfeezeg";

        //private static string sample382 =
        //    "zphqaqpavqzmjmhmykzhmiqpsnpbhsimapprhmyzhmiqpsnpbhszlvqmyiuvppihszlvqmyiuvppimyizgkymyiupyqmhkyindmnzoqmgmyindqumlgkzznrpytjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqkomzuprypyqhprykytodqyndqzsyikiynzdkyqkaklgqisahjzdpeqvmyikomvgqinpndqhkyqkvpmiqizkfnqqynpypbyshuqrykyqlpmvmyindqznrpytupzzzmkioqvvuvqzzmhmzpsvjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqoqvvkbjpszqqhqmlphkyuqnnqrznqamzkiqmvpnpbhqyikiynmvpnpbhqyikqipyqbkznkzkrpyndqpndqrpbznqqvkbndqrktdnpyqipyntqnjpsndqyndqvqbnpyqokvvpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprq";


        //static string _rustext = "ЯРЯЩЮфЮйАИЯЮЕВЫБКЫЙЮЪШЭКЭЦИРЪЛЯЭЩББТЮНБЯАЖЙБФБИИЮГВДОЯЭЙЮФЫЬЮЕИБИРНЭКЭЮВЮЯЮЕЙЮЕЙИЮТЮИБШБФБИЯЮТШРЯЮИПАКЫЩЯРМАИБВБПРФЫИЮПОЮШЭКАЙЮБЕИБОИРЩЛБОБГВЮЕШЭШЮНЮТЮЕИБШРФЫИБЕВЮЩЙЮОНБОЫЯРЯАтнръошбоаиряэщоржцрзлборбОЯНДМЮЛИАЯАЛБЦЭОЯАНВАПАЦРЮТНРШЮЕЯОЮОДЬНРОЙЮЕАФАФЪЬЮЛИАЯГИБВЮЙИЪАВЮЙИАОЫИБИРШЮЯРЯЩЛБОФЮЦШБЩЫАЯРЯЬБЩВНАЪОИЮЮОШДЖРБОЭЩОРФЮБОБФЮРВНЮЖЮМАБШЭЙРЪОЩЙЭОИЮЛБНИЮОЮФЫЯЮЛПБНРЮЛШЮЛБФРРИИРРЖЙРОЮЛРГВЫЪЦРНРЦЮНБИИДЕШЮЙЦРЦФЭЪМАЦИЫЙЮЪЦРЮШАИЮПБЩОЛЮЛШЛЮБЙАЦРОБЬГГВЫЪЦРФЮМЫЙБИГВНБШРЛКАЖТЭЬЦРЙБНОЛДЕЖЮФЮШТФРЦЦРОЮПОЮЙАНМБЩОЮЯАТНЭЬЦРОЮПОЮЬЮТИБЩВРЩРИИРРЖЙРОЮЛРЯЮТШРГИЮПЫЪМШЭББВНАЖЮШРМАЦИЫЯРМБОЩГЛАЩАОИРЛЮФЮЩЯБПОЮВЮПБЩОАПОЮЪИЮЩОЫПОЮЩЛЮЬЮШРВНБШЙАФЮЕТЮЩОЫБЕЩШЭШЮПЯЮЕЛНЭЯБАЛЮОЛЮКФРЮОЯАИЭЛВЮЯНДЛРФЮЛИАЙРОБФЫИЮЛЦТФГИЭФРИРЙБИГБЕТЮЛЮНЪОДФЫШРИОЭШАЯОЮЛРФРЩОНРИАЗДРШРЮОЛБПРБОГРИИРРЖЙРОЮЛРЙЭЦР".ToLower();
        //static string _text1 = "zphqaqpavqzmjmhmykzhmiqpsnpbhsimapprhmyzhmiqpsnpbhszlvqmyiuvppihszlvqmyiuvppimyizgkymyiupyqmhkyindmnzoqmgmyindqumlgkzznrpytjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqkomzuprypyqhprykytodqyndqzsyikiynzdkyqkaklgqisahjzdpeqvmyikomvgqinpndqhkyqkvpmiqizkfnqqynpypbyshuqrykyqlpmvmyindqznrpytupzzzmkioqvvuvqzzmhmzpsvjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqoqvvkbjpszqqhqmlphkyuqnnqrznqamzkiqmvpnpbhqyikiynmvpnpbhqyikqipyqbkznkzkrpyndqpndqrpbznqqvkbndqrktdnpyqipyntqnjpsndqyndqvqbnpyqokvvpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprq";
        //static string _text = "pehjdziavahrazketakefakgayacaypzjpkefakgayjlvjprqyajllpsaalkgjkqilerqdptarksyqadzqujdktalqacakgqruehlztakgaadzqkleemrjrkgehfgpehjyalakkqdejdzqsqkryajlvallqzedkvjdkkemdevzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrehyiaieyqarkgapujdtaqdcqkqdfthkreiajyajlkefakgayiqfglpsyqfgkadqdfjrvazqatekgphehjdzqvqkggajzqdipgjdzrqrqkjdzuypzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrqkrjlladzqdfqfekkjrkennyakadzqdfvgevajyapehjdziaqujdraahrzpqdfjyavazedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrzedkkalliaujhraqkghykrqmdevvgjkpehjyarjpqdfrenlajrarkenaonljqdqdfzedkrnajmzedkrnajmzedkrnajmdeqmdevvgjkpehyakgqdmqdfjdzqzedkdaazpehyyajredrqmdevpehfeezqmdevpehfeezqmdevpehyajlfeezeg";

        public MainWindow()
        {
            InitializeComponent();
            _language = BreakerLanguage.English;
            _attempts = 200;
            _breaker = new Breaker(Attempts, _language);
            this.Closing += MainWindow_Closing;          
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private async void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            CorrectionListView.Items.Clear();
            CipherTextRichTextBox.SelectAll();
            CipherTextRichTextBox.Selection.ApplyPropertyValue(TextElement.ForegroundProperty,Brushes.Black);
            var cipherText = GetCipherTextFromTextBox().ToLower().Trim('\n');
            var lang = DefineLanguage(cipherText);
            _language = lang;
            _breaker = new Breaker(Attempts, lang);
            cipherText=cipherText.Trim('\r');
            var progressBar=new ProgressBarWindow(_attempts);
            _breaker.StateChanged += progressBar.ProgressChanged;
            progressBar.Show();
            var key =await _breaker.FindKeyAsync(cipherText);
            progressBar.Hide();
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
            var menuItem=new MenuItem();
            menuItem.Header = "HighLight";
            menuItem.Click += MapListItemView_MouseDown;
            item.ContextMenu=new ContextMenu();
            item.ContextMenu.Items.Add(menuItem);


        }

        private void MapListItemView_MouseDown(object sender, RoutedEventArgs e)
        {
            var rtb1 = CipherTextRichTextBox;
            rtb1.SelectAll();
            rtb1.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
            rtb1.Selection.Select(rtb1.Document.ContentStart, rtb1.Document.ContentStart);
            var items = MapListView.Items;
            var nowItem = ((sender as MenuItem).Parent as ContextMenu).PlacementTarget as ListViewItem;
            var content = ((string)nowItem.Content);
            var nowLetter = char.ToLower(content[0]);
            CipherTextRichTextBox.SelectAll();

            var rtb = CipherTextRichTextBox;
            var text = CipherTextRichTextBox.Selection.Text;
            var start = rtb.Document.ContentStart.GetNextContextPosition(LogicalDirection.Forward);
            var end = rtb.Document.ContentEnd;

            var ronge = new TextRange(start, end);
            for (int i = 0; i < text.Length; i++)
            {
                ronge = new TextRange(start, end);
                if (text[i] == nowLetter)
                {
                    
                    var range = new TextRange(start, start.GetPositionAtOffset((i==0)?2:1));
                  
                    range.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
                }
                start = ronge.Start.GetPositionAtOffset(1);
            }        
        }

        private void MapListItemView_KeyDown(object sender, KeyEventArgs e)
        {
            var items = MapListView.Items;
            var letter = e.Key.ToString()[0];
            
            if (_language == BreakerLanguage.Russian)
            {
                if (e.Key.ToString()=="Oem3")
                    letter = '`';
                if (e.Key.ToString() == "OemOpenBrackets")
                    letter = '[';
                if (e.Key.ToString() == "Oem6")
                    letter = ']';
                if (e.Key.ToString() == "Oem1")
                    letter = ';';
                if (e.Key.ToString() == "OemQuotes")
                    letter = '\'';
                if (e.Key.ToString() == "OemComma")
                    letter = ',';
                if (e.Key.ToString() == "OemPeriod")
                    letter = '.';
                letter = Char.ToUpper(KeyboardEnglishCharToRussianMap(letter));
            }
            var nowItem = (ListViewItem) sender;
            if (nowItem.Background.Equals(Brushes.LimeGreen))
            {
                MessageBox.Show("Буква закреплена!", "Ошибка");
                return;
            }
            var content = ((string) nowItem.Content);
            var nowLetter = content[content.Length - 1];
            nowItem.Content = content.Substring(0, content.Length - 1) + letter;

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
                    courced.Content = content.Substring(0, content.Length - 1) + nowLetter;
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

        private BreakerLanguage DefineLanguage(string text)
        {
            var letter = text[0];
            if (letter >= 'a' && letter <= 'z') return BreakerLanguage.English;
            return BreakerLanguage.Russian;
        }

        private void TuneCorrectionListViewItem(ListViewItem item)
        {
            item.HorizontalContentAlignment = HorizontalAlignment.Center;
            item.FontSize = 14;
        }

        private void CorrectionExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            var word = OpenTextRichTextBox.Selection.Text;
            if (word.Length == 0 || Regex.IsMatch(word, "^ *$")) return;
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

        private void OpenTextRichTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var top = 21;
            var secondtop = 154;
            if ((int) Canvas.GetTop(OpenTextRichTextBox) <= top + 1)
            {
                Canvas.SetTop(OpenTextRichTextBox, secondtop);
                OpenTextRichTextBox.Height -= 25;
                OpenTextRichTextBox.Height /= 2;
                CipherTextRichTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                Canvas.SetTop(OpenTextRichTextBox, top);

                OpenTextRichTextBox.Height *= 2;
                OpenTextRichTextBox.Height += 25;
                CipherTextRichTextBox.Visibility = Visibility.Hidden;
            }
        }

        private void FontSizeUp_OnClick(object sender, RoutedEventArgs e)
        {
            OpenTextRichTextBox.SelectAll();
            var fontsize=(double)OpenTextRichTextBox.Selection.GetPropertyValue(TextElement.FontSizeProperty) + 2;
            OpenTextRichTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty,fontsize);
        }

        private void FontSizeDown_OnClick(object sender, RoutedEventArgs e)
        {
            OpenTextRichTextBox.SelectAll();
            var fontsize = (double)OpenTextRichTextBox.Selection.GetPropertyValue(TextElement.FontSizeProperty) - 2;
            OpenTextRichTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, fontsize);
        }

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new SettingsWindow(this);
            window.Show();

        }

        private void BlackTextMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var rtb1 = CipherTextRichTextBox;
            rtb1.SelectAll();
            rtb1.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
            rtb1.Selection.Select(rtb1.Document.ContentStart, rtb1.Document.ContentStart);
        }
    }

   
}
