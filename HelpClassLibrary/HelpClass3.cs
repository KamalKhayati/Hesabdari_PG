/****************************** Ghost.github.io ******************************\
*	Module Name:	HelpClass3.cs
*	Project:		HelpClassLibrary
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2019 / 1 / 15   04:26 ب.ظ
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpClassLibrary
{
    class HelpClass3
    {
        //|====================> کد تایمر بارگذاری Timer <=============================|
        //System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        //void timer_Tick(object sender, EventArgs e)
        //{
        //    ps.Value += 20;
        //    if (ps.Value == 100)
        //    {
        //        timer.Stop();
        //        new MainWindow().ShowDialog();
        //        this.Close();
        //    }
        //}
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    timer.Interval = TimeSpan.FromMilliseconds(1000);
        //    timer.Tick += new EventHandler(timer_Tick);
        //    timer.Start();
        //}
        //|================================================================|

        //|====================> ساعت دیجیتالی در تکس باکس روی فرم DateTime <=============================|
        //public Window5()
        //{
        //    InitializeComponent();
        //    timer.Tick += new EventHandler(timer_Click);
        //    timer.Start();
        //}
        //System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        //private void timer_Click(object sender, EventArgs e)
        //{
        //    textBox.Text = DateTime.Now.Hour.ToString("0#");
        //    textBox.Text += ":";
        //    textBox.Text += DateTime.Now.Minute.ToString("0#");
        //    textBox.Text += ":";
        //    textBox.Text += DateTime.Now.Second.ToString("0#");
        //}


        //|====================> Open File <=============================|
        //private void Open_Click(object sender, RoutedEventArgs e)
        //{
        //    Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
        //    open.Filter = "text file|*.txt";
        //    open.FileName = "";
        //    open.Title = "فایل مورد نظر را انتخاب فرمایید";
        //    open.ShowDialog();
        //    textBox1.Text = System.IO.File.ReadAllText(open.FileName);
        //}

        //|====================> Save File <=============================|
        //private void Save_Click(object sender, RoutedEventArgs e)
        //{
        //    Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
        //    save.Filter = "text file|*.txt";
        //    save.FileName = "kamal";
        //    save.Title = "لطفا فایل را ذخیره کنید";
        //    save.ShowDialog();
        //    System.IO.File.WriteAllText(save.FileName, textBox1.Text);
        //    MessageBox.Show("محتویات فایل ذخیره شد");
        //}
        //|================================================================|

        //|====================> DateTime Persian <=============================|
        //System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
        //txtbox1.Text = p.GetYear(DateTime.Now).ToString() +"/"+ p.GetMonth(DateTime.Now).ToString("0#")
        //        +"/"+ p.GetDayOfMonth(DateTime.Now).ToString("0#");
        //|================================================================|

        //|====================> Print <=============================|
        //private void button_Print_Click(object sender, RoutedEventArgs e)
        //{
        //    StiReport s = new StiReport();
        //    s.Load("mrt/Report.mrt");
        //    s.Compile();
        //    s.ShowWithRibbonGUI();
        //}
        //|================================================================|

        //|====================> WebBrowser <=============================|
        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    wb.Source = new Uri(textBox.Text);
        //}
        //|================================================================|

        //|====================> Xaml : ToolTip  <=============================|
        //<Button x:Name="button" Content="Button" HorizontalAlignment="Left" VerticalAlignment="Top" Width="264" Height="118" Margin="268,38,0,0" FontSize="35">
        //    <Button.ToolTip>
        //        <ToolTip>
        //            <StackPanel>
        //                <TextBlock FontWeight = "Bold" > سلام </ TextBlock >
        //                < TextBlock > این دکمه را کلیک کن</TextBlock>
        //            </StackPanel>
        //        </ToolTip>
        //    </Button.ToolTip>
        //</Button>

        //|====================> Xaml : SpellCheck  <=============================|
        //<TextBox x:Name="textBox1" TextWrapping="Wrap" Margin="268,201,260,176" FontFamily="Tahoma" FontSize="24" SpellCheck.IsEnabled="True" Language="en-US"/>

        //|====================> Xaml : Expander  <=============================|
        //<Expander Header = "عملیات فرعی " FlowDirection="RightToLeft" FontFamily="Tahoma" FontSize="22">
        //    <StackPanel>
        //        <Label Content = "مقطع تحصیلی" />
        //        < CheckBox Margin="5" Content="کاردانی"/>
        //        <CheckBox Margin = "5" Content="کارشنانی"/>
        //        <CheckBox Margin = "5" Content="کارشناسی ارشد"/>
        //    </StackPanel>
        //</Expander>

        //|====================> listBox Fill  <======================================|
        //public Window3()
        //{
        //    InitializeComponent();
        //    listBox1.ItemsSource = GetData();
        //}

        //private ArrayList GetData()
        //{
        //    ArrayList list = new ArrayList();
        //    list.Add("Kamal");
        //    list.Add("jamal");
        //    list.Add("jalal");
        //    list.Add("kaveh");
        //    return list;
        //}

        //|====================> Xaml : Click Right (Copy,Cut,Paste)  <=============================|
        //<RichTextBox x:Name="richTextBox" HorizontalAlignment="Left" Height="348" Margin="375,10,0,0" VerticalAlignment="Top" Width="362">
        //    <RichTextBox.ContextMenu>
        //        <ContextMenu>
        //            <MenuItem Command = "Copy" />
        //            < MenuItem Command="Cut"/>
        //            <MenuItem Command = "Paste" />
        //        </ ContextMenu >
        //    </ RichTextBox.ContextMenu >
        //</ RichTextBox >

        //|====================> Xaml : زاویه دار کردن فرمها  <=============================|
        //<Grid >
        //    <Border BorderBrush = "Bisque" BorderThickness="2" CornerRadius="300,0,300,0" Background="#FF568113"/>
        //</Grid>

        //|====================> Xaml : تغییر سایز فرم بدون در نظر گرفتن رزولیشن مونیتور  <=============================|
        // <Grid>
        //    <DockPanel LastChildFill = "True" >
        //        < Button x:Name="button" Content="Button"  DockPanel.Dock="Top"/>
        //        <Button x:Name="button_Copy" Content="Button"   DockPanel.Dock="Bottom"/>
        //        <Button x:Name="button_Copy1" Content="Button"   DockPanel.Dock="Left" />
        //        <Button x:Name="button_Copy3" Content="Button3"  DockPanel.Dock="Left" />
        //        <Button x:Name="button_Copy2" Content="Button"   DockPanel.Dock="Right" />
        //        <Button x:Name="button_Copy4" Content="Button"   DockPanel.Dock="Right" />
        //        <Image Source = "img/faradars-profile-picture.png" />
        //    </ DockPanel >
        //</ Grid >

        //|====================> محدود کردن تکس باکس به ورود اعداد  <=============================|
        //bool ValidateNumeric(string str)
        //{
        //    bool ret = true;
        //    int l = str.Length;
        //    for (int i = 0; i < l; i++)
        //    {
        //        char ch = str[i];
        //        ret &= char.IsDigit(ch);

        //    }
        //    return ret;
        //}
        //private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    e.Handled = !ValidateNumeric(e.Text);
        //    base.OnPreviewTextInput(e);
        //}

        //|====================> صحیح واردکردن ایمیل در تکس باکس  <=============================|
        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!textEmail.Text.Contains("@") || !textEmail.Text.Contains("."))
        //    {
        //        MessageBox.Show("ایمیل صحیح وارد شود");
        //    }
        //}

        //|====================> The sizeof Operator Memory Size اختصاص دادن حافظه به متغیرها  <=============================|
        //   The sizeof Operator
        // ==========================
        // Data Type    Memory Size
        // --------------------------
        // char           2 Bytes
        // bool           1 Bytes
        // int            4 Bytes
        // uint           4 Bytes
        // short          2 Bytes
        // ushort         2 Bytes
        // byte           1 Bytes
        // sbyte          1 Bytes
        // float          4 Bytes
        // double         8 Bytes
        // decimal       16 Bytes
        // long           8 Bytes
        // ulong          8 Bytes
        // 1 Byte = 8 bit
        //===========================

        //|====================> استفاده از عملگر ؟؟  <=============================|
        // برای اینکه یک متغییر مقدار تهی را قبول کند از عملگر ؟ بعد از نوع داده ای استفاده میشود
        //        double ? distance = null;
        //‎        double ? fromTo = null;

        //اگر مقدار دیستنس تهی باشد مقدار 135/85 را برمیگرداند در غیراینصورت مقدار غیر تهی دیستنس را برمیگرداند 
        //‎        fromTo = distance ?? 135.85;

        //|====================> عملگرهای  شرطی سه تایی تو در تو  <=============================|
        //public class Program
        //{
        //    public static void Main()
        //    {
        //        int x = 2, y = 10;

        //        string result = x > y ? "x is greater than y"
        //                                : x < y ? "x is less than y"
        //                                    : x == y ? "x is equal to y" : "No result";

        //        Console.WriteLine(result);
        //    }
        //}

        //|====================> Value Type ولیو تایپ ها  <=============================|
        // همه ی داده نوع هایی که در زیر آورده شده است از نوع ولیو تایپ هستتند

        // bool    byte   char    decimal   double
        // enum    float  int     long      sbyte
        // short   sbyte  unit    ulong     ushort

        //         داده نوع های زیر همگی رفرنس تایپ هستند :

        //|====================> Reference Type رفرنس تایپ ها  <=============================|
        // String
        // تمام آرایه ، حتی اگر مقادیر آنها از نوع ولیو تایپ باشند   
        // Class
        // Delegates

        //|====================> Interface اینترفیس  <=============================|
        // یک اینترفیس تنها شامل تعاریف متد ها ، رویداد ها و صفات است.
        // یک اینترفیس میتواند به صورت صریح و یا ضمنی پیاده سازی شود 
        // یک اینترفیس نمیتواند شامل اعضای پرایویت باشد.تمام اعضای یک اینترفیس به صورت پیشفرض پابلیک هستند.

        //interface ILog
        //{
        //    void Log(string msgToLog);
        //}

        //class ConsoleLog : ILog
        //{
        //    public void ILog.Log(string msgToPrint) // explicit implementation
        //    {
        //        Console.WriteLine(msgToPrint);
        //    }
        //}

        //تعریف صریح زمانی که کلاسی داریم که چندین اینترفیس را پیاده سازی میکند مفید
        //است در این صورت کد نوشته شده خوانا تر و پیچیدگی آن کمتر است و وقتی مفید تر خواهد
        //شد که اینترفیس ها دارای متد های با نام یکسانی باشند.

        //|====================> انواع عملگرها  <=============================|
        // عملگرهای ریاضی 
        //Operator    Description             Example
        //+	    	  جمع                     A + B = 30
        //-	    	  تفریق                   A - B = -10
        //*	    	  ضرب                     A * B = 200
        ///	    	  تقسیم                   B / A = 2
        //%	    	  باقیمانده‌ی تقسیم       B % A = 0
        //++		  یک واحد افزایش         A++ = 11
        //--		  یک واحد کاهش           A-- = 9

        // عملگرهای رابطه‌ای
        //Operator    Description             Example
        //==		  تساوی دو مقدار         (A == B) is not true.
        //!=		  عدم تساوی دو مقدار     (A != B) is true.
        //>	          بزرگتر                  (A > B) is not true.
        //<	          کوچکتر                  (A < B) is true.
        //>=          بزرگتر مساوی           (A >= B) is not true.
        //<=	      کوچکتر مساوی           (A <= B) is true.

        // عملگرهای منطقی
        //Operator      Description         Example
        //&&	        AND                 (A && B) is false.
        //||	        OR                  (A || B) is true.
        //!	            مخالف AND = OR     !(A && B) is true.

        // عملگرهای انتسابی
        //Operator        Description                Example
        //=	              تساوی                      C = A + B مقدار C = مجموع A+B
        //+=	          جمع تساوی                  C += A برابر است با C = C + A
        //-=	          تفریق تساوی                C -= A برابر است با C = C - A
        //*=	          ضر ب تساوی                 C *= A برابر است با to C = C * A
        ///=              تقسیم تساوی                C /= A برابر است با to C = C / A
        //%=              باقیمانده تساوی            C %= A برابر است با to C = C % A
        //<<=             انتقال به چپ مساوی         C <<= 2 برابر است با C = C << 2
        //>>=             انتقال به راست مساوی         C >>= 2 برابر است با C = C >> 2
        //&=              دستور AND مساوی            C &= 2 برابر است با C = C & 2
        //^=              دستور XOR مساوی            C ^= 2 برابر است با C = C ^ 2
        //|=              دستور OR مساوی             C |= 2 برابر است با C = C | 2

        // عملگرهای متفرقه
        //Operator         Description                                           Example
        //sizeof()         دستیابی به سایز یک داده	                             sizeof(int), returns 4.
        //typeof()         دستیابی به نوع یک داده	                             typeof(StreamReader);
        //&	               دستیابی به آدرس یک متغییر                           &a; returns actual address of the variable.
        //*	               اشاره به یک متغییر	                                 *a; creates pointer named 'a' to a variable.
        //? :	           عبارت شرطی                                           IF If Condition is true ? Then value X : Otherwise value Y
        //is	           مشخص کردن اینکه یک شیء شامل یک نوع خاص است یا نه   If(Ford is Car) // checks if Ford is an object of the Car class.

        //بهتر است اولویت این عملگرها را بدانیم یعنی 
        //اگر داخل یک عبارت مجموعه‌ای از این عملگرها قرار گرفت ابتدا کدامیک محاسبه می‌شوند:
        //Category              Operator                            Associativity
        //پسوندی               () [] -> . ++ - -	                Left to right
        //محاسباتی جمع تفریق	+ - ! ~ ++ - - (type) * & sizeof	Right to left
        //ضرب  و تقسیم	        * / %	                            Left to right
        //جمع و تفریق	        + -	                                Left to right
        //انتقال 	            << >>	                            Left to right
        //رابطه‌ای              < <= > >=	                        Left to right
        //تساوی	                == !=	                            Left to right
        //AND                   &	                                Left to right
        //XOR	                ^	                                Left to right
        //OR	                |	                                Left to right
        //AND منطقی            &&	                                Left to right
        //OR منطقی             ||	                                Left to right
        //شرطی	                ?:	                                Right to left
        //انتسابی              = += -= *= /= %=>>= <<= &= ^= |=    Right to left
        //کاما                 ,                                   Left to right

        //|================================> switch سویچ  <=============================================|
        //public static void Main()
        //{
        //    string statementType = "switch";

        //    switch (statementType)
        //    {
        //        case "DecisionMaking":
        //            Console.Write(" is a decision making statement.");
        //            break;
        //        case "if.else":
        //            Console.Write("if-else");
        //            break;
        //        case "ternary":
        //            Console.Write("Ternary operator");
        //            break;
        //        case "switch":
        //            Console.Write("switch statement");

        //            goto case "DecisionMaking";
        //        default:
        //            Console.WriteLine("Unknown value");
        //            break;
        //    }
        //}

        //|====================> For حلقه  <=============================|
        //حلقه ی فور مجموعه‌ای از دستورات را تا زمانی که شرط 
        //مشخص شده در آن  صحیح ارزیابی میشود به صورت تکراری اجرا می‌کند.
        //public static void Main()
        //{
        //    int i = 0;

        //    for (; ; )
        //    {
        //        if (i < 10)
        //        {
        //            Console.WriteLine("Value of i: {0}", i);
        //            i++;
        //        }
        //        else
        //            break;
        //    }
        //}

        //for (int i = 0; i< 10; i++)
        //{
        //    if(i == 5 )
        //        break;

        //    Console.WriteLine("Value of i: {0}", i);
        //}

        //|====================> while حلقه  <=============================|
        //از حلقه ی وایل برای اجرای مجموعه ای از دستورات به صورت تکراری استفاده میشود
        //public static void Main()
        //{
        //    int i = 0;

        //    while (i < 10)
        //    {
        //        Console.WriteLine("Value of i: {0}", i);

        //        i++;
        //    }
        //}

        //public static void Main()
        //{
        //    int i = 0;

        //    while (true)
        //    {
        //        Console.WriteLine("Value of i: {0}", i);

        //        i++;

        //        if (i > 10)
        //            break;
        //    }
        //}

        //|====================> Interface اینترفیس  <=============================|
        // حلقه ی دو وایل همانند حلقه وایل عمل می کند مگر در یک مورد
        //و آن این است که حلقه دو وایل کدهای موجود در بدنه ی خود را برای حداقل
        //یک بار اجرا می‌کند و این مورد به این دلیل است که حلقه ی دو وایل در ابتدا 
        //بلاک های کد موجود در بدنه خود را اجرا کرده و سپس شرط حلقه را بررسی می نماید
        //public static void Main()
        //{
        //    int i = 0;
        //    do
        //    {
        //        Console.WriteLine("Value of i: {0}", i);
        //        i++;
        //    } 
        //    while (i < 10);
        //}
        //--------------------------------
        // int i = 0;
        //do
        //{
        //    Console.WriteLine("Value of i: {0}", i);
        //    i++;
        //    if (i > 5)
        //        break;
        //} 
        //while (true);

        //|====================> Struct ساختارها  <=============================|
        //        ویژگی های یک ساختار
        // ساختار ها می توانند شامل سازنده ها ، ثابت ها ، فیلد ها
        //،متدها ، صفات ، شاخص ها ، عملگرها ، رویدادها و انواع تودرتو باشند .
        // یک ساختار نمی تواند شامل یک سازنده و یا مخرب پیش فرض باشد.
        // ساختارها می‌توانند اینترفیس ها را پیاده سازی کنند.
        // ساختار ها نمی‌توانند از یک کلاس یا ساختاری دیگر ارث بری کنند.
        // اعضای یک ساختار نمی توانند abstract ، virtual و یا protected باشند.
        // به منظور استفاده از اعضای یک ساختار
        //از جمله صفات ، متد ها و رویدادها باید آن ساختار با کلمه رزرو شده نیو مقدار دهی اولیه شود.
        //ساختار یک ولیو تایپ است و با استفاده از کلمه رزرو شده استراکت تعریف می شود.
        // ساختارها می توانند با و یا بدون کلمه رزرو شده نیو نمونه‌سازی شوند.
        // اگر بخواهید اعضای یک 
        //ساختار برای شما در دسترس باشد باید از کلمه رزرو شده ی نیو برای نمونه سازی آن استفاده کنید.
        //در استراکت نمیتوان فیلدها را مستقیم مقدار دهی کرد و بایستی حتما در متد سازنده ویا متد میین مقدار دهی شوند
        //اگر بخواهیم سازنده دیگری تعریف کنیم بایستی تمامی فیلدها در متد سازنده جدید توسط کاربر مقدار دهی شوند

        //|===================================> enum شمارنده  <==============================================|
        //در زبان برنامه نویسی سی شارپ شمارنده ها داده نوعی از نوع ولیو تایپ هستند
        //شمارنده ها برای انتخاب نام برای یک ثابت عددی استفاده میشوند
        //شمارنده ها می توانند دارای مقداری با هرداده نوع عددی معتبر باشند
        //شمارنده ها برای داده نوع رشته ای در سی شارپ پشتیبانی نمی شود
        //        enum WeekDays
        //        {
        //            Monday = 0,
        //            Tuesday = 1,
        //            Wednesday = 2,
        //            Thursday = 3,
        //            Friday = 4,
        //            Saturday = 5,
        //            Sunday = 6
        //        }
        //        Console.WriteLine(WeekDays.Friday);
        //        Console.WriteLine((int) WeekDays.Friday);

        //|=====================================> StringBuilder استرینگ بیلدر  <============================================|

        //یک رشته ، تغییر ناپذیر است و این به این معناست که بعد از آنکه رشته ای ایجاد شد نمی‌توان آن را در حافظه تغییر داد
        //با استفاده از کلاس استرینگ بیلدر میتوان رشته های پویایی ایجاد کرد که قابل تغییر هستند
        //در هنگام الحاق چندین رشته به هم دیگر استرینگ بیلدر سریع‌تر 
        //از استرینگ عمل می‌کند. از استرینگ بیلدر برای الحاق بیشتر از سه یا چهار رشته به همدیگر 
        //استفاده کنید برای الحاق دو یا سه رشته ، استرینگ کارایی بیشتری نسبت به استرینگ بیلدر دارد
        //StringBuilder sb = new StringBuilder();
        //or
        //stringbuilder sb = new stringbuilder("hello world!!");

        //یا

        //stringbuilder sb = new stringbuilder(50);
        //or
        //StringBuilder sb = new StringBuilder("Hello World!!", 50);

        //sb.Append("World!!");
        //sb.AppendLine("Hello C#!");
        //sb.AppendLine("This is new line.");
        //Console.WriteLine(sb);

        //متدهای مهم کلاس StringBuilder
        //(StringBuilder.Append(valueToAppend : این متد مقدار رشته ای را که به عنوان آرگومان می پذیرد به انتهای رشته StringBuilder اضافه می کنند
        //()StringBuilder.AppendFormat : این متد مقدار رشته ای را که به عنوان آرگومان می پذیرد با الگوی مشخص شده فرمت بندی می کنند
        //(StringBuilder.Insert(index, valueToAppend : این متد رشته ای را در مکان مشخص شده از رشته StringBuilder قرار می‌دهد
        //(StringBuilder.Remove(int startIndex, int length : این متد تعداد مشخصی از کاراکترها را از مکانی مشخص از رشته StringBuilder حذف می کند
        //(StringBuilder.Replace(oldValue, newValue : این متد کاراکترهای را مشخص شده را با کاراکتر های جدید جایگزین می کند.
        //()AppendLine :متد ()AppendLine رشته ای را با یک خط جدید به انتهای رشته StringBuilder  می افزاید.
        //()ToString : از متد ()ToString برای بدست آوردن رشته یک StringBuilder می توان استفاده کرد

        //|================================> Array آرایه های یک بعدی  <========================================|
        //تعریف آرایه
        //یک آرایه می‌تواند با استفاده از یک نوع داده که به دنبال آن[] می آید، تعریف شود :
        //int[] intArray;  // can store int values
        //bool[] boolArray; // can store boolean values
        //string[] stringArray; // can store string values
        //double[] doubleArray; // can store double values
        //byte[] byteArray; // can store byte values
        //Student[] customClassArray; // can store instances of Student class

        // مقدار دهی آرایه ها در هنگام تعریف
        //int[] intArray1 = new int[5];
        //int[] intArray2 = new int[5] { 1, 2, 3, 4, 5 };
        //int[] intArray3 = { 1, 2, 3, 4, 5 };

        //می توان با استفاده از یک حلقه فور تمام مقادیر یک آرایه را در صفحه کنسول چاپ کرد :
        //int[] intArray = new int[5] { 10, 20, 30, 40, 50 };
        //for(int i = 0; i<intArray.Length; i++)
        //    Console.WriteLine(intArray[i]);

        //کلاس های کمکی برای آرایه ها
        //int[] intArr = new int[5] { 2, 4, 1, 3, 5 };
        //Array.Sort(intArr);
        //Array.Reverse(intArr);

        //|================================> Array آرایه های دوبعدی بعدی  <========================================|
        //مقادیر یک آرایه چند بعدی می‌تواند با استفاده از دو مقدار
        //ایندکس مورد دستیابی قرار گیرد.هر دو ایندکس از صفر آغاز می‌شوند :

        //int[,] intArray = new int[3, 2]{
        //                                {1, 2},
        //                                {3, 4},
        //                                {5, 6}
        //                               };

        //intArray[0, 0]; //Output: 1
        //intArray[0, 1]; // 2

        //intArray[1, 0]; // 3
        //intArray[1, 1]; // 4

        //intArray[2, 0]; // 5
        //intArray[2, 1]; // 6
        //در نمونه مثال بالاایندکس 2و1 مقدار ۶ را برمیگرداند.در اینجا دو به معنای 
        //سطر سوم و یک به معنای ستون 
        //دوم است سطر ها و ستون‌ها از صفر آغاز می‌شوند

        //|================================> آرایه های Jagged  <========================================|
        //یک آرایه جاگد به جای اینکه مقادیری
        //را در خود ذخیره کند آرایه ها را در خود ذخیره میکند.یک آرایه جاگد با استفاده از
        //دو براکت[][] مقدار دهی اولیه می شود. در براکت اول اندازه خود آرایه مشخص میشود و در 
        //براکت دوم ابعاد آرایه هایی که قرار است در آن ذخیره سازی شوند تعیین می شود.

        //آرایه جاگد زیر دو آرایه یک بعدی را در خود ذخیره میکند :
        //int[][] intJaggedArray = new int[2][];

        //intJaggedArray[0] = new int[3]{1,2,3};

        //intJaggedArray[1] = new int[2]{4,5};

        //Console.WriteLine(intJaggedArray[0][0]); // 1

        //Console.WriteLine(intJaggedArray[0][2]); // 3

        //Console.WriteLine(intJaggedArray[1][1]); // 5

        //آرایه جاگد زیر، آرایه های چند بعدی را در خود ذخیره میکند. [,] اشاره
        //به ذخیره سازی آرایه های چند بعدی دارد :

        //int[][,] intJaggedArray = new int[3][,];
        //intJaggedArray[0] = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        //intJaggedArray[1] = new int[2, 2] { { 3, 4 }, { 5, 6 } }; 
        //intJaggedArray[2] = new int[2, 2];

        //Console.WriteLine(intJaggedArray[0][1, 1]); // 4

        //Console.WriteLine(intJaggedArray[1][1, 0]); // 5

        //Console.WriteLine(intJaggedArray[1][1, 1]); // 6

        //|================================> ArrayList اری لیست  <========================================|
        //ArrayList
        //کلاس اری لیست یک کالکشن از نوع نان جنریک در سی شارپ است که می تواند شامل هر نوع داده ای باشد.هنگامی که مقداری را به این کالکشن اضافه می کنیم اندازه آن به صورت خودکار افزایش می یابد 
        //و بر خلاف آرایه ها در زمان تعریف نیاز به مشخص کردن اندازه ی آن ندارید.اعلان یک اری لیست به شکل زیر است :

        //ArrayList myArryList = new ArrayList();

        //صفات و متد های مهم ArrayList
        //Capacity : تعداد آیتم هایی که اری لیست می تواند در خود نگه دارد را مشخص میکند.
        //Count : تعداد عناصری که در اری لیست قرار گرفته‌اند را مشخص میکند.
        //() Add : با استفاده از متد Add می‌توان یک مقدار را به انتهای اری لیست افزود.
        //() AddRange : با استفاده از متد AddRange می توان مجموعه ای از مقادیر را به اری لیست افزود.
        //() Insert : با استفاده از متد Insert میتوان یک مقدار را در مکان مشخصی از اری لیست درج کرد.
        //() InsertRange : با استفاده از متد InsertRange می توان مجموعه ای از عناصر را در یک مکان مشخص به بعد در اری لیست درج کرد.
        //() RemoveAt : با استفاده از متد Remove می‌توان عنصری خاص را در مکانی مشخص از آرایه حذف کرد.
        //() Remove : با استفاده از متد Remove میتوان عنصری را از اری لیست حذف کرد.
        //() RemoveRange : با استفاده از متد RemoveRange میتوان مجموعه ای از عناصر را از اری لیست حذف کرد.
        //() Sort : با استفاده از متد Sort میتوان  عناصر موجود در جایگزین را مرتب سازی کرد.
        //() Reverse : با استفاده از متد Reverse میتوان ترتیب قرار گرفتن مقادیر در اری لیست را عکس کرد.
        //() Contains :  بررسی می کند که عنصر مورد نظر در اری لیست وجود دارد یا نه.در صورتی که وجود داشته باشد مقدار true و در غیر این صورت مقدار false را برمیگرداند.


        //|================================> SortedList کلاس سورت لیست  <========================================|
        //با استفاده از کلاس سورت لیست میتوان مجموعه ای از مقادیر را ذخیره سازی کرد. این کالکشن مقادیر را به صورت key و value ذخیره میکند.

        //SortedList sortedList1 = new SortedList();
        //sortedList1.Add("one", 1);
        //sortedList1.Add("two", 2);
        //sortedList1.Add("three", 3);
        //sortedList1.Add("four", 4);

        //foreach(DictionaryEntry kvp in sortedList1 )
        // Console.WriteLine("key: {0}, value: {1}", kvp.Key , kvp.Value );

        //|================================> stack , Queue , Hashtable توضیح مختصر  <========================================|

        //استک نوع خاصی از کالکشن ها در سی شارپ است که عملیات ذخیره سازی مقادیر را به صورت لایفو انجام میدهد. و 
        //این بدان معناست که آخرین مقداری که وارد استک میشود، اولین مقداری است که از آن خارج میشود.

        //کویی نوع خاصی از کالکشن ها در سی شارپ 
        //است که عملیات ذخیره سازی مقادیر را به صورت فایفو انجام میدهد. و این بدان معناست که اولین 
        //مقداری که وارد کویی میشود، اولین مقداری است که از آن خارج میشود

        //با استفاده از کلاس هش تیبل میتوان مجموعه ای از مقادیر را ذخیره سازی کرد.
        //این کالکشن مقادیر را به صورت key و value ذخیره میکند.

    }
}
