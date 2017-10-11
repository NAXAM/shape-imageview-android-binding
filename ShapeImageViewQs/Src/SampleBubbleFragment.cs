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
using Android.Views;
using Square.Picasso;

namespace ShapeImageViewQs.Src
{
    public class SampleBubbleFragment : Fragment
    {
        private static string ARG_LAYOUT_1 = "arg_layout_1";
        private static string ARG_LAYOUT_2 = "arg_layout_2";
        public static SampleBubbleFragment NewInstance(int layout1, int layout2)
        {
            SampleBubbleFragment fragment = new SampleBubbleFragment();
            Bundle args = new Bundle();
            args.PutInt(ARG_LAYOUT_1, layout1);
            args.PutInt(ARG_LAYOUT_2, layout2);
            fragment.Arguments = args;
            return fragment;
        }

        public SampleBubbleFragment()
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_chat_sample, container, false);
            Picasso picasso = Picasso.With(this.Activity);
            picasso.LoggingEnabled = true;
            picasso.IndicatorsEnabled = false;

            int listLayout1 = Arguments.GetInt(ARG_LAYOUT_1);
            int listLayout2 = Arguments.GetInt(ARG_LAYOUT_2);
            ListView listView = view.FindViewById<ListView>(Resource.Id.list);
            Adapter adapter = new Adapter(this.Activity, picasso, listLayout1, listLayout2);
            listView.Adapter = adapter;
            return view;
        }

        public class Adapter : ArrayAdapter
        {
            private int MULTIPLY = 10;

            private string[,] IMAGES = new string[,]
            {
                {"https://farm4. flickr.com/3871/15090945282_28a77fdf13_z.jpg", "Morpheus"},
                {"https://farm4. flickr.com/3883/15068310256_891b454952_z.jpg", "Neo"},
            };

            private string[] MESSAGES = new string[]
            {
                "wake up, Neo...",
                "matrix has you",
                "follow the white rabbit",
                "knock, knock, Neo.",
                "whuaat?"
            };

            Picasso picasso;
            int layout1;
            int layout2;

            public Adapter(Context context, Picasso picasso, int layout1, int layout2) : base(context, 0)
            {
                this.picasso = picasso;
                this.layout1 = layout1;
                this.layout2 = layout2;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                ShapeImageViewQs.Src.SampleBubbleFragment.ViewHolder holder;

                int itemViewType = GetItemViewType(position);
                int layout = layout1;
                if (itemViewType == 1)
                {
                    layout = layout2;
                }

                if (convertView == null)
                {
                    convertView = LayoutInflater.FromContext(Context).Inflate(layout, parent, false);
                    holder = new ViewHolder();
                    holder.image = convertView.FindViewById<ImageView>(Resource.Id.image);
                    holder.text = convertView.FindViewById<TextView>(Resource.Id.text);
                    convertView.Tag = holder;
                }
                else
                {
                    holder = (ViewHolder)convertView.Tag;
                }

                position = position % MESSAGES.Length;

                string url;
                string text = MESSAGES[position];
                if (position < 4)
                {
                    url = IMAGES[0, 0];
                }
                else
                {
                    url = IMAGES[1, 0];
                }

                holder.text.Text = text;
                picasso.Load(url)
                        .Placeholder(Resource.Drawable.placeholder)
                        .Into(holder.image);
                return convertView;
            }

            public override int GetItemViewType(int position)
            {
                if (position % MESSAGES.Length == 4)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            public override int ViewTypeCount => base.ViewTypeCount + 1;

            public override int Count => (MESSAGES.Length * MULTIPLY);

        }

        private class ViewHolder : Java.Lang.Object
        {
            public ImageView image { get; set; }
            public TextView text { get; set; }
        }
    }
}