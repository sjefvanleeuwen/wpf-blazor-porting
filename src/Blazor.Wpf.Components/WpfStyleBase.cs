using Microsoft.AspNetCore.Components;

namespace Blazor.Wpf.Components
{
    public abstract class WpfStyleBase : ComponentBase, IText
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        // [Parameter]

        private string _text;

        public string Text { get { return _text; } set { _text = value; StateHasChanged(); } }
        [Parameter]
        public int Height { get; set; }
        [Parameter]
        public string HorizontalContentAlignment { get; set; }
        [Parameter]
        public string HorizontalAlignment { get; set; }
        [Parameter]
        public string Margin { get; set; }
        [Parameter]
        public string Name { get; set; }
        [Parameter]
        public string VerticalAlignment { get; set; }
        [Parameter]
        public int Width { get; set; }
        [Parameter]
        public string IsReadonly { get; set; }

        public string Style
        {
            get
            {
                // WPF Margin is in left,top,right,bottom
                // CSS Margin is in  top, right, bottom, left
                var o = Margin.Split(',');
                return $"position:absolute; margin: {o[1]}px {o[2]}px {o[3]}px {o[0]}px; width: {Width}px; height: {Height}px; vertical-align: {VerticalAlignment}; text-align: {HorizontalAlignment};";
            }
        }
    }
}
