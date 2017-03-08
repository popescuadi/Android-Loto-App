using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppTest
{
    class SecondFrame:DialogFragment
    {
        private string str;
        private string[] data;
        private string wh;
        public SecondFrame(string a,string what):base()
        {
            str = a;
            wh = what;
            if (what == "first")
                First();
            if (what == "second")
                Second();
        }
        private void First()
        {
            DateTime localDate = DateTime.Now;
            CoreData dx = new CoreData();
            dx.GetData(str);
            int x = int.Parse(GetDate(localDate.Month.ToString()));
            data = dx.GetNumbers(x);
        }
        private void Second()
        {
            int[] first_vec;
            data = new string[12];
            CoreData dx = new CoreData();
            first_vec = dx.GetRandomNumbers();
            for (int i = 0; i < 6; i++)
                data[i] = first_vec[i].ToString();
            int[] sec_vec = dx.GetRandomNumbers();
            for (int i = 6; i < 12; i++)
                data[i] = sec_vec[i-6].ToString();
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog, container, false);
            try
            {
                //FindViewById<TextView>(Resource.Id.editText1);
                if (wh=="second")
                {
                    var txtvw1= view.FindViewById<TextView>(Resource.Id.textView1);
                    string txt_str = "Primul bilet norocos!";
                    txtvw1.Text = txt_str;
                    var txtvw2 = view.FindViewById<TextView>(Resource.Id.textView2);
                    txt_str = "Al doilea bilet norocos!";
                    txtvw2.Text = txt_str;
                }
                if (wh=="third")
                {

                    var txtvw1 = view.FindViewById<TextView>(Resource.Id.textView1);
                    string txt_str = "Primul buton genereaza numerele ce au aparut cel mai des in biletele castigatoare(corespunzatoare lunii curente) din anul 1993 pana in prezent!";
                    txtvw1.Text = txt_str;
                    TextView txx = view.FindViewById<TextView>(Resource.Id.editText1);
                    txt_str = "Al doilea buton genereaza 13 milioane bilete si selecteaza biletele ce apar de cele mai multe ori!";
                    txx.Text = txt_str;
                    var txtvw2 = view.FindViewById<TextView>(Resource.Id.textView2);
                    txt_str = "Pentru sugestii sau probleme va rog sa ne contactati la adresele: popescuadrian1095@yahoo.ro \nsau \n briasimi@gmail.com ";
                    txtvw2.Text = txt_str;
                    return view;
                }
                TextView tx = view.FindViewById<TextView>(Resource.Id.editText1);
                TextView tx1 = view.FindViewById<TextView>(Resource.Id.editText2);
                string dataForText1 = "";
                for (int i = 0; i < 6; i++)
                    dataForText1 += data[i] + " ";
                string dataForText2 = "";
                for (int i = 6; i < 12; i++)
                    dataForText2 += data[i] + " ";
                tx.Text = dataForText1;
                tx1.Text = dataForText2;
            }
            catch (Exception ex)
            {
                ShowAlert("Unexpected error!/n Please contact me at /n popescuadrian1095@yahoo.ro");
            }
            return view;
        }
        private string GetDate(string data)
        {
            switch (data)
            {
                case "ianuarie":
                    return "1";
                    break;
                case "februarie":
                    return "2";
                    break;
                case "martie":
                    return "3";
                    break;
                case "aprilie":
                    return "4";
                    break;
                case "mai":
                    return "5";
                    break;
                case "iunie":
                    return "6";
                    break;
                case "iulie":
                    return "7";
                    break;
                case "august":
                    return "8";
                    break;
                case "septembrie":
                    return "9";
                    break;
                case "octombrie":
                    return "10";
                    break;
                case "noiembrie":
                    return "11";
                    break;
                case "decembrie":
                    return "12";
                    break;
                default:
                    break;
            }
            return "1";
        }
        public void ShowAlert(string str)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this.Context);
            alert.SetTitle(str);
            alert.SetPositiveButton("OK", (senderAlert, args) => {
                // write your own set of instructions
            });

            //run the alert in UI thread to display in the screen
                alert.Show();
        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}