using SimhapuriServices.Mobile.Models;
using Xamarin.Forms;

namespace SimhapuriServices.Mobile.Views
{
    public class ListTypeDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HeaderTemplate { get; set; }
        public DataTemplate ItemTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate (object item, BindableObject container)
        {
            return ((DisplayObject)item).IsHeader ? HeaderTemplate : ItemTemplate;
        }
    }
}