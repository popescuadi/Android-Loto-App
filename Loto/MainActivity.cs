
using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Android.Content.Res;
using System.Text;

//#if DEBUG
//[assembly: Application(Debuggable = true)]
//#else
//[assembly: Application(Debuggable=false)]
//#endif
namespace AppTest
{
    [Activity(Label = "Loto 6/49", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        //int count = 1;
        private Button lnBtn;
        private Button lnBtnNoroc;
        private Button inf;
        private string str = "41 4 10 8 16 36 37 47 14 22 23 15 32 15 36 17 21 30 37 43 45 2 4 6 13 25 12 24 7 38 43 33 44 9 27 45 14 22 28 3 26 17 1 13 15 41 19 20 46 36 23 25 21 30 1 6 7 16 34 38 2 4 9 41 12 13 28 10 17 36 42 5 44 10 17 14 32 49 30 41 48 16 27 31 48 4 6 26 9 19 33 37 44 47 29 3 5 15 35 36 18 25 43 45 10 38 46 1 46 5 27 45 2 9 11 21 35 44 48 16 33 42 1 5 6 15 17 18 20 23 31 8 18 29 13 25 9 12 20 23 5 24 33 36";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            string content;
            /* AssetManager assets = this.Assets;
             using (StreamReader sr = new StreamReader(assets.Open("a.txt")))
             {
                 content = sr.ReadToEnd();
             }*/

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);
            content = str;
            lnBtn = FindViewById<Button>(Resource.Id.button1);
            lnBtnNoroc = FindViewById<Button>(Resource.Id.button2);
            inf = FindViewById<Button>(Resource.Id.button3);
            lnBtn.Click += (object sender, EventArgs args) =>
              {
                  FragmentTransaction frag = FragmentManager.BeginTransaction();
                  SecondFrame sFrag = new SecondFrame(content,"first");
                  sFrag.Show(frag, "frag_dialog");
              };
            lnBtnNoroc.Click += (object sender, EventArgs args) =>
            {
                FragmentTransaction frag = FragmentManager.BeginTransaction();
                SecondFrame sFrag = new SecondFrame(content, "second");
                sFrag.Show(frag, "frag_dialog");
            };
            inf.Click += (object sender, EventArgs args) =>
            {
                FragmentTransaction frag = FragmentManager.BeginTransaction();
                SecondFrame sFrag = new SecondFrame(content, "third");
                sFrag.Show(frag, "frag_dialog");
            };
        }
    }
}

