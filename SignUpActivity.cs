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
using Android.Views.InputMethods;
using System.Net;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;
using System.Data;
using Android.Support.V4.App;
using static Android.App.AlertDialog;
using System.IO;
//using Android.Support.V7.Widget;
//using Android.Support.V7.App;

namespace Nuntius
{
    //public class OnSignUpEventsArgs: EventArgs
    //{
    //    public string mPhone;

     //   public string Phone
      //  {
      //      get { return mPhone; }
       //     set { mPhone = value; }
        //}
        
        //public OnSignUpEventsArgs(string phone):base()
        //{
        //    Phone = phone;
        //}
   // }
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Activity
    {
        private EditText mTxtNumber;
        private Button mBtnSignUp;
        private TextView mAllCountries;
        private EditText mAutoNumber;

        //public event EventHandler<OnSignUpEventsArgs> mOnSignUpComplete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.SignUpScreen);
            base.OnCreate(savedInstanceState);

            mAllCountries = FindViewById<TextView>(Resource.Id.allCountries);
            mTxtNumber = FindViewById<EditText>(Resource.Id.txtNumber);
            mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            mAutoNumber = FindViewById<EditText>(Resource.Id.autoNumber);

            var lg = System.Globalization.CultureInfo.CurrentCulture.Name;

            mAllCountries.Text = Intent.GetStringExtra("CountryName");
            mAutoNumber.Text = Intent.GetStringExtra("Code");
            mTxtNumber.Hint = Intent.GetStringExtra("Format");

            mBtnSignUp.Click += mBtnSignUp_Click;
            mAllCountries.Touch += MAllCountries_Touch;
            

        }

        private void MAllCountries_Touch(object sender, View.TouchEventArgs e)
        {
            Intent intent = new Intent(this, typeof(CountryActivity));
            this.StartActivity(intent);
            this.Finish();
            
        }

        

        private void mBtnSignUp_Click(object sender, EventArgs e)
        {
            

            MySqlConnection con = new MySqlConnection("Server=5.101.152.83;Port=3306;database=sports63_chat;User ID=sports63_chat;Password=2908JanaD;charset=utf8");
                try
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        MySqlCommand cmd = new MySqlCommand("INSERT INTO chat (Contacts_Number) VALUES (@number)", con);
                        cmd.Parameters.AddWithValue("@number", mTxtNumber.Text);
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (MySqlException ex)
                {
                    mTxtNumber.Text = ex.ToString();
                }
                finally
                {
                    con.Close();

                }


                Intent intent = new Intent(this, typeof(BaseActivity));
                this.StartActivity(intent);
                this.Finish();

            }
    }
   
}