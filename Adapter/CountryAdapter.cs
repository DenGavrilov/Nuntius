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
using Java.Lang;
using Nuntius.Model;

namespace Nuntius.Adapter
{
    class CountryAdapter : BaseAdapter<Country>, ISectionIndexer
    {
        private readonly Activity context;
        private readonly IList<Country> items;

        private string[] sections;
        private Java.Lang.Object[] sectionsObjects;
        private Dictionary<string, int> alphabetIndex;

        public CountryAdapter(Activity context, IList<Country> items):
            base()
        {
            this.context = context;
            this.items = items;
            this.BuildSectionIndexer();
        }

        #region Adapter

        public override Country this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;

            if (view == null)

                //view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
                view = context.LayoutInflater.Inflate(Resource.Layout.listview_row, null);


            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.CountryName;
            view.FindViewById<TextView>(Resource.Id.txtCountryName).Text = item.CountryName;
            view.FindViewById<TextView>(Resource.Id.txtCode).Text ="+" + item.Code;

            return view;
        }

        #endregion


        private void BuildSectionIndexer()
        {
            this.alphabetIndex = new Dictionary<string, int>();

            for (int i = 0; i < items.Count; i++)
            {
                var key = items[i].CountryName[0].ToString();
                if(!alphabetIndex.ContainsKey(key))
                    alphabetIndex.Add(key, i);                
            }

            this.sections = alphabetIndex.Keys.ToArray();
            this.sectionsObjects = new Java.Lang.Object[sections.Length];

            for (int i = 0; i < sections.Length; i++)
            {
                sectionsObjects[i] = new Java.Lang.String(sections[i]);
            }
        }

        public int GetPositionForSection(int section)
        {
            return alphabetIndex[sections[section]];
        }

        public int GetSectionForPosition(int position)
        {
            int prevSection = 0;

            for (int i = 0; i < sections.Length; i++)
            {
                if (GetPositionForSection(i) > position && prevSection <= position)
                {
                    prevSection = i;
                    break;
                }
            }

            return prevSection;
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionsObjects;
        }
    }
}