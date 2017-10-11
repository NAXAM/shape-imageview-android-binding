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
using Android.Support.V7.App;
using Android.Support.V4.App;
using Android.Support.V4.View;
using com.refractored;

namespace ShapeImageViewQs.Src
{
    [Activity(Label = "ShapeImageViewQs", MainLauncher = true, Theme = "@style/AppTheme")]
    public class SampleActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_sample);
            SupportActionBar.Hide();
            ViewPager pager = FindViewById<ViewPager>(Resource.Id.pager);
            pager.Adapter = new PagerAdapter(SupportFragmentManager);
            PagerSlidingTabStrip tabStrip = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);
            tabStrip.SetViewPager(pager);
        }
    }

    public class PagerAdapter : FragmentPagerAdapter
    {
        public PagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
        {
        }

        public override int Count
        {
            get
            {
                return 7;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            Android.Support.V4.App.Fragment fragment;

            switch (position)
            {
                case 0:
                    fragment = SampleBubbleFragment.NewInstance(Resource.Layout.list_item_shader_bubble_left, Resource.Layout.list_item_shader_bubble_right);
                    break;
                case 1:
                    fragment = SampleListFragment.NewInstance(Resource.Layout.list_item_shader_circle);
                    break;
                case 2:
                    fragment = SampleListFragment.NewInstance(Resource.Layout.list_item_shader_rounded);
                    break;
                case 3:
                    fragment = SampleFragment.NewInstance(Resource.Layout.fragment_all_sample);
                    break;
                case 4:
                    fragment = SampleFragment.NewInstance(Resource.Layout.fragment_shader_sample);
                    break;
                case 5:
                    fragment = SampleFragment.NewInstance(Resource.Layout.fragment_porter_sample);
                    break;
                case 6:
                default:
                    fragment = SampleFragment.NewInstance(Resource.Layout.fragment_relative_sample);
                    break;
            }

            return fragment;
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            string result;
            switch (position)
            {
                case 0:
                    result = "Chat Bubble(S)";
                    break;
                case 1:
                    result = "Circle(S)";
                    break;
                case 2:
                    result = "Rounded(S)";
                    break;
                case 3:
                    result = "Samples";
                    break;
                case 4:
                    result = "Shaders";
                    break;
                case 5:
                    result = "Porter";
                    break;
                case 6:
                default:
                    result = "Relative";
                    break;

            }
            return new Java.Lang.String(result);
        }
    }
}