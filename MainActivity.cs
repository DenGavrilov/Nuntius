using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;

namespace Nuntius
{
    [Activity(Label = "Nuntius", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private Button mBtnSignIn;
        private ProgressBar mProgressBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mBtnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);

            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            mBtnSignIn.Click += mBtnSignIn_Click;
            

        }

        private void mBtnSignIn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SignUpActivity));
            this.StartActivity(intent);
        }
    }
}

