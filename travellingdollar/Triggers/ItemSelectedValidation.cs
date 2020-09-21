using Xamarin.Forms;

namespace travellingdollar.Triggers
{
    public class ItemSelectedValidation : TriggerAction<ListView>
    {
        protected override void Invoke(ListView listview)
        {
            listview.IsVisible = false;
        }
    }
}
