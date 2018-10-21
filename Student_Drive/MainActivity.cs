using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;

namespace Student_Drive
{
    [Activity(Label = "Student Drive", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //FindViewById<TextView>(Resource.Id.NavHeaderUsername).Text = "Ebert";
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.first_Activity);

            FindViewById<Button>(Resource.Id.buttonRegister).Click += (s, e) =>
            {
                var intent = new Intent(this, typeof(RegisterPage));
                StartActivity(intent);
            };
            FindViewById<Button>(Resource.Id.buttonSignIn).Click += (s, e) =>
            {

                // first validate the login details
                EditText txtUsername = FindViewById<EditText>(Resource.Id.userName);
                EditText txtPassword = FindViewById<EditText>(Resource.Id.password);

                if ((txtUsername.Text != string.Empty) && (txtPassword.Text!=string.Empty))
                {
                    // check if the entered values are correct or are in the database
                    Datahandler datahandler = new Datahandler();

                    foreach (LogIn item in datahandler.ReturnLogins())
                    {
                        if (txtUsername.Text==item.Username && txtPassword.Text==item.Password)
                        {
                            Toast.MakeText(this.ApplicationContext, "Login successful", ToastLength.Short);
                            StartActivity(new Intent(this, typeof(MainPage)));
                        }
                    }
                    
                    
                }
                else
                {
                    Toast.MakeText(this.ApplicationContext, "Invalid user credentials. Please try again", ToastLength.Short);
                }
                
            };
        }        
    }
}

