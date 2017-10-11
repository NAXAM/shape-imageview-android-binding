using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Square.Picasso;

namespace ShapeImageViewQs.Src
{
    public class SampleFragment : Fragment
    {
        private static string ARG_LAYOUT = "layout";
        private int layout;

        public static SampleFragment NewInstance(int layout)
        {
            SampleFragment fragment = new SampleFragment();
            Bundle args = new Bundle();
            args.PutInt(ARG_LAYOUT, layout);
            fragment.Arguments = args;
            return fragment;
        }

        public SampleFragment()
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (Arguments != null)
            {
                layout = Arguments.GetInt(ARG_LAYOUT);
            }
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(layout, container, false);
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.relative_test_img_1);
            if (imageView != null)
            {
                imageView.PostDelayed(() =>
                {
                    Picasso.With(Activity).Load(Constants.IMAGES[0, 0]).Into(imageView);
                }, 3000);
            }
            return view;
        }

    }
}