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
    public class SampleListFragment : Fragment
    {
        private static string ARG_LAYOUT = "arg_layout";
        public static SampleListFragment NewInstance(int layout)
        {
            SampleListFragment fragment = new SampleListFragment();
            Bundle args = new Bundle();
            args.PutInt(ARG_LAYOUT, layout);
            fragment.Arguments = args;
            return fragment;
        }

        public SampleListFragment()
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_list_sample, container, false);
            Picasso picasso = Picasso.With(Activity);
            picasso.LoggingEnabled = true;
            picasso.IndicatorsEnabled = false;

            int listLayout = Arguments.GetInt(ARG_LAYOUT);
            ListView listView = view.FindViewById<ListView>(Resource.Id.list);
            Adapter adapter = new Adapter(Activity, picasso, listLayout);
            listView.Adapter = adapter;

            return view;
        }

        public class Adapter : ArrayAdapter
        {
            private int MULTIPLY = 10;

            Picasso picasso;
            int layout;

            public Adapter(Context context, Picasso picasso, int layout) : base(context, 0)
            {
                this.picasso = picasso;
                this.layout = layout;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                ShapeImageViewQs.Src.SampleListFragment.ViewHolder holder;

                if (convertView == null)
                {
                    convertView = LayoutInflater.FromContext(Context).Inflate(layout, parent, false);
                    holder = new ViewHolder();
                    holder.image = convertView.FindViewById<ImageView>(Resource.Id.image);
                    holder.title = convertView.FindViewById<TextView>(Resource.Id.title);
                    convertView.Tag = holder;
                }
                else
                {
                    holder = (ViewHolder)convertView.Tag;
                }

                position = position % (Constants.IMAGES.Length / 2);

                String title = Constants.IMAGES[position, 1];
                String url = Constants.IMAGES[position, 0];
                holder.title.Text = title;
                picasso.Load(url)
                        .Placeholder(Resource.Drawable.placeholder)
                        .Into(holder.image);
                return convertView;
            }

            public override int Count => (Constants.IMAGES.Length * MULTIPLY);
        }

        public class ViewHolder : Java.Lang.Object
        {
            public ImageView image { get; set; }
            public TextView title { get; set; }
        }
    }
}