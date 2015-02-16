using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Extras
{
    [Activity(Label = "CalledActivity")]			
    public class CalledActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CalledActivity);
            GetParameters();

            var nextActivity = FindViewById<Button>(Resource.Id.button1);
            nextActivity.Click += delegate
            {
                var bndle = new Bundle();
                var firstName = FindViewById<EditText>(Resource.Id.firstName2);
                var lastName = FindViewById<EditText>(Resource.Id.lastName2);
                var age = FindViewById<EditText>(Resource.Id.age2);

                bndle.PutString("firstName", firstName.Text);
                bndle.PutString("lastName", lastName.Text);
                bndle.PutInt("age", int.Parse(age.Text));

                var intent = new Intent();
                intent.PutExtras(bndle);
                SetResult(Result.Ok, intent);
                Finish();
            };
        }

        void GetParameters()
        {
            if (this.Intent.Extras != null)
            {
                var bundle = this.Intent.Extras;

                var firstName = FindViewById<EditText>(Resource.Id.firstName2);
                var lastName = FindViewById<EditText>(Resource.Id.lastName2);
                var age = FindViewById<EditText>(Resource.Id.age2);

                firstName.Text = bundle.GetString("firstName");
                lastName.Text = bundle.GetString("lastName");
                age.Text = bundle.GetInt("age").ToString();
            }
        }
    }
}

