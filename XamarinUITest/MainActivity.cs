using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;

namespace XamarinUITest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Android.Widget.Button button1;
        Android.Widget.Button button2;
        Android.Widget.Button button3;
        Android.Widget.CheckBox CheckBox1;
        Android.Widget.CheckBox CheckBox2;
        Android.Widget.CheckBox CheckBox3;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        private void Setup()
        {   
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            button3 = FindViewById<Button>(Resource.Id.button3);
            CheckBox1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
            CheckBox2 = FindViewById<CheckBox>(Resource.Id.checkBox1);
            CheckBox3 = FindViewById<CheckBox>(Resource.Id.checkBox1);

            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            
            switch (b.Text) 
            {
                case "button1":
                    CheckBox1.Checked = FlipBool(CheckBox1.Checked);
                    break;
                case "button2":
                    CheckBox2.Checked = FlipBool(CheckBox2.Checked);
                    break;
                case "button3":
                    CheckBox3.Checked = FlipBool(CheckBox3.Checked);
                    break;
                default: break;
            }

            throw new NotImplementedException();
        }

        private bool FlipBool(bool bContinue)
        {
            bool returnBool = false;

            if (bContinue)
            {
                returnBool = false;
            }
            else
            {
                returnBool = true;
            }

            return returnBool;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}


