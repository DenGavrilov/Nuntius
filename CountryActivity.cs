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
using Android.Content.Res;
using System.IO;
using System.Collections;
using System.Reflection;
using Nuntius.Model;
using Nuntius.Adapter;
using Android.Graphics;

namespace Nuntius
{
    [Activity(Label = "CountryActivity")]
    public class CountryActivity : ListActivity
    {

        private List<Country> countries = new List<Country>();



        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            ActionBar.SetDisplayShowHomeEnabled(false);
            ActionBar.SetDisplayShowTitleEnabled(false);
            ActionBar.SetCustomView(Resource.Layout.action_bar);
            ActionBar.SetDisplayShowCustomEnabled(true);

            string fontPath = "fonts/Roboto-Medium.ttf";
            TextView ABTitle = FindViewById<TextView>(Resource.Id.txtABCountry);
            Typeface tf = Typeface.CreateFromAsset(Application.Context.Assets, fontPath);
            ABTitle.SetTypeface(tf, TypefaceStyle.Normal);

            using (Stream stream = Assets.Open("countries.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] buffer = line.Split(';');

                        if (buffer.Length == 4)
                        {
                            this.countries.Add(new Country()
                            {
                                Code = buffer[0],
                                ShortName = buffer[1],
                                CountryName = buffer[2],
                                FillNumber = buffer[3]
                            });
                        }
                        else
                        {
                            this.countries.Add(new Country()
                            {
                                Code = buffer[0],
                                ShortName = buffer[1],
                                CountryName = buffer[2],
                                FillNumber = " "
                            });
                        }
                    }
                }
            }

            this.ListAdapter = new CountryAdapter(this, countries);
            this.ListView.FastScrollEnabled = true;

            //Add Click

            this.ListView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(countries[e.Position].CountryName);
            Intent intent = new Intent(this, typeof(SignUpActivity));
            intent.PutExtra("CountryName", countries[e.Position].CountryName);
            intent.PutExtra("Code", countries[e.Position].Code);
            intent.PutExtra("Format", countries[e.Position].FillNumber);
            this.StartActivity(intent);
        }
    }
}

