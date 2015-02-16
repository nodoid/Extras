using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace Extras
{
    [Activity(Label = "Extras", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        const int CALLED_ACTIVITY = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.CallingActivity);

            var nextActivity = FindViewById<Button>(Resource.Id.button1);
            nextActivity.Click += delegate
            {
                var intent = new Intent(this, typeof(CalledActivity));
                var bndle = new Bundle();
                var firstName = FindViewById<EditText>(Resource.Id.firstName);
                var lastName = FindViewById<EditText>(Resource.Id.lastName);
                var age = FindViewById<EditText>(Resource.Id.age);

                bndle.PutString("firstName", firstName.Text);
                bndle.PutString("lastName", lastName.Text);
                bndle.PutInt("age", int.Parse(age.Text));

                intent.PutExtras(bndle);
                StartActivityForResult(intent, CALLED_ACTIVITY);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            switch (requestCode)
            {
                case CALLED_ACTIVITY:
                    if (resultCode == Result.Ok)
                    {
                        var bundle = data.Extras;
                        var firstName = FindViewById<EditText>(Resource.Id.firstName);
                        var lastName = FindViewById<EditText>(Resource.Id.lastName);
                        var age = FindViewById<EditText>(Resource.Id.age);
                        firstName.Text = bundle.GetString("firstName");
                        lastName.Text = bundle.GetString("lastName");
                        age.Text = bundle.GetInt("age").ToString();
                    }
                    break;
            }
        }
    }
}


