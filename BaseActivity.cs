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
using Android.Support.V7.App;
using Android.Support.V4.App;
using Java.Lang;
using Android.Support.V4.View;
using com.refractored;

namespace Nuntius
{
    [Activity(Label = "Nuntius", Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class BaseActivity : AppCompatActivity
    {

        MyAdapter adapter;
        PagerSlidingTabStrip tabs;
        ViewPager pager;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.BaseLayout);

            adapter = new MyAdapter(SupportFragmentManager);
            pager = FindViewById<ViewPager>(Resource.Id.pager);
            tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);
            pager.Adapter = adapter;
            tabs.SetViewPager(pager);
            tabs.SetBackgroundColor(Android.Graphics.Color.Argb(255, 0, 149, 164));

        }

        public class MyAdapter : FragmentPagerAdapter
        {
            int tabCount = 3;

            public MyAdapter(Android.Support.V4.App.FragmentManager fm): base(fm)
            {

            }
            public override int Count
            {
                get
                {
                    return tabCount;
                }
            }

            public override ICharSequence GetPageTitleFormatted(int position)
            {
                ICharSequence cs;
                if (position == 0)
                    cs = new Java.Lang.String("Android");
                else if(position==1)
                    cs = new Java.Lang.String("IOS");
                else
                    cs = new Java.Lang.String("UWP");
                return cs;
            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return ContentFragment.NewInstance(position);
            }
        }


    }
}