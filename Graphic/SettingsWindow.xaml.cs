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
using System.Windows.Shapes;

namespace Graphic
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private MainWindow _window;
        private static string sample36 =
    "ШЙФЩЪСЮУПЫФПХЗЭЧЙФЙХЙЗГЯЕВЕФНЙЪСЕУШДЗЭДФСЬЧЙУСШЙФФПДЙНДЧЕВЙФРПВЙФЙБРПЕЪЕЙФЩЪЕЫЙФДФДГЧСЫKГСЩСШСЧЕЭKСМНБСЗЭСДШЗВСНСЩЧЙФЕЫЕШЙЮЗKЫЙЦДШЗДЩСБДВЪЙЧЙРЕДАЗШСЕХЯФЕШДЧЗЕЭДЭЗВЕХГСУФЙФЕАСГЧДЗЭЯГЪДФЕЕЕФЙВЙУЙФЕЕВЙОБПАЕУФЕХЬДУЯЗЪСШФСУФЙДЭЫЭСЪФЭСЪЗЭСАЙШЭСЧЧСНЙФЙШСАФЙЕНЕЧНФСЩЕДЪЕДЩСЫЕЭЙЪЕБЧЯЩСАШСГЧСЗВСДВЭСФЙЗЪПЁЙФСЬЙГЫДХСШДДЗЪЕШЙНГСШДУДЭЗЗСЬДЗДБФЕВСНЭСШПЗНСОДЭДГДЧДНСЪШЕЭKЗЮСШБФЙЬСВСШДЕЙЬЯФЕФДГСЩСШСЧЕЭKСФПФДЁФЕХГЕЗЙЭДЪЮХИНЕЩЧЙФЭЙХЫЭСВЙЗЙДЭЗЮГЯЁВЕФЙЭСГСУФЙФЕЮВЙВГЧЙШЕЪСЗВЯБФПЭДНЯБЕШЕЭДЪKФДДЫЭСЯОДЗГДЧШПХНЕФЯЭНСДЩСГЧЕДУБЙШВЙФЙБЯДЦДШЙИЧСГСЧЭЯНСФЧДЙЪЮЮЯЗЪПЁЙЪЗЭЧСМПДШЩДФЕЮСФДЩЕФЙЕУЯЗЭЗСШЗДНФДЧСЗЗЕАЗВСЩСЕЪЕЗСШДЭЗВСЩСИНЕЩЧЙФЭЙЕБЙОДЫДЪСШДВЙФДЕНДШЁДЩСЭСЩБЙШБДШЮФСЗЭСНЩСБЯФЕВЙВЕХЗШЮУДАЗЭЙВЕНЕИНЕЩЧЙФЭЙНЕЙГЧСМДЗЗСЧЙНЙЭДНЙЭЕВЕЯФЕШДЧЗЕЭДЭЙНЙВЩЕЪЪШПХСБРЙЕУЖОФСАЙМЧЕВЕГСЪЯЫЕШЁДЩССЬЧЙУСШЙФЕДШВДНЬЧЕБОДБЕСФЙЩЕЪKБДФХДАУЙЧЙЗЗВЙОЯСЬСШЗДНГСГСЧЮБВЯЮГСЪЯЫЕЪГЧЕЩЪЙЁДФЕДГЧСМДЗЗСЧЗВСАЫДЭПФЙЧЙАФЙЕВЙФЭПЩЯГЭЙГЧЕДХЙЭKФЙБШЙНДЗЮРЙШШЕФФЕГДЩЕЗСШНДЗЭФСГСЧЙЬСЭЙЭKФЙБЧЮБСНФЙЯЫФПХ".ToLower()
        .Replace('k', 'к');

        private static string sample371 = "ПЩИМИЙЛЬМЪГПРЧГГЪЖМГХЪЧДЛИКЩПЛПАБКОЬКЛШГУИЖИГГЪЖБРЫЗИЙЛЯЛЕТЙСЩЪДОДСЕЖЦЫКЕТРПЭМЙПАЪЪСЭЫАЦМОЫРЛДЦЫАИЖЖЫЫРЧЛЯЛУНЛЖЯЖЬЯЫКЦТЙЖОЯГЫДВЪЖЯСАЪЧРИЛРЕРХЛЙШТЦЩЙЫНСИИДФЦПЩЪАДЪИПЛШЛХКЛШЦЕЖЫКЛХЪОУПРСОДОРТЮУФИДРЦЯЖИТАКЦСЩСРЛЧИШЛЦЪАДЬХЧГБЪЪФЖВКЦТМАЛМСАВЮХЖАКЛЙГОЬГРТЮРНЩДЛШЦМСАГПФСОГНЙСНДГРТОГЗИУЦИНШЧФБЗЙЖЫКВЖБАВЪПУЛЭАЧЦЛМЛЙГОСГУМТАТФЭРУЪЖЕПУПРСЪАЭЯЛГУЛЩЪВХНГЖЪХЛМШИЫЖРЫЬВЖНХТУПМЙЛКЛУМЛЦБИИЮВВНЙОВЕЦТЙШНЬГРГКИФЬЫЫЙЖЙШНМЦЮЫЫИЧТЭОРЕАВЪЖХЫЧАЧЕЯСЯЛФЪЫБЗСВСАЧМИДЬИЙИФЭЩЧРКЪИПГБККДЯЧКЩООЫИНКЛШЪЛБГЭЪЛБГЩЖЛЧЛГОВЙРВЩШСОУТЩЙЛГПШЪЪЫНДЕГВБВЪОЯНЙМЮЧРЖХРЖПРЖААЪЛБГОПСЪЙАНМТОСЬЕТЖДЫИЕОЧАХТЮСЖЛЖНСДПЖГУЪЖИЮДЪЛИЕССЕЛЮДЮЖШГЫРЛМРИОТМНСРЛИРУЮЖШТФПМЖАКАЛДЕЬЫЦЖМСАНПГБДЛКЕЬЫЦТЩЮБГЖЬВЗЙСЫХЛЙСПППЬОЬСАЛЕТУЛРЕТЖОРДГЫГГЖАГПЕЧГНБИУИОПТДГДЫКПГЯЛЧЦАСБЛИТФБЛЩЪДКЙЛМВЪИПЛШОЬТНВКУТЩОБЖЧОЬГЦШРМКЦЪЗДЯЖИРЭЩИДРППМЕЙСГЦШРУПЦЛНИЛЯЖОДПЕМНВВЖШЕЫЬЧУВСГРЕАВШИЧГУЖЖФОВЖЖФОЩАЧЗЮВЫМСВЩАЧЗЮВЫМСВУПДЕРПЪЖИРХНМЧФКЛЦЦПХЦУУТЯБЛПОСЫМЙТКНРТНИТЙСБХЛТЧПЭПВЪВЭНФХГЖИЧХГЖИЧМНВВЖШГУКЩЙГЯПЕЖЪГЫЧЙЛОПСЪНИПМЖЦСРЖМРЖЦЕЖЛХЛТЧФШОЙООЫЖРИТПЛЙИГШЪНШЫЮЕЩЪМВЪЛХЖЫАЖЦГАШИШНСЬЪХЪНБЭЪОСЫЛИРУЭЙЭТИЯЧФТХЫИФЕВЪЙЖОДЬЪХЙПРЙЫЕСЫВСУУПТЦЪДФЪСЪДСЛМРУОИЙЛШЪЧРФСДКЕИШЯЙТОДАЕЪЧХЛСЪО".ToLower();

        private static string sample372 =
            "ЕАСЗУВНУВРДУАЙЪБВФЪЙХТВАЙЪБВФЪЙЪКВЙПЪАХБЕУДАСЗТДЗХРУСТМЙЪФЪЙХЭУХЦХДРЩХМХУЕЩПУДТХБЕХМПЕУДУАСЗЯЩХЭИЗВЮЩПЖЕТХЗХФАСЗЩХБФВЪБЗГМЮЦЙЪМДЗЪЮХЮУСЮЗХИУХЮУВЮЩЪЮЩГРВЗЪЦЪЙЦЪИТДЙНЗСЭБЙГУЩЙДАЕЩВИЦВЗСИВЗЪЙПЕУХБЙГНЪЗЪЩВРЦЪРДЙДНЦЙВЭВЕЧХФЪЗУВФЦХЩЗХИВУХТМХЦЙЪЦЪИВЗФВИВЭФВИВЭЪТХЛДЩЮЩВЗАСЕТДЙНВИКДТЦХБФВАХФЪУЪНЩДЧЙДАЕЩЦХТУДМХЩЙВМГУДМХФУЕЗЮЕБХЗГАХБЗВНЪГБЗХИВЩУДФДЫДИЪЮЦВНВЗХУИУЕЩУХИТХЪБЗВНВЮТХЩЙЕИГМХЙЪМХФМХЗХЭДБХАГЫЗВЩВАЗДЮУГЗХЩЩХРДУУСЭЩХМХЙУДХЩГБЙХНСХЙХАДЗЕЩВТЛЪНУПИЮДБФВУВИХЗХЮЦДИЦХУКДЦХУКХИФХЫЗХАФХФДЗВНВАГЙУЪЦАСЗИТХДЭЙГЦДУХЮЩВЗХЮЩЙВЫУХХЩЩХБХТУДРЩХЯЩХАСЗЩХИВЙЪШТХЭЕЪЮДБХФУЕЕЮУХМХТУЖЮГЙХИСЭИНБЗЕФДБХМЙЕТХЭФЙГНПЕТХЪИЗЪЧЪДЮЙХЦЪИСАСЗЪЮЪЗПУСТЪЗЖФПТЪЮМВЮЪАХИВТНВЩДГЙХЦЪГЙХЦЪБУДИВЪЗЖАИЪВУВЩХЗЪЭЛЪБГЗЪУ".ToLower();
        private static string sample373 = "ДЮМНЗРЛЮЬДСЬЗЕЮТЪШАЬЛРЗПЗВЮНМЮЬЛСАПСЕСЖДШЩЭНЗЙШНТЩЬТВЮРКАРШБЗПЛШАЬЛРЗЮЛВТЬЬДЮАЖСВДРШЮЛЙСЛЗЙДЮМНЗЧВШПСРЬДЗИЬЛЮЙШЖЗБЗЪКРРСЙШХШСЬРЮСДЗДЮЧУИПСРОЗИЪЙТНПШЖЗПСБПЗЙЗДЛЮЪСВСЛССЕПСМЮЙЮЬЪКЙЮПБРЗЙТЛСОПЮЮПМЮРЮВШЙШНШЬЯНЗЮЬЛЗРУЬРЮАДВЗАМЙТЩЮАШМВСОПКАЮЬЛЗРУВЮЬЬШЯПЗРЬСМНЗИДВЮРУЮЛВТДЛРЮШЩЮЛЕЮЯШБЬСВНЖЗРКПТХСВПКАЬЛКНИПЮРКЕШЕСПСЕЧЮДВЮЯЪЮЙУЧЮВЗЭСПШАШЮЪШНПЮВЗРПЮНТОПЮШЬЧЮДЮАПЮВТДЗЕШИБЗЕДПТЙЗЬЙТЩХЛЮЪЫЛЮАВСХУЯПСНЮЬЛЮАПЮАПСЮЬДРСВПШЙЬИЬДЮВЪПКАНТЩЗППЗЗЩЕЗЛЮРЗХСВПССЛНЮВЮМЗЧВШЕЮВЬДЮМЮЬЗНЗЭСЙЛКШЬРСЭШГЮПЗВШИЮХСПУЬЧЮДЮАПЗИЛЮЙУДЮПСПЗНЮЬЮЕПЮЯЮПСЕМЮРЮВШЛУЛКЕШЙКАШРСВПКАЕКЪТНСЕНВТБУИЕШМТЙИЛУЖСЙЮРЗЛУЬИЬЛЗВСЛУШЙСМДШСЕСЬИЖКЪТНТЛПЗНПЗЕШДЗДЬПСЭПКСБРСБНКЙСЛСЛУЗППЗЗЩЕЗЛЮРЗЮНПЗШБЧСЬСПДЮЛЮВКСШЬЧЮЙПИЙРСВЛШПЬДША".ToLower();
        private static string sample374 = "ЯРЯЩЮФЮЙАИЯЮЕВЫБКЫЙЮЪШЭКЭЦИРЪЛЯЭЩББТЮНБЯАЖЙБФБИИЮГВДОЯЭЙЮФЫЬЮЕИБИРНЭКЭЮВЮЯЮЕЙЮЕЙИЮТЮИБШБФБИЯЮТШРЯЮИПАКЫЩЯРМАИБВБПРФЫИЮПОЮШЭКАЙЮБЕИБОИРЩЛБОБГВЮЕШЭШЮНЮТЮЕИБШРФЫИБЕВЮЩЙЮОНБОЫЯРЯАТНРЪОШБОАИРЯЭЩОРЖЦРЗЛБОРБОЯНДМЮЛИАЯАЛБЦЭОЯАНВАПАЦРЮТНРШЮЕЯОЮОДЬНРОЙЮЕАФАФЪЬЮЛИАЯГИБВЮЙИЪАВЮЙИАОЫИБИРШЮЯРЯЩЛБОФЮЦШБЩЫАЯРЯЬБЩВНАЪОИЮЮОШДЖРБОЭЩОРФЮБОБФЮРВНЮЖЮМАБШЭЙРЪОЩЙЭОИЮЛБНИЮОЮФЫЯЮЛПБНРЮЛШЮЛБФРРИИРРЖЙРОЮЛРГВЫЪЦРНРЦЮНБИИДЕШЮЙЦРЦФЭЪМАЦИЫЙЮЪЦРЮШАИЮПБЩОЛЮЛШЛЮБЙАЦРОБЬГГВЫЪЦРФЮМЫЙБИГВНБШРЛКАЖТЭЬЦРЙБНОЛДЕЖЮФЮШТФРЦЦРОЮПОЮЙАНМБЩОЮЯАТНЭЬЦРОЮПОЮЬЮТИБЩВРЩРИИРРЖЙРОЮЛРЯЮТШРГИЮПЫЪМШЭББВНАЖЮШРМАЦИЫЯРМБОЩГЛАЩАОИРЛЮФЮЩЯБПОЮВЮПБЩОАПОЮЪИЮЩОЫПОЮЩЛЮЬЮШРВНБШЙАФЮЕТЮЩОЫБЕЩШЭШЮПЯЮЕЛНЭЯБАЛЮОЛЮКФРЮОЯАИЭЛВЮЯНДЛРФЮЛИАЙРОБФЫИЮЛЦТФГИЭФРИРЙБИГБЕТЮЛЮНЪОДФЫШРИОЭШАЯОЮЛРФРЩОНРИАЗДРШРЮОЛБПРБОГРИИРРЖЙРОЮЛРЙЭЦР".ToLower();
        private static string sample381 = Normilize("pehjdziavahrazketakefakgayacaypzjpkefakgayjlvjprqyajllpsaalkgjkqilerqdptarksyqadzqujdktalqacakgqruehlztakgaadzqkleemrjrkgehfgpehjyalakkqdejdzqsqkryajlvallqzedkvjdkkemdevzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrehyiaieyqarkgapujdtaqdcqkqdfthkreiajyajlkefakgayiqfglpsyqfgkadqdfjrvazqatekgphehjdzqvqkggajzqdipgjdzrqrqkjdzuypzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrqkrjlladzqdfqfekkjrkennyakadzqdfvgevajyapehjdziaqujdraahrzpqdfjyavazedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrzedkkalliaujhraqkghykrqmdevvgjkpehjyarjpqdfrenlajrarkenaonljqdqdfzedkrnajmzedkrnajmzedkrnajmdeqmdevvgjkpehyakgqdmqdfjdzqzedkdaazpehyyajredrqmdevpehfeezqmdevpehfeezqmdevpehyajlfeezeg");

        private static string sample382 =
            "zphqaqpavqzmjmhmykzhmiqpsnpbhsimapprhmyzhmiqpsnpbhszlvqmyiuvppihszlvqmyiuvppimyizgkymyiupyqmhkyindmnzoqmgmyindqumlgkzznrpytjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqkomzuprypyqhprykytodqyndqzsyikiynzdkyqkaklgqisahjzdpeqvmyikomvgqinpndqhkyqkvpmiqizkfnqqynpypbyshuqrykyqlpmvmyindqznrpytupzzzmkioqvvuvqzzmhmzpsvjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqoqvvkbjpszqqhqmlphkyuqnnqrznqamzkiqmvpnpbhqyikiynmvpnpbhqyikqipyqbkznkzkrpyndqpndqrpbznqqvkbndqrktdnpyqipyntqnjpsndqyndqvqbnpyqokvvpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprq";
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private static string Normilize(string text)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i])) builder.Append(text[i]);
            }
            return builder.ToString();
        }

        public SettingsWindow(MainWindow window):this()
        {
            _window = window;
            NumberOfAttemptsTextBox.Text = window.Attempts.ToString();
        }

        private void ExecuteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var attempts = int.Parse(NumberOfAttemptsTextBox.Text);
            if (attempts != _window.Attempts)
            {
                _window.Attempts = attempts;
            }
            this.Close();
        }

        private void SetTextAndLeave(string text)
        {
            _window.CipherTextRichTextBox.SelectAll();
            _window.CipherTextRichTextBox.Selection.Text = text;
            var attempts = int.Parse(NumberOfAttemptsTextBox.Text);
            if (attempts != _window.Attempts)
            {
                _window.Attempts = attempts;
            }
            Close();
        }

        private void Sample36Label_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SetTextAndLeave(sample36);
        }

        private void Sample371Label_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SetTextAndLeave(sample371);
        }

        private void Sample372Label_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SetTextAndLeave(sample372);
        }

        private void Sample373Label_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SetTextAndLeave(sample373);
        }

        private void Sample374Label_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SetTextAndLeave(sample374);
        }

        private void Sample381Label_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SetTextAndLeave(sample381);
        }

        private void Sample382Label_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SetTextAndLeave(sample382);
        }
    }
}
